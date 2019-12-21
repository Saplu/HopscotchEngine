using System;
using System.Collections.Generic;
using System.Text;
using Geometry;
using Physics;

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
            _position = new Vector2(0, 0);
            _hitbox = new OctagonHitbox(50, 50, _position);
            _maxSpeed = 100;
            _jumpSpeed = 300;
            _gravity = new Gravity(0.5);
            _currentSpeed = new Vector2(60, -80);
            _falling = true;
        }

        public void Update(int milliseconds)
        {
            _currentSpeed.Y = _gravity.Update(_currentSpeed.Y, _falling, milliseconds);
            
            _position.Update(_currentSpeed.X * milliseconds / 1000,
                _currentSpeed.Y * milliseconds / 1000);
            //Nappulat jotka vaikuttavat liikkeeseen
            //Uusi nopeus
            //Uusi sijainti
            //Collision detection
            //Jälkimainingit
        }
    }
}
