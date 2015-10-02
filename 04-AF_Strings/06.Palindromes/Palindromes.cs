using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Palindromes
{
    class Palindromes
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please use only one delimeter at a time C:");
            string[] input = Console.ReadLine().Split(new Char[] { ' ', ',', '.', '?', '!' });
            CheckIfPalindrome(input);
        }

        private static void CheckIfPalindrome(string[] input)
        {
            foreach(string word in input)
            {
                string temp = word;
                temp = Reverse(temp);
                if (word.Equals(temp)) Console.WriteLine(word);
            }
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
