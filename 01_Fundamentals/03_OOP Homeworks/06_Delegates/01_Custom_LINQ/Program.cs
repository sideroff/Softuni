using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Custom_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            list.Add(new Person("ivan", 16));
            list.Add(new Person("gosho", 16));
            list.Add(new Person("pesho", 18));
            list.Add(new Person("kiro", 80));
            list.Add(new Person("miro", 12));

            //Console.WriteLine(string.Join(", ",list.WhereNot(x=>x.Age>=80)));
            //Console.WriteLine(list.NewMax(x=>x.Age));

            int[,] array = new int[10,10];
            int counter = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int k = 0; k < array.GetLength(1); k++)
                {
                    array[i, k] = counter++;
                }
            }

            array.foreeach(val => Console.WriteLine(val));
        }
    }
}
