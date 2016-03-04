using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Linked_List_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedList<int> newList = new CustomLinkedList<int>();
            newList.Add(1);
            var specificNode = newList.Add(2);
            newList.Add(3);
            newList.Add(4);

            newList.AddAfter(specificNode,9);
            Console.Write("Whole List: ");
            newList.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            Console.WriteLine("Head is: " +newList.Head.Value);
            Console.WriteLine("Tail is: " + newList.Tail.Value);
            foreach (var i in newList)
            {
                Console.Write(i +" ");
            }
            Console.WriteLine();
            Console.WriteLine("First index of 9 is: " + newList.FirstIndexOf(9));

        }
    }
}
