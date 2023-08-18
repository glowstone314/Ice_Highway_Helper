using System.Diagnostics;
using static System.Math;

namespace Ice_Highway_Helper.IceHighway
{
    public class Calculation
    {

        private double x0, z0, x1, z1;
        private bool deg140625, getZbyX;
        private double deg;

        public Calculation(int x0, int z0, int x1, int z1, bool deg140625) 
        {
            // 从方块坐标获取中心坐标
            this.x0 = x0 + 0.5;
            this.z0 = z0 + 0.5;
            this.x1 = x1 + 0.5;
            this.z1 = z1 + 0.5;
            this.deg140625 = deg140625;
            // 转换为船稳定后的角度
            if (deg140625)
                deg = Round(getDeg(Atan2(z1 - z0, x1 - x0)) / 1.40625) * 1.40625;
            else
                deg = getDeg(Atan2(z1 - z0, x1 - x0));
            // x比z长，就以x坐标求z坐标
            getZbyX = Abs(x0 - x1) > Abs(z0 - z1);
        }

        public double getRealDeg() {
            return deg;
        }

        public V2d getCoordinate(int index)
        {
            int dx = x0 < x1 ? index : -index;
            int dz = z0 < z1 ? index : -index;
            if ( deg140625 )
            {
                if (deg == 90.0 || deg == -90.0)
                {
                    return new V2d(x0, z0 + dz);
                }
                else if ( getZbyX )
                {
                    return new V2d(x0 + dx, z0 + dx * Tan(getRad(deg)));
                }
                else
                {
                    return new V2d(x0 + dz / Tan(getRad(deg)), z0 + dz);
                }
            }
            else
            {
                if ( getZbyX )
                {
                    if (z1 == z0)
                    {
                        return new V2d(x0 + dx, z0);
                    }
                    double z = (z1 - z0) * index / (x1 - x0) + z0;
                    return new V2d(x0 + dx, z);
                }
                else
                {
                    if (x1 == x0)
                    {
                        return new V2d(x0, z0 + dz);
                    }
                    double x = (x1 - x0) * index / (z1 - z0) + x0;
                    return new V2d(x, z0 + dz);
                }
            }
        }

        public static double getDeg(double rad)
        {
            return rad * 180.0 / PI;
        }

        public static double getRad(double deg) 
        {
            return deg * PI / 180.0;
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
        public V2d(double x, double z)
        {
            this.x = (int)Floor(x);
            this.z = (int)Floor(z);
        }
    }
}
