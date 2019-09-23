using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletClassLibrary
{
    public class Rectangle
    {
        int width, height;
        Point position;
        List<Point> corners;

        public int Width { get => width; set => width = setWidth(value); }
        public int Height { get => height; set => height = setHeight(value); }
        public Point Position { get => position; set => position = changePosition(value); }
        public List<Point> Corners { get => corners; }

        public Rectangle(int width, int height, Point position)
        {
            this.width = width;
            this.height = height;
            this.position = position;
            corners = new List<Point>() { new Point(position.X, position.Y), new Point(position.X + width, position.Y),
            new Point(position.X, position.Y + height), new Point(position.X + width, position.Y + height)};
        }

        private Point changePosition(Point value)
        {
            corners = new List<Point>() { new Point(value.X, value.Y), new Point(value.X + width, value.Y),
            new Point(value.X, value.Y + height), new Point(value.X + width, value.Y + height)};
            return value;
        }

        private int setWidth(int value)
        {
            corners[1].X = position.X + value;
            corners[3].X = position.X + value;
            return value;
        }

        private int setHeight(int value)
        {
            corners[2].Y = position.Y + value;
            corners[3].Y = position.Y + value;
            return value;
        }
    }
}
