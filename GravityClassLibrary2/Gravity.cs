using System;

namespace GravityClassLibrary
{
    //Property of any object affected by gravity
    //force is expected to be default everywhere

    public class Gravity : IGravity
    {
        int force, maxSpeed, acceleration;
        double counterforce;

        public Gravity(double counterforce)
        {
            this.counterforce = forceValid(counterforce);
            force = 100;
            maxSpeed = calculateMaxSpeed(this.counterforce);
            acceleration = calculateAcceleration(this.counterforce);
        }

        public double Update(double currentSpeed, bool falling, int milliseconds) //Returns new falling speed, also if still going up
        {
            if (falling == false)
                return currentSpeed;
            else
            {
                if (milliseconds < 0)
                    throw new ArgumentOutOfRangeException("Time cannot run backwards here.");
                currentSpeed += acceleration * (double)(milliseconds / 1000);
                if (currentSpeed > maxSpeed)
                    currentSpeed = maxSpeed;
                return currentSpeed;
            }
        }

        public void UpdateCounterforce(double counterforce) //Only use if characters counterforce changes(e.g. parachute on/off)
        {
            this.counterforce = forceValid(counterforce);
            acceleration = calculateAcceleration(this.counterforce);
        }

        private int calculateMaxSpeed(double counterforce)
        {
            if (counterforce < 0.01)
                return int.MaxValue;
            else if (counterforce > 0.99)
                return 0;
            else return Convert.ToInt32(force / counterforce);
        }

        private int calculateAcceleration(double counterforce)
        {
            double multiplier = 1 - counterforce;
            return Convert.ToInt32(force * multiplier);
        }

        private double forceValid(double counterforce)
        {
            if (counterforce < 0 || counterforce > 1)
                throw new ArgumentOutOfRangeException("Counterforce must be between 0 and 1.");
            else return counterforce;
        }
    }
}
