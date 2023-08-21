using System.Collections;
using static System.Math;
using static Ice_Highway_Helper.IceHighway.Tools;

namespace Ice_Highway_Helper.IceHighway
{
    public class IceHighway
    {
        private List<V3d> ices = new List<V3d>();
        private Litematic litematic;

        public IceHighway(string name, string description, string author) { 
            litematic = new Litematic(name, description, author);
        }

        public void BuildSegmentedly(int interval, Block ice, Block button, Calculation calculation,
                Block middleIce, Block middleButton)
        {
            double deg0 = Ceiling(calculation.GetDeg() / 1.40625) * 1.40625;
            double deg1 = GetOppositeDeg(Floor(calculation.GetDeg() / 1.40625) * 1.40625);
            double line0BeginX = calculation.GetX0();
            double line0BeginZ = calculation.GetZ0();
            double line0EndX = line0BeginX + 1024.0 * Cos(GetRad(deg0));
            double line0EndZ = line0BeginZ + 1024.0 * Sin(GetRad(deg0));
            double line1BeginX = calculation.GetX1();
            double line1BeginZ = calculation.GetZ1();
            double line1EndX = line1BeginX + 1024.0 * Cos(GetRad(deg1));
            double line1EndZ = line1BeginZ + 1024.0 * Sin(GetRad(deg1));

            V2dD middlePoint = GetIntersection(
                    new V2dD(line0BeginX, line0BeginZ), new V2dD(line0EndX, line0EndZ),
                    new V2dD(line1BeginX, line1BeginZ), new V2dD(line1EndX, line1EndZ)
            );
            V3d mp = new V3d(middlePoint.x, 0, middlePoint.z);

            Calculation c0 = new Calculation(
                    (int)Floor(calculation.GetX0()), (int)Floor(calculation.GetZ0()), mp.x, mp.z, true
            );
            Calculation c1 = new Calculation(
                    (int)Floor(calculation.GetX1()), (int)Floor(calculation.GetZ1()), mp.x, mp.z, true
            );

            Build(interval, ice, button, c0);
            Build(interval, ice, button, c1);

            //if (middleIce != null) litematic.SetBlock(mp, middleIce);
            //if (middleButton != null) litematic.SetBlock(mp, middleButton);
            if (middleIce != null) litematic.SetMiddleBlock(mp, middleIce, middleButton);
            
        }

        public D Build(int interval, Block ice, Block button, Calculation calculation)
        {
            int x0 = (int)Floor(calculation.GetX0());
            int x1 = (int)Floor(calculation.GetX1());
            int z0 = (int)Floor(calculation.GetZ0());
            int z1 = (int)Floor(calculation.GetZ1());
            bool deg140625 = calculation.GetDeg140625();
            ices.Clear();
            // 获取实际建造冰道角度、理想线路角度
            double realDeg = calculation.GetDeg();
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
            double idealDeg = GetDeg(Atan2(z1 - z0, x1 - x0));

            // 计算俩线路夹角，计算偏移距离、冰道实际长度、冰道终点坐标
            V2d endPoint;
            D d;
            if (deg140625)
            {
                double angle = Abs(realDeg - idealDeg);
                if (angle > 0.703125) angle = Abs(angle - 360.0);
                double idealDistance = Sqrt(Pow(x1 - x0, 2) + Pow(z1 - z0, 2));
                double deviation = idealDistance * Sin(GetRad(angle));
                double realDistance;
                if (angle != 0.0)
                    realDistance = deviation / Tan(GetRad(angle));
                else
                    realDistance = idealDistance;
                double endX = x0 + 0.5 + realDistance * Cos(GetRad(realDeg));
                double endZ = z0 + 0.5 + realDistance * Sin(GetRad(realDeg));
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
            for (int i = 0; i < longerSide; i+=interval)
            {
                ices.Add(calculation.getCoordinate(i));
            }
            litematic.AddIceBlocks(ices, ice, button);
            return d;
        }

        public Litematic GetLitematic(V3d origin)
        {
            litematic.Adjust(origin);
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
