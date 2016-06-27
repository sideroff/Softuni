using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FilterText
{
    class FilterText
    {
        static void Main(string[] args)
        {
            string[] banWords = Console.ReadLine().Split(',').ToArray();
            string input = Console.ReadLine();
            FilterWords(banWords,input);
        }

        private static void FilterWords(string[] banWords, string input)
        {
            foreach(var word in banWords)
            {
                input = input.Replace(word, new string('*', word.Count()));
            }
            Console.WriteLine(input);
        }
    }
}
