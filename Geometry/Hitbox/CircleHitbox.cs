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
            if (_box.Radius >= range.CheckRange(_box.Position, point))
                return true;
            return false;
        }

        public bool Hit(OctagonHitbox box)
        {
            var checkpoint = _box.FindClosestPoint(box.Box.Position);
            if (BroadCheck(box.Box))
            {
                if (box.Hit(checkpoint))
                    return true;
                foreach (var corner in box.Box.Corners)
                    if (Hit(corner))
                        return true;
            }
            return false;
        }

        public bool Hit(RectangleHitbox box)
        {
            var checkpoint = _box.FindClosestPoint(box.Box.Position);
            if (BroadCheck(box.Box))
            {
                if (box.Hit(checkpoint))
                    return true;
                foreach (var corner in box.Box.Corners)
                    if (Hit(corner))
                        return true;
            }
            return false;
        }

        public bool Hit(CircleHitbox box)
        {
            var rc = new RangeChecker();
            if (rc.CheckRange(box.Box.Position, this._box.Position) <= box.Box.Radius + this._box.Radius)
                return true;
            return false;
        }

        public bool CheckHitbox(IPolygon hitbox)
        {
            foreach (var point in hitbox.Corners)
            {
                if (Hit(point))
                    return true;
            }
            return false;
        }

        public bool CheckHitbox(ICircle circle)
        {
            var rc = new RangeChecker();
            if (rc.CheckRange(circle.Position, this._box.Position) <= circle.Radius + this._box.Radius)
                return true;
            return false;
        }

        private bool BroadCheck(IShape shape)
        {
            if (shape.MaxX < this._box.MinX || shape.MinX > this._box.MaxX ||
                shape.MaxY < this._box.MinY || shape.MinY > this._box.MaxY)
                return false;
            return true;
        }
    }
}
