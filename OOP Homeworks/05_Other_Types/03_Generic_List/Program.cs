using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _03_Generic_List
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(10);
            list.PutAt(3,6);

            list.Add(9);
            list.PutAt(3, 6);

            list.Add(8);
            list.Add(7);
            list.Add(6);
            list.Add(5);

            Console.WriteLine("Full list: ");
            Console.WriteLine(list + Environment.NewLine);
            Console.WriteLine("does the list contain the digit 1?: "+list.Contains(1) + Environment.NewLine);
            Console.WriteLine($"Element at position 0 is {list.GetAt(0)}"+ Environment.NewLine);
            

            list.RemoveAt(0);
            list.RemoveAt(3);
            Console.WriteLine("Full list after removing digits at index 0 and 3: ");
            Console.WriteLine(list + Environment.NewLine);

            list.Clear();
            Console.WriteLine("List after .Clear() command: ");
            Console.WriteLine(list + Environment.NewLine);

            list.RemoveAt(0);
            list.Remove();
            list.Remove();
            list.Remove();
            list.Remove();
            list.Remove();
            list.Remove();
            list.Remove();
            Console.WriteLine(list);

            //this will throw exception because the list is cleared by now
            //Console.WriteLine($"Element at position 0 is {list.GetAt(0)}");
        }
    }
}
