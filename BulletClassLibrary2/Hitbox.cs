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
            var corners = checkCorner(point);
            if (pointInTriangle(point, corners[0], corners[1], corners[2]))
                return false;
            return true;
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
            return false;
        }

        public bool Hit(RectangleHitbox box)
        {
            return false;
        }

        private List<Point> checkCorner(Point point)
        {
            if (point.X > box.Position.X && point.Y < box.Position.Y)
                return new List<Point> { new Point(box.MidTopR.X, box.TopR.Y), box.TopR, box.MidTopR };
            if (point.X > box.Position.X && point.Y > box.Position.Y)
                return new List<Point>() { new Point(box.MidTopR.X, box.BotR.Y), box.BotR, box.MidBotR };
            if (point.X < box.Position.X && point.Y > box.Position.Y)
                return new List<Point>() { new Point(box.MidBotL.X, box.BotR.Y), box.BotL, box.MidBotL };
            return new List<Point>() { new Point(box.MidBotL.X, box.TopR.Y), box.TopL, box.MidTopL };
        }

        private bool pointInTriangle(Point check, Point corner1, Point corner2, Point corner3)
        {
            double first, second, third;
            bool hasNeg, hasPos;

            first = sign(check, corner1, corner2);
            second = sign(check, corner2, corner3);
            third = sign(check, corner3, corner1);

            hasNeg = (first <= 0) || (second <= 0) || (third <= 0);
            hasPos = (first >= 0) || (second >= 0) || (third >= 0);

            return !(hasNeg && hasPos);
        }

        private double sign(Point check, Point corner1, Point corner2)
        {
            return (check.X - corner2.X) * (corner1.Y - corner2.Y) - (corner1.X - corner2.X) * (check.Y - corner2.Y);
        }
    }
}
