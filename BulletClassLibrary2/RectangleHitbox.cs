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

        public Rectangle Box { get => box; }

        public RectangleHitbox(int height, int width, Point position, int angle)
        {
            box = new Rectangle(width, height, position, angle);
        }

        public bool Hit(Point point)
        {
            return isInside(point);
        }

        public bool Hit(Hitbox hitbox)
        {
            if (!broadCheck(hitbox.Box))
                return false;
            if (CheckHitbox(hitbox.Box))
                return true;
            else return hitbox.CheckHitbox(this.box);
        }

        public bool Hit(RectangleHitbox hitbox)
        {
            if (!broadCheck(hitbox.Box))
                return false;
            if (CheckHitbox(hitbox.box))
                return true;
            return hitbox.CheckHitbox(this.box);
        }

        public bool CheckHitbox(IShape hitbox)
        {
            foreach (var point in hitbox.Corners)
            {
                if (isInside(point))
                    return true;
            }
            return false;
        }

        private bool isInside(Point point)
        {
            if (box.Angle != 0)
            {
                if (broadCheck(point))
                {
                    var triangles = new List<Triangle>() { new Triangle(box.Corners[0], box.Corners[1], box.Corners[2]),
                    new Triangle(box.Corners[2], box.Corners[3], box.Corners[0])};
                    if (triangles[0].Contains(point) || triangles[1].Contains(point))
                        return true;
                    return false;
                }
            }
            return broadCheck(point);
        }

        private Point[][] getsides(RectangleHitbox hitbox)
        {
            var sides = new Point[4][]
            {
                new Point[]{hitbox.box.Corners[0], hitbox.box.Corners[1]},
                new Point[]{hitbox.box.Corners[2], hitbox.box.Corners[3]},
                new Point[]{hitbox.box.Corners[1], hitbox.box.Corners[3]},
                new Point[]{hitbox.box.Corners[0], hitbox.box.Corners[2]}
            };
            return sides;
        }

        private bool checkY(Point[][] sides)
        {
            for (int i = 2; i < 3; i++)
            {
                if (sides[i][0].Y <= box.Position.Y && sides[i][1].Y >= box.Position.Y ||
                    sides[i][0].Y <= box.Position.Y + box.Height && sides[i][1].Y >= box.Position.Y + box.Height ||
                    sides[i][0].Y >= box.Position.Y && sides[i][1].Y <= box.Position.Y + box.Height)
                    return true;
            }
            return false;
        }

        private List<int> getBorderValues(Rectangle box)
        {
            List<int> xValues = getCornerValues(box.Corners, true);
            List<int> yValues = getCornerValues(box.Corners, false);
            var list = new List<int>();
            list.Add(xValues.Max());
            list.Add(yValues.Max());
            list.Add(xValues.Min());
            list.Add(yValues.Min());
            return list;
        }

        private List<int> getCornerValues(List<Point> corners, bool isX)
        {
            var values = new List<int>();
            if (isX)
                foreach (var item in corners)
                    values.Add(item.X);
            else foreach (var item in corners)
                    values.Add(item.Y);
            return values;
        }

        private bool broadCheck(Point point)
        {
            if (point.X >= box.MinX && point.X <= box.MaxX &&
                point.Y >= box.MinY && point.Y <= (box.MaxY))
                return true;
            return false;
        }

        private bool broadCheck(IShape shape)
        {
            if (shape.MinX > this.box.MaxX || shape.MaxX < this.box.MinX ||
                shape.MaxY < this.box.MinY || shape.MinY > this.box.MaxY)
                return false;
            else return true;
        }
    }
}
