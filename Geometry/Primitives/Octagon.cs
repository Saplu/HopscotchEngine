using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometry
{
    public class Octagon : IPolygon
    {
        int _height, _width;
        double _maxX, _minX, _maxY, _minY;
        Vector2 _topL, _topR, _midTopR, _midBotR, _midTopL, _midBotL, _botL, _botR, _position;
        List<Vector2> _corners;
        List<Triangle> _virtualCorners;

        public int Height { get => _height; set => _height = SetHeight(value); }
        public int Width { get => _width; set => _width = SetWidth(value); }
        public Vector2 Position { get => _position; set => ChangePosition(value); }
        public List<Vector2> Corners { get => _corners; }
        public List<Triangle> VirtualCorners { get => _virtualCorners; }
        public double MaxX { get => _maxX; }
        public double MinX { get => _minX; }
        public double MaxY { get => _maxY; }
        public double MinY { get => _minY; }

        public Octagon(int height, int width, Vector2 position)
        {
            this._position = position;
            _height = height;
            _width = width;
            CalculateCorners();
            SetMaxMinValues();
            CalculateVirtualCorners();
        }

        public override bool Equals(object obj)
        {
            var toCompareWith = obj as Octagon;
            if (toCompareWith == null)
                return false;
            return _corners.SequenceEqual(toCompareWith._corners);
        }

        private void ChangePosition(Vector2 value)
        {
            //value = CheckValue(value);
            //var moveX = value.X - _position.X;
            //var moveY = value.Y - _position.Y;
            //foreach(var point in _corners)
            //{
            //    point.X += moveX;
            //    point.Y += moveY;
            //}
            //foreach(var triangle in _virtualCorners)
            //{
            //    triangle.Corners[1].X += moveX;
            //    triangle.Corners[1].Y += moveY;
            //}
            CalculateCorners();
            SetMaxMinValues();
            CalculateVirtualCorners();
            _position = value;
        }

        private int SetHeight(int value)
        {
            _corners[0].Y = _position.Y - Convert.ToInt32(value / 2);
            _corners[1].Y = _position.Y - Convert.ToInt32(value / 2);
            _corners[2].Y = _position.Y - Convert.ToInt32(value / 4);
            _corners[3].Y = _position.Y + Convert.ToInt32(value / 4);
            _corners[4].Y = _position.Y + Convert.ToInt32(value / 2);
            _corners[5].Y = _position.Y + Convert.ToInt32(value / 2);
            _corners[6].Y = _position.Y + Convert.ToInt32(value / 4);
            _corners[7].Y = _position.Y - Convert.ToInt32(value / 4);
            return value;
        }

        private int SetWidth(int value)
        {
            _corners[0].X = _position.X - Convert.ToInt32(value / 4);
            _corners[1].X = _position.X + Convert.ToInt32(value / 4);
            _corners[2].X = _position.X + Convert.ToInt32(value / 2);
            _corners[3].X = _position.X + Convert.ToInt32(value / 2);
            _corners[4].X = _position.X + Convert.ToInt32(value / 4);
            _corners[5].X = _position.X - Convert.ToInt32(value / 4);
            _corners[6].X = _position.X - Convert.ToInt32(value / 2);
            _corners[7].X = _position.X - Convert.ToInt32(value / 2);
            return value;
        }

        private Vector2 CheckValue(Vector2 value)
        {
            if (value.X < _width / 2)
                value.X = Convert.ToInt32(_width / 2);
            if (value.Y < _height / 2)
                value.Y = Convert.ToInt32(_height / 2);
            return value;
        }

        private void SetMaxMinValues()
        {
            _maxX = _midTopR.X;
            _minX = _midTopL.X;
            _maxY = _botR.Y;
            _minY = _topR.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 740219888;
            hashCode = hashCode * -1521134295 + _height.GetHashCode();
            hashCode = hashCode * -1521134295 + _width.GetHashCode();
            hashCode = hashCode * -1521134295 + _maxX.GetHashCode();
            hashCode = hashCode * -1521134295 + _minX.GetHashCode();
            hashCode = hashCode * -1521134295 + _maxY.GetHashCode();
            hashCode = hashCode * -1521134295 + _minY.GetHashCode();

            return hashCode;
        }

        private void CalculateCorners()
        {
            _topL = new Vector2(_position.X - Convert.ToInt32(_width / 4), _position.Y - Convert.ToInt32(_height / 2));
            _topR = new Vector2(_position.X + Convert.ToInt32(_width / 4), _position.Y - Convert.ToInt32(_height / 2));
            _midTopR = new Vector2(_position.X + Convert.ToInt32(_width / 2), _position.Y - Convert.ToInt32(_height / 4));
            _midBotR = new Vector2(_position.X + Convert.ToInt32(_width / 2), _position.Y + Convert.ToInt32(_height / 4));
            _midTopL = new Vector2(_position.X - Convert.ToInt32(_width / 2), _position.Y - Convert.ToInt32(_height / 4));
            _midBotL = new Vector2(_position.X - Convert.ToInt32(_width / 2), _position.Y + Convert.ToInt32(_height / 4));
            _botL = new Vector2(_position.X - Convert.ToInt32(_width / 4), _position.Y + Convert.ToInt32(_height / 2));
            _botR = new Vector2(_position.X + Convert.ToInt32(_width / 4), _position.Y + Convert.ToInt32(_height / 2));
            _corners = new List<Vector2>() { _topL, _topR, _midTopR, _midBotR, _botR, _botL, _midBotL, _midTopL };
        }

        private void CalculateVirtualCorners()
        {
            _virtualCorners = new List<Triangle>() { new Triangle(_topR, new Vector2(_midTopR.X, _topR.Y), _midTopR),
            new Triangle(_midBotR, new Vector2(_midBotR.X, _botR.Y), _botR),
            new Triangle(_botL, new Vector2(_midBotL.X, _botL.Y), _midBotL),
            new Triangle(_midTopL, new Vector2(_midTopL.X, _topL.Y), _topL)};
        }
    }
}
