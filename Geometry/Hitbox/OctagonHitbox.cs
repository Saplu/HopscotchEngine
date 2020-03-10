using System.Collections.Generic;

namespace Geometry
{
    public class OctagonHitbox : IPolygonHitbox
    {
        Octagon _box;

        public IPolygon Box { get => _box; }
        public Vector2 Position { get => _box.Position; }

        public OctagonHitbox(int height, int width, Vector2 position)
        {
            _box = new Octagon(height, width, position);
        }

        public bool Hit(Vector2 point)
        {
            if (point.Y < _box.Corners[0].Y || point.Y > _box.Corners[5].Y || point.X < _box.Corners[7].X || point.X > _box.Corners[2].X)
                return false;
            var corner = CheckCorner(point);
            return !_box.VirtualCorners[corner].Contains(point);
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

        public void UpdatePosition(Vector2 position)
        {
            _box.Position = position;
        }

        public (Vector2, int) HandleCollision(IHitbox item, Vector2 speed, int milliseconds, Vector2 original)
        {
            var collidingCorner = 0;
            for (int i = 0; i < _box.Corners.Count; i++)
            {
                if (item.Hit(_box.Corners[i]))
                {
                    collidingCorner = i;
                    ManagePosition(i, original, item, milliseconds, speed.X);
                    SoftBounce(_box.Corners[i], i, item);
                    speed = ManageSpeed(i, speed);
                }
            }
            return (speed, collidingCorner);
        }

        private int CheckCorner(Vector2 point)
        {
            if (point.X >= _box.Position.X && point.Y <= _box.Position.Y)
                return 0;
            if (point.X >= _box.Position.X && point.Y >= _box.Position.Y)
                return 1;
            if (point.X < _box.Position.X && point.Y > _box.Position.Y)
                return 2;
            return 3;
        }

        private bool Pierces(OctagonHitbox box)
        {
            if (box._box.Corners[2].X > this._box.Corners[2].X && box._box.Corners[7].X < this._box.Corners[7].X &&
                box._box.Corners[1].Y > this._box.Corners[1].Y && box._box.Corners[4].Y < this._box.Corners[4].Y)
                return true;
            if (this._box.Corners[2].X > box._box.Corners[2].X && this._box.Corners[7].X < box._box.Corners[7].X &&
                this._box.Corners[1].Y > box._box.Corners[1].Y && this._box.Corners[4].Y < box._box.Corners[4].Y)
                return true;
            return false;
        }

        private bool BroadCheck(IShape shape)
        {
            if (shape.MinX > this._box.MaxX || shape.MaxX < this._box.MinX ||
                shape.MaxY < this._box.MinY || shape.MinY > this._box.MaxY)
                return false;
            else return true;
        }

        private void ManagePosition(int corner, Vector2 original, IHitbox item, int milliseconds, double speedX)
        {
            var dX = 0.1 * milliseconds;
            switch(corner)
            {
                case 2: _box.Position = new Vector2(original.X - dX, original.Y); break;
                case 3: _box.Position = new Vector2(original.X - dX, original.Y); break;
                case 6: _box.Position = new Vector2(original.X + dX, original.Y); break;
                case 7: _box.Position = new Vector2(original.X + dX, original.Y); break;
                default: _box.Position = original; break;
            }           
        }

        private Vector2 ManageSpeed(int corner, Vector2 speed)
        {
            if (speed.X > 0 && (corner == 3 || corner == 2) || 
                speed.X < 0 && (corner == 6 || corner == 7))
                speed.X = 0;
            if (speed.Y > 0 && (corner == 4 || corner == 5) ||
                speed.Y < 0 && (corner == 0 || corner == 1))
                speed.Y = 0;
            return speed;
        }

        private void SoftBounce(Vector2 original, int corner, IHitbox item)
        {
            var testPoint = new Vector2(original.X, original.Y - 1);
            switch(corner)
            {
                case 4:
                case 5: if (item.Hit(testPoint))
                        _box.Position.Y--;
                    break;
                default: testPoint = new Vector2(original.X, original.Y + 1);
                    if (item.Hit(testPoint))
                        _box.Position.Y++;
                    break;
            }
        }
    }
}
