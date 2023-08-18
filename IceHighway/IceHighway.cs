using System.Numerics;
using static System.Math;

namespace Ice_Highway_Helper.IceHighway
{
    public class IceHighway
    {
        private int x0, z0, x1, z1;
        private bool deg140625;
        private Calculation calculation;
        private int[] ices;

        public IceHighway(int x0, int z0, int x1, int z1, bool deg140625) { 
            this.x0 = x0;
            this.z0 = z0;
            this.x1 = x1;
            this.z1 = z1;
            this.deg140625 = deg140625;
            this.calculation = new Calculation(x0, z0, x1, z1, deg140625);
        }

        public D build(int interval)
        {
            // 获取实际建造冰道角度、理想线路角度
            double realDeg = calculation.getRealDeg();
            if (realDeg == 90.0 || realDeg == -90.0)
            {
                ices = new int[Abs(z0-z1) / interval];
                for (int i = 0; i < Abs(z0 - z1); i += interval)
                {
                    ices[i / interval] = calculation.getCoordinate(i).z;
                }
                return new D(0, realDeg, x1, z1);
            }
            else if (realDeg == 0.0)
            {
                ices = new int[Abs(x0 - x1) / interval];
                for (int i = 0; i < Abs(x0 - x1); i += interval)
                {
                    ices[i / interval] = calculation.getCoordinate(i).x;
                }
                return new D(0, 0.0, x1, z1);
            }
            double idealDeg = Calculation.getDeg(Atan2(z1 - z0, x1 - x0));
            
            // 计算俩线路夹角，计算偏移距离、冰道实际长度、冰道终点坐标

            // 根据终点坐标计算冰道完整路径
        }
    }

    public class D
    {
        public readonly double deviation;    // 冰道终点与目的地距离
        public readonly double buildDeg;     // 实际建造的冰道的角度
        public readonly V2d endpoint;        // 冰道终点坐标

        public D(double deviation, double buildDeg, int x, int z) { 
            this.deviation = deviation;
            this.buildDeg = buildDeg;
            this.endpoint = new V2d(x, z);
        }
    }
}
