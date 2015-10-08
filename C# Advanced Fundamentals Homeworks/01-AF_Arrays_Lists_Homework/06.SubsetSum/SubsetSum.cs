//Write a program that reads from the console a number N and an array of integers given on a 
//    single line.Your task is to find all subsets within the array which have a sum equal to N 
//    and print them on the console(the order of printing is not important). Find only the unique 
//    subsets by filtering out repeating numbers first.In case there aren't any subsets with the 
//desired sum, print "No matching subsets." 
using System;
using System.Collections.Generic;
using System.Linq;

class SubsetSums
{

    static void Main()
    {
        //int n = int.Parse(Console.ReadLine());
        int n = 10;
        //int[] numbers = Console.ReadLine().Split().Select(int.Parse).Distinct().ToArray();
        int[] numbers = { 1,2,3,4,5,6,7,8,9,10 };

        var subset = new List<int>();
        double combinations = Math.Pow(2, numbers.Length);

        bool isEqual = false;

        for (int i = 1; i < combinations; i++)
        {
            int sum = 0;
            for (int j = 0; j < numbers.Length; j++)
            {
                int mask = i & (1 << j);
                if (mask != 0)
                {
                    sum += numbers[j];
                    subset.Add(numbers[j]);
                }
            }

            if (sum == n)
            {
                Console.WriteLine(string.Join(" + ", subset) + " = " + sum);
                isEqual = true;
            }

            subset.Clear();
        }

        if (!isEqual)
        {
            Console.WriteLine("No matching subsets.");
        }
    }
}