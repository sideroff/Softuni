using System;
using System.Linq;

namespace _06_Cable_Merchant
{
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            List<int> cablePrices = new List<int>();
            cablePrices.Add(0);
            cablePrices.AddRange(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int price = int.Parse(Console.ReadLine());
            
            for (var i = cablePrices.Count-1; i >0; i--)
            {
                var possibleSums = GetSumWays(Enumerable.Range(1, i - 1).ToArray(), i);
                int sum = 0;
                foreach (var sumWay in possibleSums)
                {
                    sum = 0;
                    foreach (var element in sumWay)
                    {
                        sum += cablePrices[element];
                    }
                    sum -= (sumWay.Length -1)*2*price;
                    if (sum > cablePrices[i])
                    {
                        cablePrices[i] = sum;
                    }
                }
            }
            Console.WriteLine(string.Join(" ",cablePrices.Skip(1)));
        }

        static int[][] GetSumWays(int[] array, int k)
        {
            int[][][] ways = new int[k + 1][][];
            ways[0] = new[] { new int[0] };

            for (int i = 1; i <= k; i++)
            {
                ways[i] = (
                    from val in array
                    where i - val >= 0
                    from subway in ways[i - val]
                    where subway.Length == 0 || subway[0] >= val
                    select Enumerable.Repeat(val, 1)
                        .Concat(subway)
                        .ToArray())
                        .ToArray();
            }

            return ways[k];
        }
    }
}



