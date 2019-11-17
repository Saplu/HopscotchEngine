using Geometry.Hitbox;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry.Tiles
{
    public class Tile
    {
        int _width, _height, _id, _left, _right;
        List<Vector2> _corners;
        List<TriangleHitbox> _hitbox;
        Vector2 _position;

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
            CalculateHitboxes();
        }

        private int CheckValue(int value)
        {
            if (value < 0 || value > 127)
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
            if (_left < 33 && _right < 33 || _left > 32 && _left < 65 && _right > 32 && _right < 65 ||
                _left > 64 && _left < 97 && _right > 64 && _right < 97 || _left > 96 && _right > 96)
                throw new Exception("Both endings cannot be on the same side.");
        }

        private void CalculateHitboxes()
        {
            var leftSide = GetSide(_left);
            var rightSide = GetSide(_right);
            var corners = GetCornersBetween(leftSide, rightSide);

        }

        public List<Vector2> GetCornersBetween(int leftSide, int rightSide)
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
            if (point < 33) return 0;
            else if (point < 65) return 1;
            else if (point < 97) return 2;
            else return 3;
        }
    }
}
