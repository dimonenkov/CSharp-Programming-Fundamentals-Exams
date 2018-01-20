using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1_Trainers1
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfParticipants = int.Parse(Console.ReadLine());
            var technicalSum = 0.0;
            var theoreticalSum = 0.0;
            var practicalSum = 0.0;




            for (int i = 0; i < numberOfParticipants; i++)
            {
                var distanceToTravelMiles = int.Parse(Console.ReadLine());
                double distMeters = distanceToTravelMiles * 1600;
                var cargo = double.Parse(Console.ReadLine());
                double cargoKilos = cargo * 1000;
                var team = Console.ReadLine();
                if (team == "Technical")
                {
                    technicalSum += ((cargoKilos * 1.5) - (0.7 * distMeters * 2.5));
                }
                else if (team == "Theoretical")
                {
                    theoreticalSum += (int)((cargoKilos * 1.5) - (0.7 * distMeters * 2.5));
                }
                else if (team == "Practical")
                {
                    practicalSum += (int)((cargoKilos * 1.5) - (0.7 * distMeters * 2.5));
                }

            }
            var valSums = new List<double>();
            valSums.Add(technicalSum);
            valSums.Add(theoreticalSum);
            valSums.Add(practicalSum);
            var maxSum = valSums.Max();

            if (maxSum == technicalSum)
            {
                Console.WriteLine($"The Technical Trainers win with ${technicalSum:f3}.");
            }
            else if (maxSum == theoreticalSum)
            {
                Console.WriteLine($"The Theoretical Trainers win with ${theoreticalSum:f3}.");
            }
            else if (maxSum == practicalSum)
            {
                Console.WriteLine($"The Practical Trainers win with ${practicalSum:f3}.");
            }
        }
    }
}