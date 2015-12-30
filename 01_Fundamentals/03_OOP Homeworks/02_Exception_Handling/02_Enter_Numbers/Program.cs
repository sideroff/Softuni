using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Enter_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            enter10Numbers();
        }
        public static int EnterNumbers(int start, int end)
        {
            int a = int.Parse(Console.ReadLine());
            if (a < start || a > end) throw new ArgumentOutOfRangeException();
            return a;
        }
        public static void enter10Numbers()
        {
            int start = 1;
            int end = 100;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter number №{0}",i);
                try
                {
                    EnterNumbers(start,end);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Number must be between {0} and {1}.", start, end);
                    i--;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number.");
                    i--;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Number must be in INT32 range.");
                    i--;
                }
                catch (Exception)
                {
                    i--;
                }
            }
        }
    }
}
