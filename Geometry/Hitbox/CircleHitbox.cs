using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    public class CircleHitbox : IHitbox
    {
        Circle _box;

        public Circle Box { get => _box; }

        public CircleHitbox(int radius, Vector2 position)
        {
            _box = new Circle(position, radius);
        }

        public bool Hit(Vector2 point)
        {
            var range = new RangeChecker();
            if (_box.Radius <= range.CheckRange(_box.Position, point))
                return true;
            return false;
        }

        public bool Hit(OctagonHitbox box)
        {
            throw new NotImplementedException();
        }

        public bool Hit(RectangleHitbox box)
        {
            throw new NotImplementedException();
        }

        public bool CheckHitbox(IShape box)
        {
            throw new NotImplementedException();
        }

        public Vector2 FindClosestPoint(Vector2 point)
        {
            var vX = point.X - _box.Position.X;
            var vY = point.Y - _box.Position.Y;
            var magV = Math.Sqrt(vX * vX + vY * vY);
            var aX = _box.Position.X + vX / magV * Box.Radius;
            var aY = _box.Position.Y + vY / magV * Box.Radius;
            return new Vector2(aX, aY);
        }
    }
}
