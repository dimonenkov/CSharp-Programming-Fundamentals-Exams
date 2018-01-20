using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Worms_World_Party
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, decimal>> TeamWormScore = new Dictionary<string, Dictionary<string, decimal>>();

            List<string> wormExistList = new List<string>();

            string inputLine = Console.ReadLine();

            while (inputLine != "quit")
            {
                string[] splitInput = inputLine.Split(new string[] { " -> " }, StringSplitOptions.None).ToArray();

                string wormName = splitInput[0];
                string team = splitInput[1];
                decimal score = decimal.Parse(splitInput[2]);

                //-------------------------------------------------------------
                if (!wormExistList.Contains(wormName))
                {
                    if (!TeamWormScore.ContainsKey(team))
                    {
                        TeamWormScore[team] = new Dictionary<string, decimal>();
                    }

                    if (!TeamWormScore[team].ContainsKey(wormName))
                    {
                        TeamWormScore[team][wormName] = score;
                    }
                }
                //-------------------------------------------------------------

                wormExistList.Add(wormName);

                inputLine = Console.ReadLine();
            }

            int place = 1;
            foreach (KeyValuePair<string, Dictionary<string, decimal>> teamScore in TeamWormScore
                .OrderByDescending(score => score.Value.Values.Sum())
                .ThenBy(sameScore => sameScore.Value.Keys.Count)
                .ThenBy(wormScore => wormScore.Value.Values.Max()))
            {
                string team = teamScore.Key;
                decimal totalTeamScore = teamScore.Value.Values.Sum();
                Console.WriteLine($"{place}. Team: {team} - {totalTeamScore}");

                foreach (KeyValuePair<string, decimal> wormScore in teamScore.Value
                    .OrderByDescending(wormScore => wormScore.Value))
                {
                    string wormName = wormScore.Key;
                    decimal score = wormScore.Value;
                    Console.WriteLine($"###{wormName} : {score}");
                }
                place++;
            }
        }
    }
}