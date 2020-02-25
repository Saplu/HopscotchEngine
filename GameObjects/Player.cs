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
            _position = new Vector2(50, 100);
            _hitbox = new OctagonHitbox(32, 32, _position);
            _maxSpeed = 100;
            _jumpSpeed = -300;
            _gravity = new Gravity(0.5);
            _currentSpeed = new Vector2(60, -140);
            _falling = true;
        }

        public void Update(int milliseconds, List<IHitbox> hitboxes)
        {
            GetMovementKeys();
            _currentSpeed.Y = _gravity.Update(_currentSpeed.Y, _falling, milliseconds);
            
            _position.Update(_currentSpeed.X * milliseconds / 1000,
                _currentSpeed.Y * milliseconds / 1000);
            _hitbox.UpdatePosition(_position);
            //Nappulat jotka vaikuttavat liikkeeseen
            //Uusi nopeus
            //Uusi sijainti

            foreach(var item in hitboxes)
            {
                if (_hitbox.Hit(item as IPolygonHitbox))
                {
                    _falling = false;
                    _currentSpeed = new Vector2(0, 0);
                }

            }
            //Collision detection
            //Jälkimainingit
        }

        private void GetMovementKeys()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                _currentSpeed.X = -_maxSpeed;
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                _currentSpeed.X = _maxSpeed;
        }
    }
}
