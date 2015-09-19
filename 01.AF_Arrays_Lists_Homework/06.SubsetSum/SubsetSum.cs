//Write a program that reads from the console a number N and an array of integers given on a 
//    single line.Your task is to find all subsets within the array which have a sum equal to N 
//    and print them on the console(the order of printing is not important). Find only the unique 
//    subsets by filtering out repeating numbers first.In case there aren't any subsets with the 
//desired sum, print "No matching subsets." 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SubsetSum
{
    class SubsetSum
    {
        static List<int> sub= new List<int>();
        
        static void SubsetFinder(int num, List<int> set)
        {
            for (int i = 0; i < set.Count; i++)
            {
                i = 2;
                sub.Add(set[i]);
                if(set[i]==num)
                {

                }
            }

        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> list = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToList();
            list.Sort();
            
            SubsetFinder(n, list);


        }
    }
}
