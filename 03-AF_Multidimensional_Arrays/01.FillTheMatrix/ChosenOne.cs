using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.FillTheMatrix
{
    class ChosenOne
    {
        static int[,] Neo(int[,] arr,int n)
        {
            int j = 1;
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    arr[k, i] = j++; //int.Parse(Console.ReadLine());
                }
            }
            return arr;
        }
        static int[,] Prophet(int[,] arr,int n)
        {
            int j = 1;
            bool sw = false;
            for (int i = 0; i < n; i++)
            {
                if (sw == false)
                {
                    for (int k = 0; k < n; k++)
                    {
                        arr[k, i] = j++; //int.Parse(Console.ReadLine());
                    }
                    sw = true;
                    continue;
                }
                for (int k = n - 1; k >= 0; k--)
                {
                    arr[k, i] = j++; //int.Parse(Console.ReadLine());
                }
                sw = false;

            }
            return arr;
        }
        static void PrintMatrix(int[,] arr,int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    Console.Write(" {0}", arr[i, k]);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] arr = new int[n,n];
            Console.WriteLine("First matrix looks like dis: ");
            PrintMatrix(Neo(arr, n),n);
            Console.WriteLine("Second matrix looks like dis: ");
            PrintMatrix(Prophet(arr, n),n);

            

        }

        
    }
}
