using System;
using System.Collections.Generic;
using System.Text;

namespace BulletClassLibrary
{
    public class Hitbox : IHitbox
    {
        Octagon box;

        public Octagon Box { get => box; }

        public Hitbox(int height, int width, Vector2 position)
        {
            box = new Octagon(height, width, position);
        }

        public bool Hit(Vector2 point)
        {
            if (point.Y < box.Corners[0].Y || point.Y > box.Corners[5].Y || point.X < box.Corners[7].X || point.X > box.Corners[2].X)
                return false;
            var corner = checkCorner(point);
            return !box.VirtualCorners[corner].Contains(point);
        }

        public bool Hit(Hitbox box)
        {
            if (!broadCheck(box.Box))
                return false;
            if (CheckHitbox(box.Box))
                return true;
            if (box.CheckHitbox(this.Box))
                return true;
            return pierces(box);
        }

        public bool Hit(RectangleHitbox box)
        {
            if (!broadCheck(box.Box))
                return false;
            if (CheckHitbox(box.Box))
                return true;
            else return box.CheckHitbox(this.box);
        }

        public bool CheckHitbox(IShape hitbox)
        {
            foreach (var point in hitbox.Corners)
            {
                if (Hit(point))
                    return true;
            }
            return false;
        }

        private int checkCorner(Vector2 point)
        {
            if (point.X >= box.Position.X && point.Y <= box.Position.Y)
                return 0;
            if (point.X >= box.Position.X && point.Y >= box.Position.Y)
                return 1;
            if (point.X < box.Position.X && point.Y > box.Position.Y)
                return 2;
            return 3;
        }

        private bool pierces(Hitbox box)
        {
            if (box.box.Corners[2].X > this.box.Corners[2].X && box.box.Corners[7].X < this.box.Corners[7].X &&
                box.box.Corners[1].Y > this.box.Corners[1].Y && box.box.Corners[4].Y < this.box.Corners[4].Y)
                return true;
            if (this.box.Corners[2].X > box.box.Corners[2].X && this.box.Corners[7].X < box.box.Corners[7].X &&
                this.box.Corners[1].Y > box.box.Corners[1].Y && this.box.Corners[4].Y < box.box.Corners[4].Y)
                return true;
            return false;
        }

        private bool broadCheck(IShape shape)
        {
            if (shape.MinX > this.box.MaxX || shape.MaxX < this.box.MinX ||
                shape.MaxY < this.box.MinY || shape.MinY > this.box.MaxY)
                return false;
            else return true;
        }
    }
}
