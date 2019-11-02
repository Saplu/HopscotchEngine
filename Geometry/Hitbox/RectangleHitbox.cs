using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometry
{
    public class RectangleHitbox : IHitbox
    {
        Rectangle box;

        public Rectangle Box { get => box; }

        public RectangleHitbox(int height, int width, Vector2 position, int angle)
        {
            box = new Rectangle(width, height, position, angle);
        }

        public bool Hit(Vector2 point)
        {
            return isInside(point);
        }

        public bool Hit(Hitbox hitbox)
        {
            if (!broadCheck((IShape)hitbox.Box))
                return false;
            if (CheckHitbox((IShape)hitbox.Box))
                return true;
            else return hitbox.CheckHitbox((IShape)this.box);
        }

        public bool Hit(RectangleHitbox hitbox)
        {
            if (!broadCheck((IShape)hitbox.Box))
                return false;
            if (CheckHitbox((IShape)hitbox.box))
                return true;
            return hitbox.CheckHitbox((IShape)this.box);
        }

        public bool CheckHitbox(IShape hitbox)
        {
            //foreach (var point in hitbox.Corners)
            //{
            //    if (isInside(point))
            //        return true;
            //}
            return false;
        }

        private bool isInside(Vector2 point)
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

        private Vector2[][] getsides(RectangleHitbox hitbox)
        {
            var sides = new Vector2[4][]
            {
                new Vector2[]{hitbox.box.Corners[0], hitbox.box.Corners[1]},
                new Vector2[]{hitbox.box.Corners[2], hitbox.box.Corners[3]},
                new Vector2[]{hitbox.box.Corners[1], hitbox.box.Corners[3]},
                new Vector2[]{hitbox.box.Corners[0], hitbox.box.Corners[2]}
            };
            return sides;
        }

        private bool checkY(Vector2[][] sides)
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

        private List<int> getCornerValues(List<Vector2> corners, bool isX)
        {
            var values = new List<int>();
            if (isX)
                foreach (var item in corners)
                    values.Add(Convert.ToInt32(item.X));
            else foreach (var item in corners)
                    values.Add(Convert.ToInt32(item.Y));
            return values;
        }

        private bool broadCheck(Vector2 point)
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
