using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_LinkedStack_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var newStack = new LinkedStack<int>();
            try
            {
                newStack.Pop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            newStack.Push(1);
            newStack.Push(2);

            while (newStack.Count > 0)
            {
                Console.WriteLine(newStack.Pop());
            }
        }
    }
}
