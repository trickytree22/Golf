using System;
using System.Collections.Generic;
using System.Text;

namespace Golf
{
    class Ball
    {
        private double Velocity { get; set; }
        private double Angle { get; set; }

        public Ball()
        {
            Velocity = 0;
            Angle = 0;
        }

        internal void SetVelocity(double velocity)
        {
            Velocity = velocity;
        }

        internal void SetAngle(double angle)
        {
            Angle = angle;
        }
        
        internal double CalculateDistance()
        {
            double _thisFar;
            double Gravity = 9.8;
            _thisFar = Math.Pow(Velocity, 2) / Gravity * Math.Sin(2 *(Math.PI / 180) * Angle);
            return _thisFar;
        }
    }
}
