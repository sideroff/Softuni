using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Calculate_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int> numbers = new Queue<int>();
            numbers.Enqueue(n);
            for (int i = 0; i < 50; i++)
            {
                int current = numbers.Dequeue();
                Console.Write(current + ", ");
                numbers.Enqueue(current+1);
                numbers.Enqueue(current*2+1);
            }
        }
    }
}
