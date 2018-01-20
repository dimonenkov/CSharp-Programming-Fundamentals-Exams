using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp272
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"(^((<\[[^a-zA-Z0-9]*\]\.)+(\.\[[a-zA-Z0-9]*\]\.)*(\2)*)$)";
            Regex rgx = new Regex(pattern);
            while (true)
            {
                var text = Console.ReadLine();
                if (text == "Traincode!")
                {
                    break;
                }
                MatchCollection trains = rgx.Matches(text);
                foreach (var item in trains)
                {
                    Console.WriteLine(item.ToString());
                }
            }


        }
    }
}