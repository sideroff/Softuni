using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<char,int> hashTable = new HashTable<char, int>();
            string input = Console.ReadLine();
            foreach (var c in input)
            {
                if (!hashTable.ContainsKey(c))
                {
                    hashTable[c] = 0;
                }
                hashTable[c]++;
            }

            foreach (var keyValue in hashTable)
            {
                Console.WriteLine($"{keyValue.Key}: {keyValue.Value} time/s. ");
            }
        }
    }
}
