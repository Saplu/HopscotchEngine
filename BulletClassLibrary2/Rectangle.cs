using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletClassLibrary
{
    public class Rectangle : IShape
    {
        int width, height, angle, maxX, maxY, minX, minY;
        Point position;
        List<Point> corners;

        public int Width { get => width; set => setWidth(value); }
        public int Height { get => height; set => setHeight(value); }
        public Point Position { get => position; set => position = changePosition(value); }
        public List<Point> Corners { get => corners; }
        public int Angle { get => angle; set => angle = setAngle(value); }
        public int MaxX { get => maxX; }
        public int MaxY { get => maxY; }
        public int MinX { get => minX; }
        public int MinY { get => minY; }

        public Rectangle(int width, int height, Point position)
        {
            this.width = width;
            this.height = height;
            this.position = position;
            angle = 0;
            corners = calculateCorners(angle);
            setMaxMinValues();
        }

        public Rectangle(int width, int height, Point position, int angle)
        {
            this.width = width;
            this.height = height;
            this.position = position;
            this.angle = angle;
            corners = calculateCorners(angle);
            setMaxMinValues();
        }

        public override bool Equals(object obj)
        {
            var toCompareWith = obj as Rectangle;
            if (toCompareWith == null)
                return false;
            return corners.SequenceEqual(toCompareWith.corners);
        }

        private Point changePosition(Point value)
        {
            value = checkValue(value);
            corners = calculateCorners(angle);
            setMaxMinValues();
            return value;
        }

        private void setWidth(int value)
        {
            width = value;
            corners = calculateCorners(angle);
            setMaxMinValues();            
        }

        private void setHeight(int value)
        {
            height = value;
            corners = calculateCorners(angle);
            setMaxMinValues();
        }

        private int setAngle(int value)
        {
            if (value != angle)
            {
                corners = calculateCorners(value);
            }
            return value;
        }

        private List<Point> calculateCorners(int angle)
        {
            if (angle == 0)
                corners = new List<Point>() { new Point(position.X - width / 2, position.Y - height / 2),
                    new Point(position.X + width / 2, position.Y - height / 2), new Point(position.X - width / 2, position.Y + height / 2),
                    new Point(position.X + width / 2, position.Y + height / 2)};
            else
            {
                corners = new List<Point>();
                for (int i = 0; i < 4; i++)
                {
                    
                    double tempX = 0;
                    double tempY = 0;
                    if (i == 0 || i == 2)
                        tempX = (position.X - width / 2) - position.X;
                    else tempX = (position.X + width / 2) -position.X;
                    if (i == 0 || i == 1)
                        tempY = (position.Y - width / 2) - position.Y;
                    else tempY = (position.Y + width / 2) - position.Y;
                   
                    double rotatedX = (tempX * Math.Cos(angle * Math.PI/180)) - (tempY * Math.Sin(angle * Math.PI/180));
                    double rotatedY = (tempX * Math.Sin(angle * Math.PI/180)) + (tempY * Math.Cos(angle * Math.PI/180));

                    corners.Add(new Point(Convert.ToInt32(rotatedX + position.X), Convert.ToInt32(rotatedY + position.Y)));
                }
            }
            return corners;
        }

        private Point checkValue(Point value)
        {
            if (value.X < width / 2)
                value.X = Convert.ToInt32(width / 2);
            if (value.Y < height / 2)
                value.Y = Convert.ToInt32(height / 2);
            return value;
        }

        private void setMaxMinValues()
        {
            var values = getBorderValues();
            maxX = values[0];
            maxY = values[1];
            minX = values[2];
            minY = values[3];
        }


        private List<int> getBorderValues()
        {
            List<int> xValues = getCornerValues(true);
            List<int> yValues = getCornerValues(false);
            var list = new List<int>();
            list.Add(xValues.Max());
            list.Add(yValues.Max());
            list.Add(xValues.Min());
            list.Add(yValues.Min());
            return list;
        }

        private List<int> getCornerValues(bool isX)
        {
            var values = new List<int>();
            if (isX)
                foreach (var item in corners)
                    values.Add(item.X);
            else foreach (var item in corners)
                    values.Add(item.Y);
            return values;
        }
    }
}
