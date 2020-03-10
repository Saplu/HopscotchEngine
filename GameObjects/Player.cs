using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using Geometry;
using Physics;
using SFML.Window;

namespace GameObjects
{
    public class Player
    {
        OctagonHitbox _hitbox;
        int _maxSpeed, _jumpSpeed;
        Gravity _gravity;
        Vector2 _position, _currentSpeed;
        bool _falling;

        public Vector2 Position { get => _position; set => _position = value; }
        public Player()
        {
            _position = new Vector2(50, 350);
            _hitbox = new OctagonHitbox(32, 32, _position);
            _maxSpeed = 100;
            _jumpSpeed = -300;
            _gravity = new Gravity(0.5);
            _currentSpeed = new Vector2(00, 0);
            _falling = true;
        }

        public void Update(int milliseconds, List<IHitbox> hitboxes)
        {
            GetMovementKeys();
            _currentSpeed.Y = _gravity.Update(_currentSpeed.Y, _falling, milliseconds);
            var current = _position;
            _position.Update(_currentSpeed.X * milliseconds / 1000,
                _currentSpeed.Y * milliseconds / 1000);
            CheckBorders();
            _hitbox.UpdatePosition(_position);

            _falling = true;
            foreach(var item in hitboxes)
            {
                if (_hitbox.Hit(item as IPolygonHitbox))
                {
                    var collisionResult = _hitbox.HandleCollision(item, _currentSpeed, milliseconds, current);
                    this.Position = _hitbox.Position;
                    _currentSpeed = collisionResult.Item1;
                    if (collisionResult.Item2 == 4 || collisionResult.Item2 == 5)
                        _falling = false;
                }
            }
        }

        private void GetMovementKeys()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                _currentSpeed.X = -_maxSpeed;
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                _currentSpeed.X = _maxSpeed;
            else _currentSpeed.X = 0;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && _falling == false)
            {
                _currentSpeed.Y = _jumpSpeed;
                _falling = true;
            }
        }

        private void CheckBorders()
        {
            if (_position.X < -2)
                _position.X = 802;
            if (_position.X > 802)
                _position.X = -2;
        }
    }
}
