using Geometry.Hitbox;
using System;
using System.Collections.Generic;
using System.Text;
using Geometry;

namespace GameObjects
{
    public class Tile
    {
        int _width, _height, _id, _left, _right, _leftSide, _rightSide;
        List<Vector2> _corners;
        List<IPolygonHitbox> _hitbox;
        Vector2 _position, _leftVector, _rightVector;
        double _angle;

        public List<IPolygonHitbox> Hitbox { get => _hitbox; }
        public Vector2 Position { get => _position; set => _position = value; }
        public double Angle { get => _angle; set => _angle = value; }
        public int Id { get => _id; set => _id = value; }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }

        public Tile(int left, int right, int id)
        {
            _width = 32;
            _height = 32;
            _id = id;
            _left = CheckValue(left);
            _right = CheckValue(right);
            CalculatePosition();
            CalculateCorners();
            CheckSameSide();
            _leftVector = CalculateSideVector(_left);
            _rightVector = CalculateSideVector(_right);
            CalculateHitboxes();
            CalculateAngle();
        }

        public Tile(int premade, int id)
        {
            _width = 32;
            _height = 32;
            _id = id;
            CalculatePosition();
            CalculateCorners();
            _hitbox = new List<IPolygonHitbox>();
            switch(premade)
            {
                case 1: FullTile(); break;
                case 2: UpHill(); break;
                case 3: DownHill(); break;
                default: throw new ArgumentOutOfRangeException("Try better.");
            }
        }

        private int CheckValue(int value)
        {
            var max = _width * 2 + _height * 2;
            if (value < 0 || value >= max)
                throw new ArgumentOutOfRangeException(String.Format("Value must be between 0 and {0}.", max));
            return value;
        }

        private void CalculatePosition()
        {
            var row = _id / 25;
            var column = _id % 25;
            var x = column * _width;
            var y = row * _height;
            _position = new Vector2(x, y);
        }

        private void CalculateCorners()
        {
            _corners = new List<Vector2>()
            {
                _position,
                new Vector2(_position.X + _width, _position.Y),
                new Vector2(_position.X + _width, _position.Y + _height),
                new Vector2(_position.X, _position.Y + _height)
            };
        }

        private void CheckSameSide()
        {
            _leftSide = GetSide(_left);
            _rightSide = GetSide(_right);
            if (_leftSide == _rightSide)
                throw new Exception("Both endings cannot be on the same side.");
        }

        private void CalculateHitboxes()
        {
            _hitbox = new List<IPolygonHitbox>();
            var corners = new List<Vector2>() { _rightVector, _leftVector };
            corners.AddRange(GetCornersBetween(_leftSide, _rightSide));
            for (int i = 2; i < corners.Count; i++)
            {
                var box = new TriangleHitbox(_rightVector, corners[i - 1], corners[i]);
                _hitbox.Add(box);
            }
        }

        private List<Vector2> GetCornersBetween(int leftSide, int rightSide)
        {
            var list = new List<Vector2>();
            var i = leftSide;
            while(true)
            {
                list.Add(_corners[i]);
                i--;
                if (i < 0) i = 3;
                if (i == rightSide)
                    break;
            }
            return list;
        }

        private int GetSide(int point)
        {
            if (point < _width) return 0;
            else if (point < _width + _height) return 1;
            else if (point < _width * 2 + _height) return 2;
            else return 3;
        }
        private Vector2 CalculateSideVector(int position)
        {
            if (position <= _width)
                return new Vector2(_position.X + position, _position.Y);
            if (position <= _width + _height)
                return new Vector2(_position.X + _width, _position.Y + position - _width);
            if (position <= _width * 2 + _height)
                return new Vector2(_position.X + _width - (position - _width - _height), _position.Y + _height);
            else return new Vector2(_position.X, _position.Y + (_width * 2 + _height * 2 - position));
        }

        private void CalculateAngle()
        {
            var yDiff = _leftVector.Y - _rightVector.Y;
            var xDiff = _rightVector.X - _leftVector.X;
            var rad = Math.Atan2(yDiff, xDiff);
            _angle = rad * (180 / Math.PI);
        }

        private void FullTile()
        {
            _hitbox.Add(new RectangleHitbox(_height, _width, _position, 0));
            _angle = 0;
        }

        private void UpHill()
        {
            _hitbox.Add(new TriangleHitbox(_corners[3], _corners[1], _corners[2]));
            _angle = 135;
        }

        private void DownHill()
        {
            _hitbox.Add(new TriangleHitbox(_corners[0], _corners[2], _corners[3]));
            _angle = 45;
        }
    }
}
