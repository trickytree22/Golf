using System;
using System.Collections.Generic;
using System.Text;

namespace Golf
{
    class Golfer
    {
        internal double Location { get; private set; }
        internal int SwingCount { get; private set; }
        public string GolferName { get; private set; }
        internal Ball GolfersBall { get; private set; }
        internal bool InHole { get; private set; }
        internal Dictionary<int, double> SwingAndDistance = new Dictionary<int, double>();
        internal bool BallLost { get; private set; }


        internal Golfer(string[] inputArray)
        {
            SwingCount = 0;
            double.TryParse(inputArray[1], out double _location);
            Location = _location;
            GolferName = inputArray[0];
            GolfersBall = new Ball();
        }

        internal void UpdateLocation(double distance)
        {
            if (distance > Location*3 && distance > 300)
            {
                throw new GolferException("Ball hit too far. It was eaten by an alligator in the swamp.");
            }
            Location = (distance < Location) ? Location - distance : distance - Location;
            
            if (Math.Floor(Location*5) == 0)
            {
                InHole = true;
            }
            else
            {
                Console.WriteLine($"{GolferName} hit the ball {distance} and is now {Location} from the hole. \n That was {GolferName}'s {SwingCount} swing");
            }
        }

        internal void Swing()
        {
            try
            {
                UpdateSwingCount();
            }
            catch (GolferException e)
            {
                Console.WriteLine(e);
                BallLost = true;
                return;
            }
            Console.WriteLine($"{GolferName}'s distance to hole is {Location}.");
            Console.WriteLine($"Input the angle of {GolferName}'s swing");
            GolfersBall.SetAngle(GetUserInput());
            Console.WriteLine($"Input the velocity of {GolferName}'s swing");
            GolfersBall.SetVelocity(GetUserInput());
            Console.Clear();
            double distance = GolfersBall.CalculateDistance();
            SwingAndDistance.Add(SwingCount, distance);
            try
            {
                UpdateLocation(distance);
            }
            catch (GolferException e)
            {
                Console.WriteLine(e);
                BallLost = true;
            }
        }

        private double GetUserInput()
        {
            string _userInput = Console.ReadLine();
            double.TryParse(_userInput, out double result);
            return result;
        }

        internal void UpdateSwingCount()
        {
            SwingCount += 1;
            if (SwingCount > 10)
            {
                throw new GolferException("Too many swings. Your constant hitting of the ball reduced it to a pile of dust.");
            }
        }
    }
}
