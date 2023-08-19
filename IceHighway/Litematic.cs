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

    }

    internal class LiteRegion
    {
        private int posX, posY, posZ;
        private int sizeX, sizeY, sizeZ;
        private Block[] blocks;

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
