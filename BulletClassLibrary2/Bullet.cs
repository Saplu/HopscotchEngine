using System;

namespace BulletClassLibrary
{
    public class Bullet
    {
        Point position;
        GravityClassLibrary.Gravity gravity;
        Velocity velocity;
        bool active;

        public Bullet(int X, int Y, double vX, double vY)
        {
            this.active = true;
            gravity = new GravityClassLibrary.Gravity(0.1);
            position = new Point(X, Y);
            velocity = new Velocity(vX, vY);
        }

        public void Update(int milliseconds)
        {
            velocity.Update(gravity, milliseconds);
        }
    }
}
