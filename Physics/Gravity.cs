using System;

namespace Physics
{
    //Property of any object affected by gravity
    //force is expected to be default everywhere

    public class Gravity : IGravity
    {
        int _force, _maxSpeed, _acceleration;
        double _counterforce;

        public Gravity(double counterforce)
        {
            this._counterforce = ForceValid(counterforce);
            _force = 100;
            _maxSpeed = CalculateMaxSpeed(this._counterforce);
            _acceleration = CalculateAcceleration(this._counterforce);
        }

        public double Update(double currentSpeed, bool falling, int milliseconds) //Returns new falling speed, also if still going up
        {
            if (falling == false)
                return currentSpeed;
            else
            {
                if (milliseconds < 0)
                    throw new ArgumentOutOfRangeException("Time cannot run backwards here.");
                currentSpeed += _acceleration * (double)(milliseconds / 1000);
                if (currentSpeed > _maxSpeed)
                    currentSpeed = _maxSpeed;
                return currentSpeed;
            }
        }

        public void UpdateCounterforce(double counterforce) //Only use if characters counterforce changes(e.g. parachute on/off)
        {
            this._counterforce = ForceValid(counterforce);
            _acceleration = CalculateAcceleration(this._counterforce);
        }

        private int CalculateMaxSpeed(double counterforce)
        {
            if (counterforce < 0.01)
                return int.MaxValue;
            else if (counterforce > 0.99)
                return 0;
            else return Convert.ToInt32(_force / counterforce);
        }

        private int CalculateAcceleration(double counterforce)
        {
            double multiplier = 1 - counterforce;
            return Convert.ToInt32(_force * multiplier);
        }

        private double ForceValid(double counterforce)
        {
            if (counterforce < 0 || counterforce > 1)
                throw new ArgumentOutOfRangeException("Counterforce must be between 0 and 1.");
            else return counterforce;
        }
    }
}
