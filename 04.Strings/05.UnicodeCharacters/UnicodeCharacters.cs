using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.UnicodeCharacters
{
    class UnicodeCharacters
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            GetUnicodeValueFromCharArray(input);
    }

        private static void GetUnicodeValueFromCharArray(char[] input)
        {

            foreach (var ch in input)
                Console.Write("\\U{0:X4}", Convert.ToUInt16(ch));
        }
    }
}
