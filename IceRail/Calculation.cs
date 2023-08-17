using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace IceRailHelper.IceRail
{
    public class Calculation
    {

        double x0, z0, x1, z1;
        bool deg140625, getZbyX;
        float deg;

        public Calculation(int x0, int z0, int x1, int z1, bool deg140625) 
        {
            // 从方块坐标获取中心坐标
            this.x0 = x0 + 0.5;
            this.z0 = z0 + 0.5;
            this.x1 = x1 + 0.5;
            this.z1 = z1 + 0.5;
            this.deg140625 = deg140625;
            // 转换为船稳定后的角度
            if ( deg140625 )
            {
                if (x1 == x0)
                {
                    deg = z0 < z1 ? 90F : -90F;
                }
                else
                {
                    deg = (float)(Math.Round(getDeg(Math.Atan((z1 - z0) / (x1 - x0))) / 1.40625) * 1.40625);
                }
            }
            // x比z长，就以x坐标求z坐标
            getZbyX = Math.Abs(x0 - x1) > Math.Abs(z0 - z1);
        }

        public V2d getCoordinate(int index)
        {
            if ( deg140625 )
            {
                if (deg == 90F)
                {
                    int z = (int)(z0 + index);
                    return new V2d((int)x0, z);
                }
                else if (deg == -90F)
                {
                    int z = (int) (z0 - index);
                    return new V2d((int)x0, z);
                }
                else if ( getZbyX )
                {

                }
            }
        }

        public static double getDeg(double rad)
        {
            return rad * 180.0 / Math.PI;
        }

        public static double getRad(double deg) 
        {
            return deg * Math.PI / 180.0;
        }

    }

    public class V2d
    {
        public int x;
        public int z;

        public V2d(int x, int z)
        {
            this.x = x;
            this.z = z;
        }
    }
}
