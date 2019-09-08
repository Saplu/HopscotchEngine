using System;
using System.Collections.Generic;
using System.Text;

namespace BulletClassLibrary
{
    public class Point
    {
        int x, y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Point(int X, int Y)
        {
            if (X < 0 || Y < 0)
                throw new ArgumentOutOfRangeException("Coordinates cannot be negative.");
            x = X;
            y = Y;
        }
    }
}
