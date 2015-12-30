using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Interest_Calculator
{
    class Program
    {
        public delegate decimal CalculateInterest(decimal sum, decimal interest, int years);

        public class DelegatesExample
        {

            public static decimal GetSimpleInterest(decimal sum, decimal interest, int years)
            {
                return sum * (1 + interest * years);
            }
            public static decimal GetCompoundInterest(decimal sum, decimal interest, int years)
            {
                return sum*(decimal) Math.Pow((double) (1 + interest/12), years*12);
            }

            public static void Main()
            {
                InterestCalculator iCalc = new InterestCalculator(500, 5.6m, 10, GetCompoundInterest);
                InterestCalculator iCalc2 = new InterestCalculator(2500,7.2m,15, GetSimpleInterest);

                Console.WriteLine("{0:F3}", iCalc.Result);
                Console.WriteLine("{0:F3}", iCalc2.Result);

            }
        }

    }
}
