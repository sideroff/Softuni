
//Write a program to sort an array of numbers and then print them back on the console.
//The numbers should be entered from the console on a single line, separated by a space.
//Refer to the examples for problem 1.
//Note: Do not use the built-in sorting method, you should write your own.


using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SortArrayUsingSelectionSort
{
    class SelectionSortArray
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> list = new List<int>();
            list = arr.ToList();
            for (int i = 0; i <list.Count; i++)
            {
                
                int min = list[i];
                int minValueIndex = i;
                for (int k = i+1; k < list.Count; k++)
                {
                    if (list[k]< min)
                    {
                        min = list[k];
                        minValueIndex = k;
                    }

                }
                if(minValueIndex!=i)
                {
                    list.RemoveAt(minValueIndex);
                    list.Insert(i, min);
                }
                
            }
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
