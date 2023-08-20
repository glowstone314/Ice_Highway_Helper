using System.Collections;
using static System.Math;
using static Ice_Highway_Helper.IceHighway.Tools;

namespace Ice_Highway_Helper.IceHighway
{
    public class IceHighway
    {
        private int x0, z0, x1, z1;
        private bool deg140625;
        private Calculation calculation;
        private List<V3d> ices = new List<V3d>();
        private Litematic litematic;

        public IceHighway(int x0, int z0, int x1, int z1, bool deg140625) { 
            this.x0 = x0;
            this.z0 = z0;
            this.x1 = x1;
            this.z1 = z1;
            this.deg140625 = deg140625;
            this.calculation = new Calculation(x0, z0, x1, z1, deg140625);
        }

        public void BuildLitematic(string name, string description, string author)
        {
            litematic = new Litematic(name, description, author);
        }

        public D build(int interval, Block ice, Block button)
        {
            ices.Clear();
            // 获取实际建造冰道角度、理想线路角度
            double realDeg = calculation.getRealDeg();
            if (realDeg == 90.0 || realDeg == -90.0)
            {
                //ices = new int[Abs(z0-z1) / interval];
                for (int i = 0; i < Abs(z0 - z1); i += interval)
                {
                    ices.Add(calculation.getCoordinate(i));
                }
                litematic.AddIceBlocks(ices, ice, button);
                return new D(0, realDeg, x1, z1);
            }
            else if (realDeg == 0.0 || realDeg == 180.0)
            {
                for (int i = 0; i < Abs(x0 - x1); i += interval)
                {
                    ices.Add(calculation.getCoordinate(i));
                }
                litematic.AddIceBlocks(ices, ice, button);
                return new D(0, realDeg, x1, z1);
            }
            double idealDeg = getDeg(Atan2(z1 - z0, x1 - x0));

            // 计算俩线路夹角，计算偏移距离、冰道实际长度、冰道终点坐标
            V2d endPoint;
            D d;
            if (deg140625)
            {
                double angle = Abs(realDeg - idealDeg);
                if (angle > 0.703125) angle = Abs(angle - 360.0);
                double idealDistance = Sqrt(Pow(x1 - x0, 2) + Pow(z1 - z0, 2));
                double deviation = idealDistance * Sin(getRad(angle));
                double realDistance;
                if (angle != 0.0)
                    realDistance = deviation / Tan(getRad(angle));
                else
                    realDistance = idealDistance;
                double endX = x0 + 0.5 + realDistance * Cos(getRad(realDeg));
                double endZ = z0 + 0.5 + realDistance * Sin(getRad(realDeg));
                endPoint = new V2d(endX, endZ);
                d = new D(deviation, realDeg, endPoint);
            }
            else
            {
                endPoint = new V2d(x1, z1);
                d = new D(0.0, realDeg, x1, z1);
            }

            // 根据终点坐标计算冰道完整路径
            int longerSide = Max(Abs(x0 - endPoint.x), Abs(z0 - endPoint.z));
            //ices = new int[longerSide / interval];
            for (int i = 0; i < longerSide; i+=interval)
            {
                ices.Add(calculation.getCoordinate(i));
            }
            litematic.AddIceBlocks(ices, ice, button);
            return d;
        }

        public Litematic GetLitematic()
        {
            return litematic;
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

        public D(double deviation, double buildDeg, V2d endpoint)
        {
            this.deviation = deviation;
            this.buildDeg = buildDeg;
            this.endpoint = endpoint;
        }
    }
}
