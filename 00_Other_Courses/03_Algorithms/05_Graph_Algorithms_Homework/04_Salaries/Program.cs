using System;
using System.Collections.Generic;

namespace _04_Salaries
{
    using System.Linq;

    class Program
    {
        private static List<int>[] employees;
        static void Main()
        {
            int people = int.Parse(Console.ReadLine());
            employees = new List<int>[people];
            for (int i = 0; i < people; i++)
            {
                employees[i] = new List<int>();
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 'Y')
                    {
                        employees[i].Add(j);
                    }
                }
            }
            long sum = 0;
            for (int i = 0; i < people; i++)
            {
                sum += CalculateSalary(i);
            }
            Console.WriteLine(sum);
        }

        private static long CalculateSalary(int person)
        {
            if (employees[person].Count == 0)
            {
                return 1;
            }
            long sum = 0;
            foreach (var subEmployees in employees[person])
            {
                sum += CalculateSalary(subEmployees);
            }
            return sum;
        }
    }
}

