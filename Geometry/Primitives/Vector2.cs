using System;

namespace Geometry
{
    public class Vector2
    {
        double _x, _y;

        public double X { get => Convert.ToInt32(_x); set => _x = value; }
        public double Y { get => Convert.ToInt32(_y); set => _y = value; }

        public Vector2(double X, double Y)
        {
            _x = X;
            _y = Y;
        }

        public override bool Equals(object obj)
        {
            var toCompareWith = obj as Vector2;
            if (toCompareWith == null)
                return false;
            return this._x == toCompareWith._x && this._y == toCompareWith._y;
        }

        public void Update(double X, double Y)
        {
            _x += X;
            _y += Y;
        }

        public override int GetHashCode()
        {
            var hashCode = -624234986;
            hashCode = hashCode * -1521134295 + _x.GetHashCode();
            hashCode = hashCode * -1521134295 + _y.GetHashCode();

            return hashCode;
        }
    }
}
