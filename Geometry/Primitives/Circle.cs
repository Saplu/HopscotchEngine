using System;

namespace Geometry
{
    public class Circle : IShape
    {
        double _maxX, _minX, _maxY, _minY, _radius;
        Vector2 _position;

        public double MaxX { get => _maxX; }
        public double MinX { get => _minX; }
        public double MaxY { get => _maxY; }
        public double MinY { get => _minY; }
        public double Radius { get => _radius; set => SetRadius(value); }

        public Vector2 Position { get => _position; set => SetPosition(value); }

        public Circle(Vector2 position, double radius)
        {
            this._position = position;
            this._radius = radius;
            GetMaxMinValues();
        }

        private void SetRadius(double value)
        {
            Radius = value;
            GetMaxMinValues();
        }

        private void SetPosition(Vector2 value)
        {
            Position = value;
            GetMaxMinValues();
        }


        private void GetMaxMinValues()
        {
            _maxX = _position.X + _radius;
            _minX = _position.X - _radius;
            _maxY = _position.Y + _radius;
            _minY = _position.Y - _radius;
        }
    }
}
