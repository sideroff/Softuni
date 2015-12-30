//Write a program to find all increasing sequences inside an array of integers.
//    The integers are given on a single line, separated by a space.Print the sequences 
//    in the order of their appearance in the input array, each at a single line.Separate 
//    the sequence elements by a space.Find also the longest increasing sequence and 
//    print it at the last line.If several sequences have the same longest length, 
//    print the left-most of them.

using System;
using System.Collections.Generic;
using System.Linq;

namespace _14._9_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<List<int>> list = new List<List<int>>();
            list.Add(new List<int>());
            list[0].Add(input[0]);
            for (int i = 1; i < input.Length; i++)
            {

                if (input[i - 1] < input[i])
                {
                    list[list.Count - 1].Add(input[i]);
                }
                else
                {
                    list.Add(new List<int>());
                    list[list.Count - 1].Add(input[i]);
                }

            }
            List<int> max = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Count > max.Count) max = list[i];
                Console.WriteLine(string.Join(", ", list[i]));
            }
            Console.Write("Longest: ");
            Console.WriteLine(string.Join(", ", max));

        }
    }
}
