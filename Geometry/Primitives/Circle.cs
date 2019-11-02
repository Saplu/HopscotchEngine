namespace Geometry
{
    public class Circle : IShape
    {
        double _maxX, _minX, _maxY, _minY, _radius;
        Vector2 _position;

        public double MaxX { get => _maxX; set => _maxX = value; }
        public double MinX { get => _minX; set => _minX = value; }
        public double MaxY { get => _maxY; set => _maxY = value; }
        public double MinY { get => _minY; set => _minY = value; }
        public double Radius { get => _radius; set => _radius = value; }
        public Vector2 Position { get => _position; set => _position = value; }

        public Circle(Vector2 position, double radius)
        {
            this._position = position;
            this._radius = radius;
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
