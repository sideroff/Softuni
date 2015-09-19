using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SequencesInMatrices
{
    class Program
    {
        static string[] biggest = new string[5];
        static string[] tempBiggest = new string[5];
        static string[,] matrix =
        {
            {"ha","ha","ha","ba", },
            {"ba","ha","ea","ra", },
            {"ha","ha","ha","ha", }
        };
        static void Main(string[] args)
        {
            biggest[4] = 0.ToString();
            //int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    string[] input = Console.ReadLine().Split(' ');
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        matrix[i, j] = input[j];
            //    }
            //}

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    tempBiggest[0] = i.ToString();
                    tempBiggest[1] = j.ToString();
                    tempBiggest[3] = matrix[i, j];
                    tempBiggest[4] = 0.ToString();
                    if(j+1!=matrix.GetLength(1))
                    {
                        if (matrix[i, j] == matrix[i, j + 1])
                        {

                            tempBiggest[2] = "H"; //H for Horizontal
                            tempBiggest[4] = (int.Parse(tempBiggest[4]) + 1).ToString();
                            int br = 1;
                            while ((matrix[i, j] == matrix[i, j + br]) && (j + br) < matrix.GetLength(0))
                            {
                                tempBiggest[4] = (int.Parse(tempBiggest[4]) + 1).ToString();
                                br++;
                            }
                            if (int.Parse(biggest[4]) < int.Parse(tempBiggest[4]))
                            {
                                SubmitBiggest(biggest, tempBiggest);
                            }
                            tempBiggest[4] = 0.ToString();

                        }

                        if (matrix[i, j] == matrix[i + 1, j + 1])
                        {

                            tempBiggest[2] = "D"; //D for diagonal
                            tempBiggest[4] = (int.Parse(tempBiggest[4]) + 1).ToString();
                            int br = 1;
                            while ((matrix[i, j] == matrix[i + 1, j + 1]) && ((i + br) < matrix.GetLength(1)) && (j + br < matrix.GetLength(0)))
                            {
                                tempBiggest[4] = (int.Parse(tempBiggest[4]) + 1).ToString();
                                br++;
                            }
                            if (int.Parse(biggest[4]) < int.Parse(tempBiggest[4]))
                            {
                                SubmitBiggest(biggest, tempBiggest);
                            }
                            tempBiggest[4] = 0.ToString();
                        }
                    }
                    
                    if (matrix[i, j] == matrix[i+1, j])
                    {

                        tempBiggest[2] = "V"; // V for vertical
                        int br = 1;
                        while ((matrix[i, j] == matrix[i+1, j]) && (i + br) < matrix.GetLength(1))
                        {
                            tempBiggest[4] = (int.Parse(tempBiggest[4]) + 1).ToString();
                            br++;
                        }
                        if (int.Parse(biggest[4]) < int.Parse(tempBiggest[4]))
                        {
                            SubmitBiggest(biggest, tempBiggest);
                        }
                        tempBiggest[4] = 0.ToString();

                    }


                }
            }
            PrintBiggest(biggest);

        }

        private static void CheckHorizontal(string[,] matrix)
        {
            throw new NotImplementedException();
        }

        private static void PrintBiggest(string[] biggest)
        {

                PrintInfo(biggest);
                for (int j = 0; j < int.Parse(biggest[4]); j++)
                    {
                    Console.Write(biggest[3]);
                    }
                Console.WriteLine();
            
        }

        private static void PrintInfo(string[] biggest)
        {
            Console.WriteLine("The biggest sequence in the matrix is as follows:");
            Console.WriteLine("Starting index: matrix[{0},{1}]; string: {2}, number of times appearing: {3}", biggest[1], biggest[2], biggest[4]);
            Console.WriteLine("Sequence:");
        }

        private static void SubmitBiggest(string[] biggest, string[] tempBiggest)
        {
            biggest[0] = tempBiggest[0];
            biggest[1] = tempBiggest[1];
            biggest[2] = tempBiggest[2];
            biggest[3] = tempBiggest[3];
            biggest[4] = tempBiggest[4];
        }
    }
}
