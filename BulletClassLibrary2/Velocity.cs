using System;
using System.Collections.Generic;
using System.Text;

namespace BulletClassLibrary
{
    public class Velocity : IVelocity
    {
        double x, y, speed;
        
        public Velocity(double X, double Y)
        {
            x = X;
            y = Y;
            calculateSpeed();
        }

        public void Update(GravityClassLibrary.Gravity gravity, int milliseconds)
        {
            y = gravity.Update(speed, true, milliseconds);
        }

        private void calculateSpeed()
        {
            var first = x * x;
            var second = y * y;
            speed = Math.Sqrt(first + second);
        }
    }
}
