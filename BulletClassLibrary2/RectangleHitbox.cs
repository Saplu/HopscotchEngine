using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletClassLibrary
{
    public class RectangleHitbox : IHitbox
    {
        Rectangle box;

        public RectangleHitbox(int height, int width, Point position)
        {
            box = new Rectangle(width, height, position);
        }

        public bool Hit(Point point)
        {
            return isInside(point);
        }

        public bool Hit(Hitbox hitbox)
        {
            return false;
        }

        public bool Hit(RectangleHitbox hitbox)
        {
            if (hitbox.box.Width == box.Width && hitbox.box.Height == box.Height)
                return sameSizeCheck(hitbox);
            else  return allSizeCheck(hitbox);
        }

        private bool isInside(Point point)
        {
            if (point.X >= box.Position.X && point.X <= (box.Position.X + box.Width) &&
                point.Y >= box.Position.Y && point.Y <= (box.Position.Y + box.Height))
                return true;
            else return false;
        }

        private bool sameSizeCheck(RectangleHitbox hitbox)
        {
            foreach(var point in hitbox.box.Corners)
            {
                if (isInside(point))
                    return true;
            }
            return false;
        }

        private bool allSizeCheck(RectangleHitbox hitbox)
        {
            var sides = getsides(hitbox);
            for(int i = 0; i < 2; i++)
            {
                if (sides[i][0].X <= box.Position.X && sides[i][1].X >= box.Position.X ||
                    sides[i][1].X >= box.Position.X + box.Width && sides[i][0].X <= box.Position.X + box.Width ||
                    sides[i][0].X >= box.Position.X && sides[i][1].X <= box.Position.X + box.Width)
                {
                    if (checkY(sides))
                        return true;
                }
            }
            return false;
        }

        private Point[][] getsides(RectangleHitbox hitbox)
        {
            var sides = new Point[4][]
            {
                new Point[]{hitbox.box.Corners[0], hitbox.box.Corners[1]},
                new Point[]{hitbox.box.Corners[2], hitbox.box.Corners[3]},
                new Point[]{hitbox.box.Corners[1], hitbox.box.Corners[3]},
                new Point[]{hitbox.box.Corners[0], hitbox.box.Corners[2]}
            };
            return sides;
        }

        private bool checkY(Point[][] sides)
        {
            for (int i = 2; i < 3; i++)
            {
                if (sides[i][0].Y <= box.Position.Y && sides[i][1].Y >= box.Position.Y ||
                    sides[i][0].Y <= box.Position.Y + box.Height && sides[i][1].Y >= box.Position.Y + box.Height ||
                    sides[i][0].Y >= box.Position.Y && sides[i][1].Y <= box.Position.Y + box.Height)
                    return true;
            }
            return false;
        }
    }
}
