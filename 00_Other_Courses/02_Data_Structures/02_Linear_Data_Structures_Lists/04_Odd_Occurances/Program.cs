using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Odd_Occurances
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> markedIndexes = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                bool appearsMoreThanOnce = false;
                for (int j = i+1; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        markedIndexes.Add(list[j]);
                        appearsMoreThanOnce = true;
                        break;
                    }
                }
                if (!appearsMoreThanOnce && !markedIndexes.Contains(list[i]))
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
