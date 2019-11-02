using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometry
{
    public class Rectangle : IPolygon
    {
        int width, height, angle;
        double maxX, maxY, minX, minY;
        Vector2 position;
        List<Vector2> corners;

        public int Width { get => width; set => setWidth(value); }
        public int Height { get => height; set => setHeight(value); }
        public Vector2 Position { get => position; set => position = changePosition(value); }
        public List<Vector2> Corners { get => corners; }
        public int Angle { get => angle; set => angle = setAngle(value); }
        public double MaxX { get => maxX; }
        public double MaxY { get => maxY; }
        public double MinX { get => minX; }
        public double MinY { get => minY; }

        public Rectangle(int width, int height, Vector2 position)
        {
            this.width = width;
            this.height = height;
            this.position = position;
            angle = 0;
            corners = calculateCorners(angle);
            setMaxMinValues();
        }

        public Rectangle(int width, int height, Vector2 position, int angle)
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

        private Vector2 changePosition(Vector2 value)
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

        private List<Vector2> calculateCorners(int angle)
        {
            if (angle == 0)
                corners = new List<Vector2>() { new Vector2(position.X - width / 2, position.Y - height / 2),
                    new Vector2(position.X + width / 2, position.Y - height / 2), new Vector2(position.X - width / 2, position.Y + height / 2),
                    new Vector2(position.X + width / 2, position.Y + height / 2)};
            else
            {
                corners = new List<Vector2>();
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

                    corners.Add(new Vector2(Convert.ToInt32(rotatedX + position.X), Convert.ToInt32(rotatedY + position.Y)));
                }
            }
            return corners;
        }

        private Vector2 checkValue(Vector2 value)
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
                    values.Add(Convert.ToInt32(item.X));
            else foreach (var item in corners)
                    values.Add(Convert.ToInt32(item.Y));
            return values;
        }

        public override int GetHashCode()
        {
            var hashCode = -649387116;
            hashCode = hashCode * -1521134295 + width.GetHashCode();
            hashCode = hashCode * -1521134295 + height.GetHashCode();
            hashCode = hashCode * -1521134295 + angle.GetHashCode();
            hashCode = hashCode * -1521134295 + maxX.GetHashCode();
            hashCode = hashCode * -1521134295 + maxY.GetHashCode();
            hashCode = hashCode * -1521134295 + minX.GetHashCode();
            hashCode = hashCode * -1521134295 + minY.GetHashCode();
            return hashCode;
        }
    }
}
