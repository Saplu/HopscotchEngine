using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometry
{
    public class Rectangle : IPolygon
    {
        int _width, _height, _angle;
        double _maxX, _maxY, _minX, _minY;
        Vector2 _position;
        List<Vector2> _corners;

        public int Width { get => _width; set => SetWidth(value); }
        public int Height { get => _height; set => SetHeight(value); }
        public Vector2 Position { get => _position; set => _position = ChangePosition(value); }
        public List<Vector2> Corners { get => _corners; }
        public int Angle { get => _angle; set => _angle = SetAngle(value); }
        public double MaxX { get => _maxX; }
        public double MaxY { get => _maxY; }
        public double MinX { get => _minX; }
        public double MinY { get => _minY; }

        public Rectangle(int width, int height, Vector2 position)
        {
            this._width = width;
            this._height = height;
            this._position = position;
            _angle = 0;
            _corners = CalculateCorners(_angle);
            SetMaxMinValues();
        }

        public Rectangle(int width, int height, Vector2 position, int angle)
        {
            this._width = width;
            this._height = height;
            this._position = position;
            this._angle = angle;
            _corners = CalculateCorners(angle);
            SetMaxMinValues();
        }

        public override bool Equals(object obj)
        {
            var toCompareWith = obj as Rectangle;
            if (toCompareWith == null)
                return false;
            return _corners.SequenceEqual(toCompareWith._corners);
        }

        private Vector2 ChangePosition(Vector2 value)
        {
            value = CheckValue(value);
            _corners = CalculateCorners(_angle);
            SetMaxMinValues();
            return value;
        }

        private void SetWidth(int value)
        {
            _width = value;
            _corners = CalculateCorners(_angle);
            SetMaxMinValues();            
        }

        private void SetHeight(int value)
        {
            _height = value;
            _corners = CalculateCorners(_angle);
            SetMaxMinValues();
        }

        private int SetAngle(int value)
        {
            if (value != _angle)
            {
                _corners = CalculateCorners(value);
            }
            return value;
        }

        private List<Vector2> CalculateCorners(int angle)
        {
            if (angle == 0)
                _corners = new List<Vector2>() { new Vector2(_position.X, _position.Y),
                    new Vector2(_position.X + _width, _position.Y), new Vector2(_position.X + _width, _position.Y + _height),
                    new Vector2(_position.X, _position.Y + _height)};
            else
            {
                _corners = new List<Vector2>();
                for (int i = 0; i < 4; i++)
                {
                    double tempX = 0;
                    double tempY = 0;
                    if (i == 0 || i == 3)
                        tempX = (_position.X) - _position.X;
                    else tempX = (_position.X + _width) -_position.X;
                    if (i == 0 || i == 1)
                        tempY = (_position.Y) - _position.Y;
                    else tempY = (_position.Y + _width) - _position.Y;
                   
                    double rotatedX = (tempX * Math.Cos(angle * Math.PI/180)) - (tempY * Math.Sin(angle * Math.PI/180));
                    double rotatedY = (tempX * Math.Sin(angle * Math.PI/180)) + (tempY * Math.Cos(angle * Math.PI/180));

                    _corners.Add(new Vector2(Convert.ToInt32(rotatedX + _position.X), Convert.ToInt32(rotatedY + _position.Y)));
                }
            }
            return _corners;
        }

        private Vector2 CheckValue(Vector2 value)
        {
            if (value.X < 0)
                value.X = 0;
            if (value.Y < 0)
                value.Y = 0;
            return value;
        }

        private void SetMaxMinValues()
        {
            var values = GetBorderValues();
            _maxX = values[0];
            _maxY = values[1];
            _minX = values[2];
            _minY = values[3];
        }


        private List<int> GetBorderValues()
        {
            List<int> xValues = GetCornerValues(true);
            List<int> yValues = GetCornerValues(false);
            var list = new List<int>();
            list.Add(xValues.Max());
            list.Add(yValues.Max());
            list.Add(xValues.Min());
            list.Add(yValues.Min());
            return list;
        }

        private List<int> GetCornerValues(bool isX)
        {
            var values = new List<int>();
            if (isX)
                foreach (var item in _corners)
                    values.Add(Convert.ToInt32(item.X));
            else foreach (var item in _corners)
                    values.Add(Convert.ToInt32(item.Y));
            return values;
        }

        public override int GetHashCode()
        {
            var hashCode = -649387116;
            hashCode = hashCode * -1521134295 + _width.GetHashCode();
            hashCode = hashCode * -1521134295 + _height.GetHashCode();
            hashCode = hashCode * -1521134295 + _angle.GetHashCode();
            hashCode = hashCode * -1521134295 + _maxX.GetHashCode();
            hashCode = hashCode * -1521134295 + _maxY.GetHashCode();
            hashCode = hashCode * -1521134295 + _minX.GetHashCode();
            hashCode = hashCode * -1521134295 + _minY.GetHashCode();
            return hashCode;
        }
    }
}
