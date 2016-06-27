using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Parenthesis
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var list = generateParenthesis(n);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        private static List<string> generateParenthesis(int n)
        {
            List<string> result = new List<string>();
            dfs(result, "", n, n);
            return result;
        }

        private static void dfs(List<string> result, string s, int left, int right)
        {
            if (left > right)
            {
                return;
            }

            if (left == 0 && right == 0)
            {
                result.Add(s);
                return;
            }

            if (left > 0)
            {
                dfs(result, s + "(", left - 1, right);
            }

            if (right > 0)
            {
                dfs(result, s + ")", left, right - 1);
            }
        }

    }
}
