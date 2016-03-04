using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_LinkedQueue_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {

            LinkedQueue<int> queue = new LinkedQueue<int>();

            for (int i = 0; i < 2; i++)
            {
                queue.Enqueue(1);
                queue.Enqueue(2);
                queue.Enqueue(3);

                while (queue.Count > 0)
                {
                    Console.WriteLine(queue.Dequeue());
                }

            }
        }
    }
}
