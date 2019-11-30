using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometry
{
    public class RectangleHitbox : IPolygonHitbox
    {
        Rectangle _box;

        public IPolygon Box { get => _box; }

        public RectangleHitbox(int height, int width, Vector2 position, int angle)
        {
            _box = new Rectangle(width, height, position, angle);
        }

        public bool Hit(Vector2 point)
        {
            return IsInside(point);
        }
        public bool Hit(IPolygonHitbox box)
        {
            if (!BroadCheck(box.Box))
                return false;
            if (CheckHitbox(box.Box))
                return true;
            else return box.CheckHitbox(this._box);
        }

        public bool Hit(CircleHitbox hitbox)
        {
            if (!BroadCheck(hitbox.Box))
                return false;
            if (CheckHitbox(hitbox.Box))
                return true;
            else return hitbox.CheckHitbox(this._box);
        }

        public bool CheckHitbox(IPolygon hitbox)
        {
            foreach (var point in hitbox.Corners)
            {
                if (IsInside(point))
                    return true;
            }
            return false;
        }

        public bool CheckHitbox(ICircle circle)
        {
            var checkpoint = circle.FindClosestPoint(_box.Position);
            return Hit(checkpoint);
        }

        private bool IsInside(Vector2 point)
        {
            if (_box.Angle != 0)
            {
                if (BroadCheck(point))
                {
                    var triangles = new List<Triangle>() { new Triangle(_box.Corners[0], _box.Corners[1], _box.Corners[2]),
                    new Triangle(_box.Corners[2], _box.Corners[3], _box.Corners[0])};
                    if (triangles[0].Contains(point) || triangles[1].Contains(point))
                        return true;
                    return false;
                }
            }
            return BroadCheck(point);
        }

        //private Vector2[][] Getsides(RectangleHitbox hitbox)
        //{
        //    var sides = new Vector2[4][]
        //    {
        //        new Vector2[]{hitbox._box.Corners[0], hitbox._box.Corners[1]},
        //        new Vector2[]{hitbox._box.Corners[2], hitbox._box.Corners[3]},
        //        new Vector2[]{hitbox._box.Corners[1], hitbox._box.Corners[3]},
        //        new Vector2[]{hitbox._box.Corners[0], hitbox._box.Corners[2]}
        //    };
        //    return sides;
        //}

        //private bool CheckY(Vector2[][] sides)
        //{
        //    for (int i = 2; i < 3; i++)
        //    {
        //        if (sides[i][0].Y <= _box.Position.Y && sides[i][1].Y >= _box.Position.Y ||
        //            sides[i][0].Y <= _box.Position.Y + _box.Height && sides[i][1].Y >= _box.Position.Y + _box.Height ||
        //            sides[i][0].Y >= _box.Position.Y && sides[i][1].Y <= _box.Position.Y + _box.Height)
        //            return true;
        //    }
        //    return false;
        //}

        //private List<int> GetBorderValues(Rectangle box)
        //{
        //    List<int> xValues = GetCornerValues(box.Corners, true);
        //    List<int> yValues = GetCornerValues(box.Corners, false);
        //    var list = new List<int>();
        //    list.Add(xValues.Max());
        //    list.Add(yValues.Max());
        //    list.Add(xValues.Min());
        //    list.Add(yValues.Min());
        //    return list;
        //}

        //private List<int> GetCornerValues(List<Vector2> corners, bool isX)
        //{
        //    var values = new List<int>();
        //    if (isX)
        //        foreach (var item in corners)
        //            values.Add(Convert.ToInt32(item.X));
        //    else foreach (var item in corners)
        //            values.Add(Convert.ToInt32(item.Y));
        //    return values;
        //}

        private bool BroadCheck(Vector2 point)
        {
            if (point.X >= _box.MinX && point.X <= _box.MaxX &&
                point.Y >= _box.MinY && point.Y <= (_box.MaxY))
                return true;
            return false;
        }

        private bool BroadCheck(IShape shape)
        {
            if (shape.MinX > this._box.MaxX || shape.MaxX < this._box.MinX ||
                shape.MaxY < this._box.MinY || shape.MinY > this._box.MaxY)
                return false;
            else return true;
        }

        public override bool Equals(object obj)
        {
            var toCompareWith = obj as RectangleHitbox;
            if (toCompareWith == null)
                return false;
            if (toCompareWith.Box.Equals(this.Box))
                return true;
            else return false;
        }

        public override int GetHashCode()
        {
            var hashCode = 623778965;
            hashCode = hashCode * -1521134295 + EqualityComparer<Rectangle>.Default.GetHashCode(_box);
            hashCode = hashCode * -1521134295 + EqualityComparer<IPolygon>.Default.GetHashCode(Box);
            return hashCode;
        }
    }
}
