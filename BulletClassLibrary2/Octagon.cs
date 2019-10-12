using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletClassLibrary
{
    public class Octagon : IShape
    {
        int height, width;
        Point topL, topR, midTopR, midBotR, midTopL, midBotL, botL, botR, position;
        List<Point> corners;
        List<Triangle> virtualCorners;

        public int Height { get => height; set => height = setHeight(value); }
        public int Width { get => width; set => width = setWidth(value); }
        public Point Position { get => position; set => position = changePosition(value); }
        public List<Point> Corners { get => corners; }
        public List<Triangle> VirtualCorners { get => virtualCorners; }

        public Octagon(int height, int width, Point position)
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
            corners = new List<Point>() { topL, topR, midTopR, midBotR, botR, botL, midBotL, midTopL};
            virtualCorners = new List<Triangle>() { new Triangle(topR, new Point(midTopR.X, topR.Y), midTopR),
            new Triangle(midBotR, new Point(midBotR.X, botR.Y), botR),
            new Triangle(botL, new Point(midBotL.X, botL.Y), midBotL),
            new Triangle(midTopL, new Point(midTopL.X, topL.Y), topL)};
        }

        public override bool Equals(object obj)
        {
            var toCompareWith = obj as Octagon;
            if (toCompareWith == null)
                return false;
            return corners.SequenceEqual(toCompareWith.corners);
        }

        private Point changePosition(Point value)
        {
            value = checkValue(value);
            var moveX = value.X - position.X;
            var moveY = value.Y - position.Y;
            foreach(var point in corners)
            {
                point.X += moveX;
                point.Y += moveY;
            }
            foreach(var triangle in virtualCorners)
            {
                triangle.Corners[1].X += moveX;
                triangle.Corners[1].Y += moveY;
            }
            return value;
        }

        private int setHeight(int value)
        {
            corners[0].Y = position.Y - Convert.ToInt32(value / 2);
            corners[1].Y = position.Y - Convert.ToInt32(value / 2);
            corners[2].Y = position.Y - Convert.ToInt32(value / 4);
            corners[3].Y = position.Y + Convert.ToInt32(value / 4);
            corners[4].Y = position.Y + Convert.ToInt32(value / 2);
            corners[5].Y = position.Y + Convert.ToInt32(value / 2);
            corners[6].Y = position.Y + Convert.ToInt32(value / 4);
            corners[7].Y = position.Y - Convert.ToInt32(value / 4);
            return value;
        }

        private int setWidth(int value)
        {
            corners[0].X = position.X - Convert.ToInt32(value / 4);
            corners[1].X = position.X + Convert.ToInt32(value / 4);
            corners[2].X = position.X + Convert.ToInt32(value / 2);
            corners[3].X = position.X + Convert.ToInt32(value / 2);
            corners[4].X = position.X + Convert.ToInt32(value / 4);
            corners[5].X = position.X - Convert.ToInt32(value / 4);
            corners[6].X = position.X - Convert.ToInt32(value / 2);
            corners[7].X = position.X - Convert.ToInt32(value / 2);
            return value;
        }

        private Point checkValue(Point value)
        {
            if (value.X < width / 2)
                value.X = Convert.ToInt32(width / 2);
            if (value.Y < height / 2)
                value.Y = Convert.ToInt32(height / 2);
            return value;
        }
    }
}
