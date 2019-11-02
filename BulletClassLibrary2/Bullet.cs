using Geometry;
using System;
using Physics;


namespace BulletClassLibrary
{
    public class Bullet : ISolidObject
    {
        Vector2 _position, _speed;
        Gravity _gravity;
        bool _active;
        double _trueSpeed;

        public Vector2 Position { get => _position; set => _position = value; }
        public Vector2 Speed { get => _speed; set => _speed = value; }

        public Bullet(int X, int Y, double vX, double vY)
        {
            this._active = true;
            _gravity = new Gravity(0.1);
            _position = new Vector2(X, Y);
            _speed = new Vector2(vX, vY);
            CalculateSpeed();
        }

        public void Update(int milliseconds)
        {
            _gravity.Update(_speed.Y, _active, milliseconds);
            _position.Update(_speed.X, _speed.Y);
            //Sitten collision checkiä, activen mahdollinen muutos osumasta.
        }

        public bool Hit(ISolidObject solid)
        {
            return false;
        }

        public bool Hit(IImmaterialObject immaterial)
        {
            return false;
        }

        private void CalculateSpeed()
        {
            var first = _speed.X * _speed.X;
            var second = _speed.Y * _speed.Y;
            _trueSpeed = Math.Sqrt(first + second);
        }
    }
}
