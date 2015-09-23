using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.NumberCalculations
{
    class Program
    {
        static double[] StringArrToDoubleArr(string[] stringArr)
        {
            double[] doubleArr = new double[stringArr.Length];
            for (int i = 0; i < stringArr.Length; i++)
            {
                doubleArr[i] = double.Parse(stringArr[i]);
            }
            return doubleArr;
        }
        static double CalculateMax(double[] inputArr)
        {
            double max = inputArr[0];
            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] > max) max = inputArr[i];
            }
            return max;
        }
        static double CalculateMin(double[] inputArr)
        {
            double min = inputArr[0];
            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] < min) min = inputArr[i];
            }
            return min;
        }
        static double CalculateAvg(double[] inputArr)
        {
            double avg = 0;
            for (int i = 0; i < inputArr.Length; i++)
            {
                avg += inputArr[i];
            }
            return avg / inputArr.Length;
        }
        static double CalculateSum(double[] inputArr)
        {
            double sum = 0;
            for (int i = 0; i<inputArr.Length; i++)
            {
                sum += inputArr[i];
            }
            return sum;
        }
        static double CalculateProduct(double[] inputArr)
        {
            double product = 1;
            for (int i = 0; i < inputArr.Length; i++)
            {
                product *= inputArr[i];
            }
            return product;
        }

        static void Main(string[] args)
        {
            
            Console.WriteLine("Write the numbers seperated by space:");
            string[] input = Console.ReadLine().Split();

            double[] inputArr = StringArrToDoubleArr(input);

            Console.WriteLine("The Max value of your sequence is: {0}",CalculateMax(inputArr));
            Console.WriteLine("The Min value of your sequence is: {0}", CalculateMin(inputArr));
            Console.WriteLine("The Average value of your sequence is: {0}", CalculateAvg(inputArr));
            Console.WriteLine("The Sum of your sequence is: {0}", CalculateSum(inputArr));
            Console.WriteLine("The Product of your sequence is: {0}", CalculateProduct(inputArr));


        }
    }
}
