using Geometry;
using System;


namespace BulletClassLibrary
{
    public class Bullet : ISolidObject
    {
        Vector2 position, speed;
        GravityClassLibrary.Gravity gravity;
        bool active;
        double trueSpeed;

        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Speed { get => speed; set => speed = value; }

        public Bullet(int X, int Y, double vX, double vY)
        {
            this.active = true;
            gravity = new GravityClassLibrary.Gravity(0.1);
            position = new Vector2(X, Y);
            speed = new Vector2(vX, vY);
            calculateSpeed();
        }

        public void Update(int milliseconds)
        {
            gravity.Update(speed.Y, active, milliseconds);
            position.Update(speed.X, speed.Y);
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

        private void calculateSpeed()
        {
            var first = speed.X * speed.X;
            var second = speed.Y * speed.Y;
            trueSpeed = Math.Sqrt(first + second);
        }
    }
}
