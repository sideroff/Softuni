using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_OrderedSet_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderedSet<int> orderedSet = new OrderedSet<int>();
            orderedSet.Add(5);
            orderedSet.Add(3);
            orderedSet.Add(7);
            orderedSet.Add(1);
            orderedSet.Add(4);
            orderedSet.Add(6);
            orderedSet.Add(8);
            orderedSet.Add(2);

            foreach (var i in orderedSet)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine($"Number of elements (should be 7): {orderedSet.Count}");
            Console.WriteLine($"Check if set contains 3 (it should): {orderedSet.Contains(3)}");
            Console.WriteLine($"Try removing 3 (should succeed): {orderedSet.Remove(3)}");
            Console.WriteLine($"Try removing 3 (should fail): {orderedSet.Remove(3)}");
            Console.WriteLine($"Try removing 5 (should succeed): {orderedSet.Remove(5)}");
            Console.WriteLine($"Check if set contains 5 (it should not): {orderedSet.Contains(5)}");
            Console.WriteLine($"Number of elements (should be 5): {orderedSet.Count}");

            foreach (var i in orderedSet)
            {
                Console.WriteLine(i);
            }


        }
    }
}
