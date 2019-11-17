using System;

namespace Geometry
{
    public class Circle : ICircle
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
        public virtual Vector2 FindClosestPoint(Vector2 point)
        {
            var vX = point.X - _position.X;
            var vY = point.Y - _position.Y;
            var magV = Math.Sqrt(vX * vX + vY * vY);
            var aX = _position.X + vX / magV * _radius;
            var aY = _position.Y + vY / magV * _radius;
            return new Vector2(aX, aY);
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
