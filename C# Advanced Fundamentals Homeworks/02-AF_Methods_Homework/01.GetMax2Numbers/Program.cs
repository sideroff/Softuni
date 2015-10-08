using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_AF_Methods_Homework
{
    class GetMaxOf2Numbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number1:");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Number2:");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("The biggest number is: {0}", GetMax(num1, num2));

        }
        static int GetMax(int number1, int number2)
        {
            if (number1 > number2) return number1;
            else return number2;
        }

    }
}
