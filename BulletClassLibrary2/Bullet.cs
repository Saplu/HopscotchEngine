using System;

namespace BulletClassLibrary
{
    public class Bullet
    {
        Vector2 position, speed;
        GravityClassLibrary.Gravity gravity;
        bool active;

        public Bullet(int X, int Y, double vX, double vY)
        {
            this.active = true;
            gravity = new GravityClassLibrary.Gravity(0.1);
            position = new Vector2(X, Y);
            speed = new Vector2(vX, vY);
        }

        public void Update(int milliseconds)
        {
            gravity.Update(speed.Y, active, milliseconds);
            position.Update(speed.X, speed.Y);
            //Sitten collision checkiä, activen mahdollinen muutos osumasta.
        }

        private void calculateSpeed()
        {
            var first = speed.X * speed.X;
            var second = speed.Y * speed.Y;
            var tangent = Math.Sqrt(first + second);
        }
    }
}
