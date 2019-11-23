using Geometry.Hitbox;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry.Tiles
{
    public class Tile
    {
        int _width, _height, _id, _left, _right, _leftSide, _rightSide;
        List<Vector2> _corners;
        List<TriangleHitbox> _hitbox;
        Vector2 _position, _leftVector, _rightVector;

        public List<TriangleHitbox> Hitbox { get => _hitbox; set => _hitbox = value; }

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
        }

        private int CheckValue(int value)
        {
            if (value < 0 || value >= _width * 2 + _height * 2)
                throw new ArgumentOutOfRangeException("Value must be between 0 and 127.");
            return value;
        }

        private void CalculatePosition()
        {
            _position = new Vector2(0, 0);
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
            _hitbox = new List<TriangleHitbox>();
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
            else return new Vector2(_position.X, _position.Y + (position - _width * 2 - _height));
        }
    }
}
