using System;
using System.Collections.Generic;

namespace Geometry
{
    public class Triangle : IPolygon
    {
        List<Vector2> _corners;
        Vector2 _position;
        double _maxX, _minX, _maxY, _minY;

        public List<Vector2> Corners { get => _corners; set => _corners = CheckValue(value); }
        public double MaxX { get => _maxX; }
        public double MinX { get => _minX; }
        public double MaxY { get => _maxY; }
        public double MinY { get => _minY; }
        public Vector2 Position { get => _position; set => SetPosition(value); }

        public Triangle(Vector2 c1, Vector2 c2, Vector2 c3)
        {
            if (c1 != c2 && c2 != c3 && c3 != c1)
            {
                _corners = new List<Vector2>() { c1, c2, c3 };
            }
            else throw new Exception("Triangle must have three different corners.");
            SetMaxMinValues();
            SetPosition();
        }

        public bool Contains(Vector2 point)
        {
            double first, second, third;
            bool hasNeg, hasPos;

            first = Sign(point, _corners[0], _corners[1]);
            second = Sign(point, _corners[1], _corners[2]);
            third = Sign(point, _corners[2], _corners[0]);

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
            _minX = int.MaxValue;
            _maxX = int.MinValue;
            _minY = int.MaxValue;
            _maxY = int.MinValue;
            foreach(var corner in _corners)
            {
                if (corner.X < _minX)
                    _minX = corner.X;
                if (corner.X > _maxX)
                    _maxX = corner.X;
                if (corner.Y < _minY)
                    _minY = corner.Y;
                if (corner.Y > _maxY)
                    _maxY = corner.Y;
            }
        }

        private void SetPosition()
        {
            var x = (_corners[0].X + _corners[1].X + _corners[2].X) / 3;
            var y = (_corners[0].Y + _corners[1].Y + _corners[2].Y) / 3;
            _position = new Vector2(x, y);
        }

        private void SetPosition(Vector2 position)
        {
            foreach(var corner in _corners)
            {
                corner.X += _position.X - position.X;
                corner.Y += _position.Y - position.Y;
            }
            _position = position;
            SetMaxMinValues();
        }
    }
}
