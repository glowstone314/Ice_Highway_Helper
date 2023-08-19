using SharpNBT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Ice_Highway_Helper.IceHighway
{
    public class Litematic
    {

        public string author, description, name;
        private int minX, minY, minZ, maxX, maxY, maxZ;
        private Hashtable regions;
        private Hashtable blocks;

        public Litematic(int x, int y, int z)
        {
            this.minX = x;
            this.minY = y;
            this.minZ = z;
            this.maxX = x;
            this.maxY = y;
            this.maxZ = z;
        }

        public void addIceBlocks(ArrayList list, Block ice, Block button)
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
            foreach (V3d v in list)
            {
                if (v.x < minX) minX = v.x;
                if (v.z < minZ) minZ = v.z;
                if (v.x > maxX) maxX = v.x;
                if (v.z > maxZ) maxZ = v.z;
                blocks.Add(v, ice);
                if (button != null) blocks.Add(v.getNewV3d(0, 1, 0), button);
            }
        }

        public void setBlock(V3d v, Block block)
        {
            if (v.x < minX) minX = v.x;
            else if (v.x > maxX) maxX = v.x;
            if (v.y < minY) minY = v.y;
            else if (v.y > maxY) maxY = v.y;
            if (v.z < minZ) minZ = v.z;
            else if (v.z > maxZ) maxZ = v.z;
            blocks.Add(v, block);
        }

        public void buildForIceHighway(int begX, int begZ, int endX, int endZ)
        {
            if (begX == endX || begZ == endZ)
            {
                regions.Add("0", extractRegion(
                    new V3d(begX, minY, begZ), new V3d(endX, maxY, endZ)));
                return;
            }

            int maxSide = Max(maxX - minX, maxZ - minZ);
            int regionCount = (int) Round(maxSide / 16.0);
            if (regionCount > 1)
            {
                if (Abs(begX - endX) > Abs(begZ - endZ))
                {
                    int localBegX = begX, localBegZ = begZ;
                    for (int i = 0; i < regionCount; i++)
                    {
                        int localEndX = (endX - begX) * (i + 1) / regionCount;
                        V3d localEnd = new V3d(localEndX, 0, 
                            (endZ - begZ) * 32 / (endX - begX) * localEndX / 32);
                        localEnd = findBlock(localEnd);
                        if ()
                    }
                }
            }
        }

        private V3d findBlock(V3d pos)
        {
            if (blocks.ContainsKey(pos)) return pos;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    V3d npos = pos.getNewV3d(i, 0, j);
                    if (blocks.ContainsKey(npos)) return npos;
                }
            }
            return null;
        }

        private LiteRegion extractRegion(V3d beg, V3d end)
        {
            LiteRegion region = new LiteRegion(beg, end);
            for (int x = Min(beg.x, end.x); x <= Max(beg.x, end.x); x++)
            {
                for (int y = Min(beg.y, end.y); y <= Max(beg.y, end.y); y++)
                {
                    for (int z = Min(beg.z, end.z); z <= Max(beg.z, end.z); z++)
                    {
                        V3d position = new V3d(x, y, z);
                        if (blocks.ContainsKey(position))
                            region.setBlockByRealPosition(position, (Block)blocks[position]);
                        else
                            region.setBlockByRealPosition(position, Block.air);
                    }
                }
            }
            return region;
        }

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
