using System;
using System.Collections.Generic;
using System.Text;

namespace BulletClassLibrary
{
    public class Hitbox : IHitbox
    {
        Octagon box;

        public Octagon Box { get => box; }

        public Hitbox(int height, int width, Point position)
        {
            box = new Octagon(height, width, position);
        }

        public bool Hit(Point point)
        {
            if (point.Y < box.Corners[0].Y || point.Y > box.Corners[5].Y || point.X < box.Corners[7].X || point.X > box.Corners[2].X)
                return false;
            var corner = checkCorner(point);
            return !box.VirtualCorners[corner].Contains(point);
        }

        public bool Hit(Hitbox box)
        {
            if (box.box.Corners[6].X > this.box.Corners[3].X || box.box.Corners[3].X < this.box.Corners[6].X || 
                box.box.Corners[0].Y > this.box.Corners[5].Y || box.box.Corners[5].Y < this.box.Corners[0].Y)
                return false;
            foreach(var point in box.box.Corners)
            {
                if (Hit(point))
                    return true;
            }
            foreach(var point in this.box.Corners)
            {
                if (box.Hit(point))
                    return true;
            }
            return pierces(box);
        }

        public bool Hit(RectangleHitbox box)
        {
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

        private int checkCorner(Point point)
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
    }
}
