using System;
using System.Collections.Generic;
using System.Text;

namespace BulletClassLibrary
{
    public class Point
    {
        int x, y;

        public int X { get => x; set => x = checkValue(value); }
        public int Y { get => y; set => y = checkValue(value); }

        public Point(int X, int Y)
        {
            x = checkValue(X);
            y = checkValue(Y);
        }

        public override bool Equals(object obj)
        {
            var toCompareWith = obj as Point;
            if (toCompareWith == null)
                return false;
            return this.x == toCompareWith.x && this.y == toCompareWith.y;
        }

        private int checkValue(int check)
        {
            if (check < 0)
                throw new ArgumentOutOfRangeException("Coordinates cannot be negative.");
            return check;
        }
    }
}
