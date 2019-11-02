using System;

namespace Geometry
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
