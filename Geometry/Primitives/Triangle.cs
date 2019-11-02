using System;
using System.Collections.Generic;

namespace Geometry
{
    public class Triangle : IPolygon
    {
        List<Vector2> corners;
        double maxX, minX, maxY, minY;

        public List<Vector2> Corners { get => corners; set => corners = CheckValue(value); }
        public double MaxX { get => maxX; }
        public double MinX { get => minX; }
        public double MaxY { get => maxY; }
        public double MinY { get => minY; }
        public Vector2 Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Triangle(Vector2 c1, Vector2 c2, Vector2 c3)
        {
            if (c1 != c2 && c2 != c3 && c3 != c1)
            {
                corners = new List<Vector2>() { c1, c2, c3 };
            }
            else throw new Exception("Triangle must have three different corners.");
            SetMaxMinValues();
        }

        public bool Contains(Vector2 point)
        {
            double first, second, third;
            bool hasNeg, hasPos;

            first = Sign(point, corners[0], corners[1]);
            second = Sign(point, corners[1], corners[2]);
            third = Sign(point, corners[2], corners[0]);

            hasNeg = (first <= 0) || (second <= 0) || (third <= 0);
            hasPos = (first >= 0) || (second >= 0) || (third >= 0);

            return !(hasNeg && hasPos);
        }

        private double Sign(Vector2 check, Vector2 corner1, Vector2 corner2)
        {
            return (check.X - corner2.X) * (corner1.Y - corner2.Y) - (corner1.X - corner2.X) * (check.Y - corner2.Y);
        }

        private List<Vector2> CheckValue(List<Vector2> value)
        {
            if (value.Count != 3 || value[0] == value[1] || value[1] == value[2] || value[2] == value[0])
                throw new ArgumentOutOfRangeException("TRIangle contains exactly THREE corners.");
            SetMaxMinValues();
            return value;
        }

        private void SetMaxMinValues()
        {
            minX = int.MaxValue;
            maxX = int.MinValue;
            minY = int.MaxValue;
            maxY = int.MinValue;
            foreach(var corner in corners)
            {
                if (corner.X < minX)
                    minX = corner.X;
                if (corner.X > maxX)
                    maxX = corner.X;
                if (corner.Y < minY)
                    minY = corner.Y;
                if (corner.Y > maxY)
                    maxY = corner.Y;
            }
        }
    }
}
