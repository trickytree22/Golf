using System;
using System.Collections.Generic;

namespace Golf
{
    class Program
    {
        public static List<Golfer> GolferList;

        static void Main(string[] args)
        {
            string[] UserInput = new string[2];
            GolferList = new List<Golfer>();
            while (true)
            {
                Console.WriteLine("Type x when you have enough players");
                Console.WriteLine("Input name of golfer");
                string _temp = Console.ReadLine();
                if (_temp == "x")
                {
                    break;
                }
                UserInput[0] = _temp;
                Console.WriteLine("Input distance to cup");
                _temp = Console.ReadLine();
                if (_temp == "x")
                {
                    break;
                }
                UserInput[1] = _temp;
                Golfer _tempGolfer = new Golfer(UserInput);
                GolferList.Add(_tempGolfer);
            }
            while (GolferList.Count > 0)
            {
                foreach (Golfer golfer in GolferList)
                {
                    golfer.Swing();
                    if (golfer.InHole)
                    {
                        Console.Clear();
                        Console.WriteLine($"{golfer.GolferName} finished the hole with {golfer.SwingCount} swings.");
                        foreach (KeyValuePair<int,double> swing in golfer.SwingAndDistance)
                        {
                            Console.WriteLine($"Swing {swing.Key} went a distance of {swing.Value}.");
                        }
                        GolferList.Remove(golfer);
                        Console.WriteLine("Press a key to continue");
                        Console.ReadKey();
                        break;
                    }
                    if (golfer.BallLost)
                    {
                        Console.WriteLine("You did not finish the hole. Better luck next time."); //Comment this out to remove the partially similar ending messages
                        GolferList.Remove(golfer);
                        Console.WriteLine("Press a key to continue"); //This could also be commented out
                        Console.ReadKey();
                        break;
                    }
                }
            }

        }
    }
}
