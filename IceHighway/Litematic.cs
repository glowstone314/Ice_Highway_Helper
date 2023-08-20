using SharpNBT;
using System.Collections;
using static System.Math;

namespace Ice_Highway_Helper.IceHighway
{
    public class Litematic
    {

        public string author, description, name;
        private int minX, minY, minZ, maxX, maxY, maxZ;
        private Dictionary<string, LiteRegion> regions;
        //private Hashtable blocks;

        public Litematic(int x, int y, int z)
        {
            this.minX = x;
            this.minY = y;
            this.minZ = z;
            this.maxX = x;
            this.maxY = y;
            this.maxZ = z;
        }

        public void addIceBlocks(List<V3d> list, Block ice, Block button)
        {
            if (button != null)
            {
                if (0 < minY) minY = 0;
                if (1 > maxY) maxY = 1;
            }
            else
            {
                if (0 < minY) minY = 0;
                else if (0 > maxY) maxY = 0;
            }
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

        /*public void setBlock(V3d v, Block block)
        {
            if (v.x < minX) minX = v.x;
            else if (v.x > maxX) maxX = v.x;
            if (v.y < minY) minY = v.y;
            else if (v.y > maxY) maxY = v.y;
            if (v.z < minZ) minZ = v.z;
            else if (v.z > maxZ) maxZ = v.z;
            blocks.Add(v, block);
        }*/

    }

    internal class LiteRegion
    {
        private int posX, posY, posZ;
        private int sizeX, sizeY, sizeZ;
        private V3d origin;     // “三轴坐标均为最小”的原点
        private Block[] blocks;

        public LiteRegion(V3d begin, V3d end)
        {
            posX = begin.x; posY = begin.y; posZ = begin.z;
            sizeX = end.x - begin.x; sizeY = end.y - begin.y; sizeZ = end.z - begin.z;
            origin = new V3d(Min(begin.x, end.x), Min(begin.y, end.y), Min(begin.z, end.z));
            blocks = new Block[Abs(sizeX * sizeY * sizeZ)];
        }

        public LiteRegion(List<V3d> list, int localBegIndex, int localEndIndex, 
                V3d offset, Block ice, Block button)
        {
            V3d begin = list[localBegIndex];
            V3d end = list[localEndIndex];
            posX = begin.x; posY = begin.y; posZ = begin.z;
            sizeX = end.x - begin.x; sizeY = end.y - begin.y; sizeZ = end.z - begin.z;
            origin = new V3d(Min(begin.x, end.x), Min(begin.y, end.y), Min(begin.z, end.z));
            blocks = new Block[Abs(sizeX * sizeY * sizeZ)];
            for (int i = localBegIndex; i <= localEndIndex; i++)
            {
                setBlockByRealPosition(list[i], ice);
                if (button != null) setBlockByRealPosition(list[i].getNewV3d(0, 1, 0), button);
            }
            posX -= offset.x;
            posY -= offset.y;
            posZ -= offset.z;
            origin.x -= offset.x;
            origin.y -= offset.y;
            origin.z -= offset.z;
        }

        public bool setBlock(int x, int y, int z, Block block)
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

        public bool setBlockByRealPosition(V3d position, Block block)
        {
            if (position.x >= origin.x && position.x < origin.x + Abs(sizeX)
                && position.y >= origin.y && position.y < origin.y + Abs(sizeY)
                && position.z >= origin.z && position.z < origin.z + Abs(sizeZ))
            {
                int localX = position.x - origin.x;
                int localY = position.y - origin.y;
                int localZ = position.z - origin.z;
                blocks[localX + localZ * Abs(sizeZ) + localY * Abs(sizeX * sizeZ)] = block;
                return true;
            }
            return false;
        }

        private Dictionary<Block, int> getBlockPalette()
        {
            Dictionary<Block, int> palette = new Dictionary<Block, int>();
            foreach (Block block in blocks)
            {
                if (block == null) continue;
                if (palette.ContainsKey(block)) palette.Add(block, palette.Count);
            }
            if (palette.ContainsKey(Block.air)) palette.Add(Block.air, palette.Count);
            return palette;
        }

        private LongArrayTag getBlockStates(Dictionary<Block, int> palette)
        {
            int bitsPerBlock = getBits(palette.Count);  // 每个方块占用多少位
            int allBits = bitsPerBlock * blocks.Length; // 所有方块占用多少位
            int longs = allBits / 64 + allBits % 64 == 0 ? 0 : 1;   // 需要多少个long，向上取整
            List<bool> states = new List<bool>();
            foreach (Block block in blocks)             // 遍历方块存入临时bitList
               addBlockInBitList(states, palette[block], bitsPerBlock);

            LongArrayTag tag = new LongArrayTag("BlockStates");
            for (int i = 0; i < longs; i++)
            {
                bool[] local = new bool[64];
                states.CopyTo(i * 64, local, 0, Min(64, states.Count - i * 64));
                tag.Add(getLongFromBitList(local));
            }
            return tag;
        }

        private static void addBlockInBitList(List<bool> list, int block, int bitsPerBlock)
        {
            for (int i = 0; i < bitsPerBlock; i++)
            {
                list.Add((block >> i & 0b1) == 1);
            }
        }

        public static long getLongFromBitList(bool[] bits)
        {
            long l = 0L;
            for (int i = 0; i < Min(64, bits.Length); i++)
            {
                l |= getBySingleBit(bits[i]) << i;
            }
            return l;
        }

        private static long getBySingleBit(bool bit)
        {
            if (bit) return 1L;
            else return 0L;
        }

        public static int getBits(int amount)
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
    }
}
