using System;
using System.Collections.Generic;
using System.Text;

namespace BulletClassLibrary
{
    public class Hitbox
    {
        Octagon box;

        public Hitbox(int height, int width, Point position)
        {
            box = new Octagon(height, width, position);
        }

        public bool Hit(Point point)
        {
            if (point.Y < box.TopL.Y || point.Y > box.BotL.Y || point.X < box.MidTopL.X || point.X > box.MidTopR.X)
                return false;
            var corner = checkCorner(point);
            return !box.VirtualCorners[corner].Contains(point);
        }

        public bool Hit(Hitbox box)
        {
            if (box.box.MidBotL.X > this.box.MidBotR.X || box.box.MidBotR.X < this.box.MidBotL.X || 
                box.box.TopL.Y > this.box.BotL.Y || box.box.BotL.Y < this.box.TopL.Y)
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
            return false;
        }

        public bool Hit(RectangleHitbox box)
        {
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
    }
}
