using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Reversed_List_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            ReversedList<int> list = new ReversedList<int>(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            long sum = 0;
            foreach (int element in list)
            {
                sum += element;
            }
            list.Remove(3);
            list.RemoveAt(0);
            list.Add(1);
            Console.WriteLine(sum);
            Console.WriteLine(list.Count);
        }
    }
}
