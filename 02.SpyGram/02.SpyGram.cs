using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.SpyGram
{
    class Startup
    {
        static void Main()
        {
            Dictionary<string, List<string>> messages = new Dictionary<string, List<string>>();

            string privateKey = Console.ReadLine();

            int index = 0;

            Regex regex = new Regex(@"^TO:\s([A-Z]+);\sMESSAGE:\s(.+);$");

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);

                    string sender = match.Groups[1].ToString();

                    if (!messages.ContainsKey(sender))
                    {
                        messages.Add(sender, new List<string>());
                    }

                    string convertedMessage = "";

                    for (int i = 0; i < match.Length; i++)
                    {
                        if (index > privateKey.Length - 1) index = 0;
                        var x = int.Parse(privateKey[index].ToString());
                        char letter = (char)(match.ToString()[i] + x);
                        convertedMessage += letter;
                        index++;
                    }
                    index = 0;
                    messages[sender].Add(convertedMessage);

                }
                input = Console.ReadLine();
            }

            foreach (var sender in messages.OrderBy(n => n.Key))
            {
                foreach (var item in sender.Value)
                {
                    Console.WriteLine(item);
                }
            }

        }
    }
}