// generate all combinations of letters such that same letters are together
namespace _02_Generate_All_Combinations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    class Program
    {
        private static Dictionary<string, int> lettersCount;
        public static void Main(string[] args)
        {
            lettersCount = new Dictionary<string, int>();
            foreach (var s in Console.ReadLine().Split())
            {
                if (!lettersCount.ContainsKey(s))
                {
                    lettersCount[s] = 0;
                }
                lettersCount[s]++;
            }

            Permute(lettersCount.Keys.ToArray(), 0);
        }

        public static void Permute(string[] letters, int index)
        {
            if (index == letters.Length)
            {
                PrintArray(letters);
                return;
            }
            Permute(letters, index + 1);
            for (int i = index + 1; i < letters.Length; i++)
            {
                Swap(ref letters[i], ref letters[index]);
                Permute(letters, index + 1);
                Swap(ref letters[i], ref letters[index]);
            }
        }

        private static void Swap(ref string one, ref string two)
        {
            var swap = one;
            one = two;
            two = swap;
        }

        private static void PrintArray(string[] letters)
        {
            for (var i = 0; i < letters.Length; i++)
            {
                for (int j = 0; j < lettersCount[letters[i]]; j++)
                {
                    Console.Write(letters[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
