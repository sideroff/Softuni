using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToArray();
            Dictionary<char, int> qkoime = new Dictionary<char, int>();
            foreach(var letter in input)
            {
                int counter = input.Count(x => x == letter);
                qkoime[letter] = counter;
            }
            var list = qkoime.Keys.ToList();
            list.Sort();
            foreach(var key in list)
            {
                Console.WriteLine("{0}: {1}",key,qkoime[key]);
            }
        }
    }
}
