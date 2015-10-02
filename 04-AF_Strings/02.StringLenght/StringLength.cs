using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StringLenght
{
    class StringLength
    {
        static int maxLength = 20;
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(FormatStringTo20Chars(input));
            
        }

        private static string FormatStringTo20Chars(string input)
        {
            if (input.Length > maxLength)
            {
                return input.Substring(0, maxLength);
            }
            else return input.PadRight(20, '*');
        }
    }
}
