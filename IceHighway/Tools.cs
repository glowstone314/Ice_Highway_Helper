namespace Ice_Highway_Helper.IceHighway
{
    public class Tools
    {
        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds);
        }

        public static double GetDeg(double rad)
        {
            return rad * 180.0 / Math.PI;
        }

        public static double GetRad(double deg)
        {
            return deg * Math.PI / 180.0;
        }

        public static double GetMinecraftDeg(double deg)
        {
            deg -= 90.0;
            if (deg < -180.0) deg += 360.0;
            return deg;
        }

        public static double GetOppositeDeg(double deg)
        {
            if (deg < 0) return deg + 180.0;
            else return deg - 180.0;
        }

        public static V2dD GetIntersection(V2dD line0Begin, V2dD line0End, 
                V2dD line1Begin, V2dD line1End)
        {
            double a = 0, b = 0;
            int state = 0;
            if (line0Begin.x != line0End.x)
            {
                a = (line0End.z - line0Begin.z) / (line0End.x - line0Begin.x);
                state |= 1;
            }
            if (line1Begin.x != line1End.x)
            {
                b = (line1End.z - line1Begin.z) / (line1End.x - line1Begin.x);
                state |= 2;
            }
            switch (state)
            {
                case 0: //L1与L2都平行Y轴
                    {
                        if (line0Begin.x == line1Begin.x)
                        {
                            throw new Exception("无法计算交点");
                        }
                        else
                        {
                            throw new Exception("无法计算交点");
                        }
                    }
                case 1: //L1存在斜率, L2平行Y轴
                    {
                        double x = line1Begin.x;
                        double y = (line0Begin.x - x) * (-a) + line0Begin.z;
                        return new V2dD(x, y);
                    }
                case 2: //L1 平行Y轴，L2存在斜率
                    {
                        double x = line0Begin.x;
                        double y = (line1Begin.x - x) * (-b) + line1Begin.z;
                        return new V2dD(x, y);
                    }
                case 3: //L1，L2都存在斜率
                    {
                        if (a == b)
                        {
                            throw new Exception("无法计算交点");
                        }
                        double x = (a * line0Begin.x - b * line1Begin.x - 
                                line0Begin.z + line1Begin.z) / (a - b);
                        double y = a * x - a * line0Begin.x + line0Begin.z;
                        return new V2dD(x, y);
                    }
            }
            throw new Exception("无法计算交点");
        }

        public class V2dD
        {
            public double x;
            public double z;

            public V2dD(double x, double z)
            {
                this.x = x;
                this.z = z;
            }
        }
    }
}
