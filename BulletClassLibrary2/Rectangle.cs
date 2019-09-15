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

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public Point Position { get => position; set => position = value; }
        public List<Point> Corners { get => corners; set => corners = value; }

        public Rectangle(int width, int height, Point position)
        {
            this.width = width;
            this.height = height;
            this.position = position;
            corners = new List<Point>() { new Point(position.X, position.Y), new Point(position.X + width, position.Y),
            new Point(position.X, position.Y + height), new Point(position.X + width, position.Y + height)};
        }
    }
}
