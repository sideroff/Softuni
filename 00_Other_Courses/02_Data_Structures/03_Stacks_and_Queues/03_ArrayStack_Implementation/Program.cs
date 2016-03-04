using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ArrayStack_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var newStack = new ArrayStack<int>(8);
            newStack.Push(1);
            newStack.Push(2);
            newStack.Push(3);
            newStack.Push(4);

            newStack.Pop();
            newStack.Pop();
            newStack.Pop();

            newStack.Push(9);

            var array = newStack.ToArray();

            Console.WriteLine(string.Join(" ",array));

            Console.WriteLine(newStack.Pop() + " " + newStack.Pop());
        }
    }
}
