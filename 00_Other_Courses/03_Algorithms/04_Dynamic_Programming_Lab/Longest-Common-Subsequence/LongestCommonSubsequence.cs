namespace Longest_Common_Subsequence
{
    using System;
    using System.Collections.Generic;

    public class LongestCommonSubsequence
    {
        public static void Main()
        {
            var firstStr = "treeeeeee";
            var secondStr = "team";

            var lcs = FindLongestCommonSubsequence(firstStr, secondStr);

            Console.WriteLine("Longest common subsequence:");
            Console.WriteLine("  first  = {0}", firstStr);
            Console.WriteLine("  second = {0}", secondStr);
            Console.WriteLine("  lcs    = {0}", lcs);
        }

        public static string FindLongestCommonSubsequence(string firstStr, string secondStr)
        {
            int[,] matrix = new int[firstStr.Length + 1, secondStr.Length + 1];

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (firstStr[i - 1] == secondStr[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        matrix[i, j] = Math.Max(matrix[i, j - 1], matrix[i - 1, j]);
                    }
                }
            }
            return RecoverLCS(firstStr, secondStr, matrix);

        }

        private static string RecoverLCS(string firstStr, string secondStr, int[,] matrix)
        {
            int i = firstStr.Length;
            int j = secondStr.Length;

            List<char> lcs = new List<char>();

            while (i > 0 && j > 0)
            {
                if (firstStr[i - 1] == secondStr[j - 1])
                {
                    lcs.Add(firstStr[i-1]);
                    i -= 1;
                    j -= 1;
                }
                else if (matrix[i, j] == matrix[i - 1, j])
                {
                    i -= 1;
                }
                else
                {
                    j -= 1;
                }
            }

            lcs.Reverse();

            return string.Join("", lcs);
        }
    }
}
