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
        double maxX, minX, maxY, minY;
        Vector2 topL, topR, midTopR, midBotR, midTopL, midBotL, botL, botR, position;
        List<Vector2> corners;
        List<Triangle> virtualCorners;

        public int Height { get => height; set => height = setHeight(value); }
        public int Width { get => width; set => width = setWidth(value); }
        public Vector2 Position { get => position; set => position = changePosition(value); }
        public List<Vector2> Corners { get => corners; }
        public List<Triangle> VirtualCorners { get => virtualCorners; }
        public double MaxX { get => maxX; }
        public double MinX { get => minX; }
        public double MaxY { get => maxY; }
        public double MinY { get => minY; }

        public Octagon(int height, int width, Vector2 position)
        {
            this.position = position;
            topL = new Vector2(position.X - Convert.ToInt32(width / 4), position.Y - Convert.ToInt32(height / 2));
            topR = new Vector2(position.X + Convert.ToInt32(width / 4), position.Y - Convert.ToInt32(height / 2));
            midTopR = new Vector2(position.X + Convert.ToInt32(width / 2), position.Y - Convert.ToInt32(height / 4));
            midBotR = new Vector2(position.X + Convert.ToInt32(width / 2), position.Y + Convert.ToInt32(height / 4));
            midTopL = new Vector2(position.X - Convert.ToInt32(width / 2), position.Y - Convert.ToInt32(height / 4));
            midBotL = new Vector2(position.X - Convert.ToInt32(width / 2), position.Y + Convert.ToInt32(height / 4));
            botL = new Vector2(position.X - Convert.ToInt32(width / 4), position.Y + Convert.ToInt32(height / 2));
            botR = new Vector2(position.X + Convert.ToInt32(width / 4), position.Y + Convert.ToInt32(height / 2));
            corners = new List<Vector2>() { topL, topR, midTopR, midBotR, botR, botL, midBotL, midTopL};
            setMaxMinValues();
            virtualCorners = new List<Triangle>() { new Triangle(topR, new Vector2(midTopR.X, topR.Y), midTopR),
            new Triangle(midBotR, new Vector2(midBotR.X, botR.Y), botR),
            new Triangle(botL, new Vector2(midBotL.X, botL.Y), midBotL),
            new Triangle(midTopL, new Vector2(midTopL.X, topL.Y), topL)};
        }

        public override bool Equals(object obj)
        {
            var toCompareWith = obj as Octagon;
            if (toCompareWith == null)
                return false;
            return corners.SequenceEqual(toCompareWith.corners);
        }

        private Vector2 changePosition(Vector2 value)
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
            setMaxMinValues();
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
            maxX = midTopR.X;
            minX = midTopL.X;
            maxY = botR.Y;
            minY = topR.Y;
        }
    }
}
