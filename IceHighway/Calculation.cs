﻿using static System.Math;
using static Ice_Highway_Helper.IceHighway.Tools;

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
                deg = Round(Tools.GetDeg(Atan2(z1 - z0, x1 - x0)) / 1.40625) * 1.40625;
            else
                deg = Tools.GetDeg(Atan2(z1 - z0, x1 - x0));
            // x比z长，就以x坐标求z坐标
            getZbyX = Abs(x0 - x1) > Abs(z0 - z1);
        }

        public double GetDeg() {
            return deg;
        }

        public V3d getCoordinate(int index)
        {
            int dx = x0 < x1 ? index : -index;
            int dz = z0 < z1 ? index : -index;
            if ( deg140625 )
            {
                if (deg == 90.0 || deg == -90.0)
                {
                    return new V3d(x0, 0, z0 + dz);
                }
                else if ( getZbyX )
                {
                    return new V3d(x0 + dx, 0, z0 + dx * Tan(GetRad(deg)));
                }
                else
                {
                    return new V3d(x0 + dz / Tan(GetRad(deg)), 0, z0 + dz);
                }
            }
            else
            {
                if ( getZbyX )
                {
                    if (z1 == z0)
                    {
                        return new V3d(x0 + dx, 0, z0);
                    }
                    double z = Abs((z1 - z0) / (x1 - x0)) * dz + z0;
                    return new V3d(x0 + dx, 0, z);
                }
                else
                {
                    if (x1 == x0)
                    {
                        return new V3d(x0, 0, z0 + dz);
                    }
                    double x = Abs((x1 - x0) / (z1 - z0)) * dx + x0;
                    return new V3d(x, 0, z0 + dz);
                }
            }
        }

        public double GetX0()
        {
            return x0;
        }
        public double GetX1()
        {
            return x1;
        }
        public double GetZ0()
        {
            return z0;
        }
        public double GetZ1()
        {
            return z1;
        }
        public bool GetDeg140625()
        {
            return deg140625;
        }
    }
}
