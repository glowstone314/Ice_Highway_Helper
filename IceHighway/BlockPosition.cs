using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Ice_Highway_Helper.IceHighway
{

    public class V2d
    {
        public int x, z;

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
        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            V2d v = (V2d) obj;
            return this.x == v.x && this.z == v.z;
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + x.GetHashCode();
            result = 31 * result + z.GetHashCode();
            return result;
        }
    }

    public class V3d
    {
        public int x, y, z;

        public V3d(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public V3d(double x, double y, double z)
        {
            this.x = (int)Floor(x);
            this.y = (int)Floor(y);
            this.z = (int)Floor(z);
        }
        public V3d getNewV3d(int dx, int dy, int dz)
        {
            return new V3d(dx + x, dy + y, dz + z);
        }
        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            V3d v = (V3d) obj;
            return this.x == v.x && this.y == v.y && this.z == v.z;
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + x.GetHashCode();
            result = 31 * result + y.GetHashCode();
            result = 31 * result + z.GetHashCode();
            return result;
        }
    }

}
