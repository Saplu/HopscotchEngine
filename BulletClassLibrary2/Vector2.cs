using System;
using System.Collections.Generic;
using System.Text;

namespace BulletClassLibrary
{
    public class Vector2
    {
        double x, y;

        public double X { get => Convert.ToInt32(x); set => x = value; }
        public double Y { get => Convert.ToInt32(y); set => y = value; }

        public Vector2(double X, double Y)
        {
            x = X;
            y = Y;
        }

        public override bool Equals(object obj)
        {
            var toCompareWith = obj as Vector2;
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
