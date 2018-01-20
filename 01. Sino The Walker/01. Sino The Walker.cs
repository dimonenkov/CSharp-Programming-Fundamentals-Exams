using System;

class Program
{
    static void Main()
    {
        DateTime leaves = DateTime.Parse(Console.ReadLine());

        double steps = double.Parse(Console.ReadLine()) % 86400;//steps in seconds
        //махаме цели дни, ако някой се прави на интересен да ни ги подава като вход
        double timeInSeconds = double.Parse(Console.ReadLine()) % 86400;//time in seconds for each step

        double allTime = steps * timeInSeconds / 3600;//in seconds
        Console.WriteLine("Time Arrival: " + (leaves.AddHours(allTime)).TimeOfDay);
    }
}