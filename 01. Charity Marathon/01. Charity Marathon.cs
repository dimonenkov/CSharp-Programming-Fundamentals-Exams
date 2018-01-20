using System;

class CharityMarathon
{
    static void Main(string[] args)
    {
        int days = int.Parse(Console.ReadLine());
        int runners = int.Parse(Console.ReadLine());
        int laps = int.Parse(Console.ReadLine());
        int lapLenght = int.Parse(Console.ReadLine());
        int trackCapacity = int.Parse(Console.ReadLine());
        double moneyPerKm = double.Parse(Console.ReadLine());

        int maxRunners = 0;
        if (trackCapacity * days >= runners)
        {
            maxRunners = runners;
            long totalKm = ((long)(maxRunners * laps * lapLenght)) / 1000;
            CalculateTotalMoney(moneyPerKm, totalKm);
        }
        else
        {
            maxRunners = trackCapacity * days;
            long totalKm = ((long)(maxRunners * laps * lapLenght)) / 1000;
            CalculateTotalMoney(moneyPerKm, totalKm);
        }
    }

    private static void CalculateTotalMoney(double moneyPerKm, long totalKm)
    {
        double totalMoney = totalKm * moneyPerKm;
        Console.WriteLine("Money raised: {0:F2}", totalMoney);
    }
}