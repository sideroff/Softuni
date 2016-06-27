using System;
using System.Collections.Generic;
using System.Linq;


public class Knapsack
{
    static void Main()
    {
        int[] intervals = Console.ReadLine().Split(
            new char[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int currentVol = int.Parse(Console.ReadLine());
        int maxVol = int.Parse(Console.ReadLine());

        bool[] row = new bool[maxVol+1];
        row[currentVol] = true;

        List<int> trueSpots = new List<int>();
        trueSpots.Add(currentVol);

        foreach (var interval in intervals)
        {
            List<int> forRemoval = new List<int>();
            foreach (var trueSpot in trueSpots)
            {
                bool shouldRemove = false;
                if (trueSpot - interval >= 0)
                {
                    row[trueSpot] = false;
                    row[trueSpot - interval] = true;
                    trueSpots.Add(trueSpot-interval);
                    shouldRemove = true;
                }
                if (trueSpot + interval <= maxVol)
                {
                    row[trueSpot] = false;
                    row[trueSpot + interval] = true;
                    trueSpots.Add(trueSpot + interval);
                    shouldRemove = true;
                }
                if (shouldRemove)
                {
                    forRemoval.Add(trueSpot);
                }
            }
            foreach (var index in forRemoval)
            {
                trueSpots.Remove(index);
            }
        }
        Console.WriteLine(trueSpots.Max());
    }
}
