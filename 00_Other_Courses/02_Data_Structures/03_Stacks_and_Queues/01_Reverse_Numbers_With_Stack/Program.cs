using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Reverse_Numbers_With_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers= new Stack<int>();

            foreach (var i in Console.ReadLine().Split().Select(int.Parse))
            {
                numbers.Push(i);
            }

            while (numbers.Count > 0)
            {
                Console.Write(numbers.Pop() + " ");
            }
        }
    }
}
