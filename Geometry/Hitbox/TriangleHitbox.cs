using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry.Hitbox
{
    public class TriangleHitbox : IPolygonHitbox
    {
        Triangle _box;

        public IPolygon Box { get => _box; }

        public TriangleHitbox(Vector2 c1, Vector2 c2, Vector2 c3)
        {
            _box = new Triangle(c1, c2, c3);
        }

        public bool Hit(Vector2 point)
        {
            return _box.Contains(point);
        }

        public bool Hit(IPolygonHitbox box)
        {
            if (!BroadCheck(box.Box))
                return false;
            if (CheckHitbox(box.Box))
                return true;
            else return box.CheckHitbox(this._box);
        }

        public bool Hit(CircleHitbox box)
        {
            if (!BroadCheck(box.Box))
                return false;
            if (CheckHitbox(box.Box))
                return true;
            else return box.CheckHitbox(this._box);
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
            var checkpoint = circle.FindClosestPoint(_box.Position);
            return Hit(checkpoint);
        }

        private bool BroadCheck(IShape shape)
        {
            if (shape.MinX > this._box.MaxX || shape.MaxX < this._box.MinX ||
            shape.MaxY < this._box.MinY || shape.MinY > this._box.MaxY)
                return false;
            else return true;
        }
    }
}
