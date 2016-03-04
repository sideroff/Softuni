namespace _03_Longest_Subsequence
{
    using System.Collections.Generic;
    using System.Text;

    public class Sequence_Finder
    {
        public string Get_Longest_Sequence(List<int> list)
        {
            int longestSequenceStartIndex = 0;
            int longestSequenceEndIndex = 1;
            long longestSequenceLenght = 1;

            for (int i = 0; i < list.Count - 1; i++)
            {

                if (list[i] == list[i + 1])
                {
                    int currentLongestSequenceStartIndex = i;
                    int currentLongestSequenceEndIndex = i + 1;
                    for (int j = i; j < list.Count - 1; j++)
                    {
                        if (list[j] == list[j + 1])
                        {
                            currentLongestSequenceEndIndex++;
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    long currentLongestSequenceLenght = currentLongestSequenceEndIndex
                                                   - currentLongestSequenceStartIndex;
                    if (currentLongestSequenceLenght > longestSequenceLenght)
                    {
                        longestSequenceStartIndex = currentLongestSequenceStartIndex;
                        longestSequenceEndIndex = currentLongestSequenceEndIndex;
                        longestSequenceLenght = currentLongestSequenceLenght;
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int i = longestSequenceStartIndex; i < longestSequenceEndIndex; i++)
            {
                sb.Append(list[i] + " ");
            }

            return sb.ToString().TrimEnd();
        }
    }
}