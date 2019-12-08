using System;
using System.Collections.Generic;
using System.Text;
using Geometry;
using Physics;

namespace GameObjects
{
    public class Player
    {
        //Texture
        OctagonHitbox _hitbox;
        int _maxSpeed, _jumpSpeed;
        Gravity _gravity;
        Vector2 _position, _currentSpeed;
        bool _falling;

        public Player()
        {
            _position = new Vector2(0, 0);
            _hitbox = new OctagonHitbox(50, 50, _position);
            _maxSpeed = 100;
            _jumpSpeed = 300;
            _gravity = new Gravity(0.5);
            _currentSpeed = new Vector2(0, 0);
            _falling = false;
        }

        public void Update(int milliseconds)
        {
            //Nappulat jotka vaikuttavat liikkeeseen
            //Uusi nopeus
            //Uusi sijainti
            //Collision detection
            //Jälkimainingit
        }
    }
}
