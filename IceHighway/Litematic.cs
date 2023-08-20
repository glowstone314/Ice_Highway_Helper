using SharpNBT;
using System.Collections;
using static System.Math;
using static Ice_Highway_Helper.IceHighway.Tools;
using System.Diagnostics;

namespace Ice_Highway_Helper.IceHighway
{
    public class Litematic
    {

        public string author, description, name;
        //private int minX, minY, minZ, maxX, maxY, maxZ;
        private Dictionary<string, LiteRegion> regions;
        //private Hashtable blocks;

        public Litematic(string name, string description, string author)
        {
            this.name = name;
            this.description = description;
            this.author = author;
            regions = new Dictionary<string, LiteRegion>();
        }

        public void AddIceBlocks(List<V3d> list, Block ice, Block button)
        {
            /*if (button != null)
            {
                if (0 < minY) minY = 0;
                if (1 > maxY) maxY = 1;
            }
            else
            {
                if (0 < minY) minY = 0;
                else if (0 > maxY) maxY = 0;
            }*/
            V3d begin = list[0];
            V3d end = list[list.Count - 1];
            int shorterSide = Min(Abs(begin.x - end.x), Abs(begin.z - end.z));
            if (shorterSide > 16)
            {
                int count = (shorterSide * 2 / 16 + 1) / 2;
                for (int i = 0; i < count; i++)
                {
                    int localBegIndex = list.Count * i / count;
                    int localEndIndex = list.Count * (i + 1) / count - 1;
                    regions.Add(regions.Count.ToString(), 
                        new LiteRegion(list, localBegIndex, localEndIndex, begin, ice, button));
                }
            }
            else
            {
                regions.Add(regions.Count.ToString(), new LiteRegion(list, 0, list.Count - 1, begin, ice, button));
            }
        }

        public CompoundTag BuildLitematic()
        {
            CompoundTag root = new CompoundTag("");

            CompoundTag data = new CompoundTag("Metadata");
            data.Add(new StringTag("Author", author));
            data.Add(new StringTag("Description", description));
            data.Add(new StringTag("Name", name));
            data.Add(new IntTag("RegionCount", this.regions.Count));
            long now = GetTimeStamp();
            data.Add(new LongTag("TimeCreated", now));
            data.Add(new LongTag("TimeModified", now));
            root.Add(data);

            CompoundTag regionsTag = new CompoundTag("Regions");
            foreach (string name in regions.Keys)
            {
                regionsTag.Add(regions[name].GetTag(name));
            }
            root.Add(regionsTag);

            root.Add(new IntTag("MinecraftDataVersion", 2586));
            root.Add(new IntTag("SubVersion", 1));
            root.Add(new IntTag("Version", 5));

            return root;
        }

    }

    internal class LiteRegion
    {
        private int posX, posY, posZ;
        private int sizeX, sizeY, sizeZ;
        private V3d origin;     // “三轴坐标均为最小”的原点
        private Block[] blocks;

        public int GetSize(int end, int beg)
        {
            int size = end - beg;
            if (size < 0) size -= 1;
            else size += 1;
            return size;
        }

        public LiteRegion(V3d begin, V3d end)
        {
            posX = begin.x; posY = begin.y; posZ = begin.z;
            sizeX = GetSize(end.x, begin.x); 
            sizeY = GetSize(end.y, begin.y); 
            sizeZ = GetSize(end.z, begin.z);
            origin = new V3d(Min(begin.x, end.x), Min(begin.y, end.y), Min(begin.z, end.z));
            blocks = new Block[Abs(sizeX * sizeY * sizeZ)];
        }

        public LiteRegion(List<V3d> list, int localBegIndex, int localEndIndex, 
                V3d offset, Block ice, Block button)
        {
            V3d begin = list[localBegIndex];
            V3d end = list[localEndIndex];
            posX = begin.x; posY = begin.y; posZ = begin.z;
            sizeX = GetSize(end.x, begin.x);
            if (button != null) sizeY = 2;
            else sizeY = 1;
            sizeZ = GetSize(end.z, begin.z);
            origin = new V3d(Min(begin.x, end.x), Min(begin.y, end.y), Min(begin.z, end.z));
            blocks = new Block[Abs(sizeX * sizeY * sizeZ)];
            for (int i = localBegIndex; i <= localEndIndex; i++)
            {
                SetBlockByRealPosition(list[i], ice);
                if (button != null) SetBlockByRealPosition(list[i].getNewV3d(0, 1, 0), button);
            }
            posX -= offset.x;
            posY -= offset.y;
            posZ -= offset.z;
            origin.x -= offset.x;
            origin.y -= offset.y;
            origin.z -= offset.z;
        }

        public bool SetBlock(int x, int y, int z, Block block)
        {
            if (x + z * Abs(sizeX) + y * Abs(sizeX * sizeZ) >= blocks.Length)
            {
                return false;
            }
            else
            {
                blocks[x + z * Abs(sizeZ) + y * Abs(sizeX * sizeZ)] = block;
                return true;
            }
        }

        public bool SetBlockByRealPosition(V3d position, Block block)
        {
            if (position.x >= origin.x && position.x < origin.x + Abs(sizeX)
                && position.y >= origin.y && position.y < origin.y + Abs(sizeY)
                && position.z >= origin.z && position.z < origin.z + Abs(sizeZ))
            {
                int localX = position.x - origin.x;
                int localY = position.y - origin.y;
                int localZ = position.z - origin.z;
                blocks[localX + localZ * Abs(sizeX) + localY * Abs(sizeX * sizeZ)] = block;
                return true;
            }
            return false;
        }

        private LongArrayTag GetBlockStates(Dictionary<Block, int> palette)
        {
            int bitsPerBlock = GetBits(palette.Count);  // 每个方块占用多少位
            int allBits = bitsPerBlock * blocks.Length; // 所有方块占用多少位
            int longs = allBits / 64 + (allBits % 64 == 0 ? 0 : 1);   // 需要多少个long，向上取整
            List<bool> states = new List<bool>();
            foreach (Block block in blocks)             // 遍历方块存入临时bitList
               AddBlockInBitList(states, palette[block], bitsPerBlock);

            LongArrayTag tag = new LongArrayTag("BlockStates");
            for (int i = 0; i < longs; i++)
            {
                bool[] local = new bool[64];
                states.CopyTo(i * 64, local, 0, Min(64, states.Count - i * 64));
                tag.Add(GetLongFromBitList(local));
            }
            return tag;
        }

        private static void AddBlockInBitList(List<bool> list, int block, int bitsPerBlock)
        {
            for (int i = 0; i < bitsPerBlock; i++)
            {
                list.Add((block >> i & 0b1) == 1);
            }
        }

        public static long GetLongFromBitList(bool[] bits)
        {
            long l = 0L;
            for (int i = 0; i < Min(64, bits.Length); i++)
            {
                l |= GetBySingleBit(bits[i]) << i;
            }
            return l;
        }

        private static long GetBySingleBit(bool bit)
        {
            if (bit) return 1L;
            else return 0L;
        }

        public static int GetBits(int amount)
        {
            if (amount < 5)
                return 2;
            else if (amount < 9)
                return 3;
            else if (amount < 17)
                return 4;
            else if (amount < 33)
                return 5;
            else if (amount < 65)
                return 6;
            else if (amount < 129)
                return 7;
            else if (amount < 257)
                return 8;
            else if (amount < 513)
                return 9;
            else if (amount < 1025)
                return 10;
            else if (amount < 2049)
                return 11;
            else if (amount < 4097)
                return 12;
            else if (amount < 8193)
                return 13;
            else
                return 14;
        }

        public CompoundTag GetTag(string name)
        {
            CompoundTag tag = new CompoundTag(name);

            CompoundTag pos = new CompoundTag("Position");
            pos.Add(new IntTag("x", posX));
            pos.Add(new IntTag("y", posY));
            pos.Add(new IntTag("z", posZ));
            tag.Add(pos);
            CompoundTag size = new CompoundTag("Size");
            size.Add(new IntTag("x", sizeX));
            size.Add(new IntTag("y", sizeY));
            size.Add(new IntTag("z", sizeZ));
            tag.Add(size);

            ListTag paletteL = new ListTag("BlockStatePalette", TagType.Compound);
            Dictionary<Block, int> paletteD = new Dictionary<Block, int>();
            paletteD.Add(Block.air, 0);
            paletteL.Add(Block.air.getTag());
            for (int i = 0; i < blocks.Length; i++)
            {
                if (blocks[i] == null)
                {
                    blocks[i] = Block.air;
                    continue;
                }
                if (!paletteD.ContainsKey(blocks[i]))
                {
                    paletteD.Add(blocks[i], paletteD.Count);
                    paletteL.Add(blocks[i].getTag());
                }
            }
            tag.Add(paletteL);
            tag.Add(GetBlockStates(paletteD));

            return tag;
        }
    }
}
