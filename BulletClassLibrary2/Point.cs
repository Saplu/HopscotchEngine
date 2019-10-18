using System;
using System.Collections.Generic;
using System.Text;

namespace BulletClassLibrary
{
    public class Point
    {
        double x, y;

        public int X { get => Convert.ToInt32(x); set => x = value; }
        public int Y { get => Convert.ToInt32(y); set => y = value; }

        public Point(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public override bool Equals(object obj)
        {
            var toCompareWith = obj as Point;
            if (toCompareWith == null)
                return false;
            return this.x == toCompareWith.x && this.y == toCompareWith.y;
        }

        public void Update(double X, double Y)
        {
            x += X;
            y += Y;
        }
    }
}
