using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletClassLibrary
{
    public class RangeChecker
    {
        public double CheckRange(Vector2 a, Vector2 b)
        {
            var x = Math.Abs(a.X - b.X);
            var y = Math.Abs(a.Y - b.Y);
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
    }
}
