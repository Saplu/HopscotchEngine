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

        public (Vector2, List<int>) HandleCollision(IHitbox item, Vector2 speed, int milliseconds)
        {
            List<int> collidingCorners = new List<int>();
            for (int i = 0; i < _box.Corners.Count; i++)
            {
                if (item.Hit(_box.Corners[i]))
                {
                    collidingCorners.Add(i);
                    ManagePosition(i, speed, item, milliseconds);
                    speed = ManageSpeed(i, speed);
                }
            }
            return (speed, collidingCorners);
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

        private void ManagePosition(int corner, Vector2 speed, IHitbox item, int milliseconds)
        {
            var newPos = new Vector2(0, 0);
            if (speed.X != 0)
            {
                if (corner == 3 || corner == 2)
                    newPos.X = _box.Position.X - 1;
                else if (corner == 6 || corner == 7)
                    newPos.X = _box.Position.X + 1;
                else newPos.X = _box.Position.X;
            }
            else newPos.X = _box.Position.X;
            if (speed.Y != 0)
            {
                if (corner == 4 || corner == 5)
                    newPos.Y = _box.Position.Y - 1;
                else if (corner == 0 || corner == 1)
                    newPos.Y = _box.Position.Y + 1;
                else newPos.Y = _box.Position.Y;
            }
            else newPos.Y = _box.Position.Y;
            _box.Position = newPos;
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
    }
}
