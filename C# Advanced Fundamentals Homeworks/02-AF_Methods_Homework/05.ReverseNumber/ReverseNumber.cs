using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ReverseNumber
{
    class ReverseNumber
    {
        static double ReverseDigits(double num)
        {
            byte decimalSpaces = 0; 

            while(num%1!=0)  //turn the number to integer and save the decimal places
            {
                num *= 10;
                decimalSpaces++;
            }
            int numToInt = (int)num;
            Stack<int> digits = new Stack<int>();
            while(numToInt!=0)      //push the digits in a stack so they're reversed automatically
            {
                digits.Push(numToInt % 10);
                numToInt /= 10;
            }
            double reversedNumber = 0;
            int i = 0;
            while(digits.Count>0)       //get the numbers from the stack and multiply them so they are
                                        //in their correct possition
            {
                reversedNumber += Math.Pow(10, i) * digits.Pop();
                i++;
            }
            return reversedNumber / Math.Pow(10,decimalSpaces);   //divide the reversed number to 10 to the power of
                                                                  //decimalSpaces so we end up with the decimal
                                                                  //seperator at the correct position
        }
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            Console.WriteLine(ReverseDigits(number));
        }
    }
}
