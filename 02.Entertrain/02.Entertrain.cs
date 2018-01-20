using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Entertain
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = new List<int>();
            int locoPower = int.Parse(Console.ReadLine()), currentSum = 0, average = 0;
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (input.Equals("All ofboard!")) break;
                else
                {
                    int currentWagon = int.Parse(input);

                    wagons.Add(currentWagon);
                    currentSum = wagons.Sum();
                    if (currentSum > locoPower)
                    {
                        Dictionary<int, int> toRemove = new Dictionary<int, int>();
                        average = currentSum / wagons.Count;
                        foreach (int wagon in wagons)
                        {
                            toRemove.Add(wagon, Math.Abs(average - wagon));
                        }
                        foreach (var item in toRemove.OrderBy(x => x.Value).Take(1))
                        {
                            wagons.Remove(item.Key);
                        }
                    }
                }
            }
            wagons.Reverse();
            if (wagons.Count > 0) Console.WriteLine(string.Join(" ", wagons) + " " + locoPower);
            else Console.WriteLine(locoPower);
            Console.ReadLine();
        }
    }
}