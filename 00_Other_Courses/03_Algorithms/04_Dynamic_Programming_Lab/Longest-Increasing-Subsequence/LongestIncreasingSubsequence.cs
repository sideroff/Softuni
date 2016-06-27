namespace Longest_Increasing_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Schema;

    public class LongestIncreasingSubsequence
    {
        public static void Main()
        {
            var sequence = new int[] { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10,
            1, 12, 13, 14, 20, 15, 30, 16, 17, 40, 18, 19, 20 };

            var expectedSeq = new int[] { 3, 5, 7, 8, 9, 11, 12, 13, 14,
            15, 16, 17, 18, 19, 20 };
            var longestSeq = FindLongestIncreasingSubsequence(sequence);
            Console.WriteLine("Longest increasing subsequence (LIS)");
            Console.WriteLine("  Length: {0}", longestSeq.Length);
            Console.WriteLine("  Sequence: [{0}]", string.Join(", ", longestSeq));
        }

        public static int[] FindLongestIncreasingSubsequence(int[] sequence)
        {
            int[] len =new int[sequence.Length];
            int[] prev =new int[sequence.Length];

            int maxLen = 0;
            int lastIndex = -1;

            for (int i = 0; i < sequence.Length; i++)
            {
                len[i] = 1;
                prev[i] = -1;

                
                for (int j = 0; j < i; j++)
                {
                    if (sequence[j] < sequence[i] && len[j] >= len[i])
                    {
                        len[i] = len[j] + 1;
                        prev[i] = j;
                    }
                }
                if (len[i] > maxLen)
                {
                    maxLen = len[i];
                    lastIndex = i;
                }
            }

            List<int> longestSequence = new List<int>();
            while (lastIndex != -1)
            {
                longestSequence.Add(sequence[lastIndex]);
                lastIndex = prev[lastIndex];

            }

            longestSequence.Reverse();

            return longestSequence.ToArray();
        }
    }
}



