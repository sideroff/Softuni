using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.CountSubstringOccurances
{
    class CountSubstringOccurances
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            string searchWord = Console.ReadLine();
            FindOccurances(input,searchWord);
        }

        private static void FindOccurances(string[] input, string searchWord)
        {

            int appearances = 0;
            foreach (var str in input)
            {
                if (searchWord.Equals(str)) appearances++;
            }
            Console.WriteLine("The number of times \"{0}\" appears in \"{1}\" is: {2}",searchWord, string.Join(" ", input), appearances);
        }
    }
}
