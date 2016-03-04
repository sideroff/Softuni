namespace _03_Longest_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        

        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var sequenceFinder = new Sequence_Finder();

            var result = sequenceFinder.Get_Longest_Sequence(list);
            Console.WriteLine(result);
        }
    }
}
