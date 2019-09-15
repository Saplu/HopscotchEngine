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
            return false;
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
    }
}
