using System;
class Program
{
    static void Main()
    {
        int wormLenght = int.Parse(Console.ReadLine()) * 100;
        double wormWidth = double.Parse(Console.ReadLine());

        if (wormLenght % wormWidth == 0) Console.WriteLine("{0:f2}", wormLenght * wormWidth);
        else Console.WriteLine("{0:f2}%", wormLenght * 100 / wormWidth);
    }
}