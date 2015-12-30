using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LastDigitOfANumber
{
    class LastDigitOfANumber
    {

        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("The last digit of the number you entered is: {0}",GetLastDigitAsWord(num));

        }
        static string GetLastDigitAsWord(int number)
        {
            string[] digitAsWord = {"zero","one","two","three","four","five",
                                    "six","seven","eight","nine","ten"};
            return digitAsWord[(number % 10)];
        }
    }
}
