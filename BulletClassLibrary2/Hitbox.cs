using System;
using System.Collections.Generic;
using System.Text;

namespace BulletClassLibrary
{
    public class Hitbox
    {
        int height, width;
        public Point topL, topR, midTopR, midBotR, midTopL, midBotL, botL, botR, position;

        public Hitbox(int height, int width, Point position)
        {
            this.position = position;
            topL = new Point(position.X - Convert.ToInt32(width / 4), position.Y - Convert.ToInt32(height / 2));
            topR = new Point(position.X + Convert.ToInt32(width / 4), position.Y - Convert.ToInt32(height / 2));
            midTopR = new Point(position.X + Convert.ToInt32(width / 2), position.Y - Convert.ToInt32(height / 4));
            midBotR = new Point(position.X + Convert.ToInt32(width / 2), position.Y + Convert.ToInt32(height / 4));
            midTopL = new Point(position.X - Convert.ToInt32(width / 2), position.Y - Convert.ToInt32(height / 4));
            midBotL = new Point(position.X - Convert.ToInt32(width / 2), position.Y + Convert.ToInt32(height / 4));
            botL = new Point(position.X - Convert.ToInt32(width / 4), position.Y + Convert.ToInt32(height / 2));
            botR = new Point(position.X + Convert.ToInt32(width / 4), position.Y + Convert.ToInt32(height / 2));
        }

        public bool Hit(Point point)
        {
            if (point.Y < topL.Y || point.Y > botL.Y || point.X < midTopL.X || point.X > midTopR.X)
                return false;
            var corners = checkCorner(point);
            if (pointInTriangle(point, corners[0], corners[1], corners[2]))
                return false;
            return true;
        }

        private List<Point> checkCorner(Point point)
        {
            if (point.X > position.X && point.Y < position.Y)
                return new List<Point> { new Point(midTopR.X, topR.Y), topR, midTopR };
            if (point.X > position.X && point.Y > position.Y)
                return new List<Point>() { new Point(midTopR.X, botR.Y), botR, midBotR };
            if (point.X < position.X && point.Y > position.Y)
                return new List<Point>() { new Point(midBotL.X, botR.Y), botL, midBotL };
            return new List<Point>() { new Point(midBotL.X, topR.Y), topL, midTopL };
        }

        private bool pointInTriangle(Point check, Point corner1, Point corner2, Point corner3)
        {
            double first, second, third;
            bool hasNeg, hasPos;

            first = sign(check, corner1, corner2);
            second = sign(check, corner2, corner3);
            third = sign(check, corner3, corner1);

            hasNeg = (first < 0) || (second < 0) || (third < 0);
            hasPos = (first > 0) || (second > 0) || (third > 0);

            return !(hasNeg && hasPos);
        }

        private double sign(Point check, Point corner1, Point corner2)
        {
            return (check.X - corner2.X) * (corner1.Y - corner2.Y) - (corner1.X - corner2.X) * (check.Y - corner2.Y);
        }
    }
}
