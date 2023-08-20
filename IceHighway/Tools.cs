using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ice_Highway_Helper.IceHighway
{
    public class Tools
    {
        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds);
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
}
