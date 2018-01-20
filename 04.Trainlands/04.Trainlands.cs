using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _4_Trainlands
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainDict = new Dictionary<string, Dictionary<string, int>>();


            var patternInput1 = new Regex(@"^[a-zA-Z0-9~#$@'^%""/*&()+\|;_!<]+ -> [a-zA-Z0-9~#$@'^%""/*&()+\|;_!<]+ : [a-zA-Z0-9~#$@'^%""/*&()+\|;_!<]+$");
            var patternInput2 = new Regex(@"^[a-zA-Z0-9~#$@'^%""/*&()+\|;_!<]+ -> [a-zA-Z0-9~#$@'^%""/*&()+\|;_!<]+$");
            var patternInput3 = new Regex(@"^[a-zA-Z0-9~#$@'^%""/*&()+\|;_!<]+ = [a-zA-Z0-9~#$@'^%""/*&()+\|;_!<]+$");


            var input = Console.ReadLine();

            while (input != "It's Training Men!")
            {
                if (patternInput1.IsMatch(input))
                {
                    var newInput = input.Split(new string[] { " -> ", " : " }, StringSplitOptions.RemoveEmptyEntries);
                    var trainName = newInput[0];
                    var wagonName = newInput[1];
                    var wagonPower = Convert.ToInt32(newInput[2]);

                    if (!mainDict.ContainsKey(trainName))
                    {
                        mainDict[trainName] = new Dictionary<string, int>();
                    }
                    mainDict[trainName].Add(wagonName, wagonPower);
                }
                else if (patternInput2.IsMatch(input))
                {
                    var newInput = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                    var trainName = newInput[0];
                    var otherTrainName = newInput[1];

                    if (!mainDict.ContainsKey(trainName))
                    {
                        mainDict[trainName] = new Dictionary<string, int>();
                    }
                    //mainDict[trainName].Clear();
                    foreach (var dict in mainDict[otherTrainName])
                    {
                        mainDict[trainName].Add(dict.Key, dict.Value);
                    }
                    mainDict.Remove(otherTrainName);
                }
                else if (patternInput3.IsMatch(input))
                {
                    var newInput = input.Split(new string[] { " = " }, StringSplitOptions.RemoveEmptyEntries);
                    var trainName = newInput[0];
                    var otherTrainName = newInput[1];

                    if (!mainDict.ContainsKey(trainName))
                    {
                        mainDict[trainName] = new Dictionary<string, int>();
                    }
                    mainDict[trainName].Clear();
                    foreach (var dict in mainDict[otherTrainName])
                    {
                        mainDict[trainName].Add(dict.Key, dict.Value);
                    }
                }





                input = Console.ReadLine();
            }
            foreach (var train in mainDict.OrderByDescending(m => m.Value.Values.Sum()).ThenBy(n => n.Value.Count))
            {
                Console.WriteLine($"Train: {train.Key}");

                foreach (var wag in train.Value.OrderByDescending(k => k.Value))
                {
                    Console.WriteLine($"###{wag.Key} - {wag.Value}");
                }
            }

        }
    }
}