using System;
using System.Collections.Generic;

class SequenceInMatrix
{
    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        int columns = int.Parse(Console.ReadLine());
        string[,] matrix = new string[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            string[] currentStringRow = Console.ReadLine().Split(' ');
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = currentStringRow[j];
            }
        }
        List<string> maxSequenceInRows = MaxSequenceInRows(matrix);
        List<string> maxSequenceInColumns = MaxSequenceInColumns(matrix);
        List<string> maxSequenceInDiagonals = MaxSequenceInDiagonal(matrix);
        if (maxSequenceInRows.Count >= maxSequenceInColumns.Count && maxSequenceInRows.Count >= maxSequenceInDiagonals.Count)
        {
            Console.WriteLine(string.Join(", ", maxSequenceInRows));
        }
        else if (maxSequenceInColumns.Count >= maxSequenceInRows.Count && maxSequenceInColumns.Count >= maxSequenceInDiagonals.Count)
        {
            Console.WriteLine(string.Join(", ", maxSequenceInColumns));
        }
        else if (maxSequenceInDiagonals.Count >= maxSequenceInRows.Count && maxSequenceInDiagonals.Count >= maxSequenceInColumns.Count)
        {
            Console.WriteLine(string.Join(", ", maxSequenceInDiagonals));
        }
    }

    private static List<string> MaxSequenceInRows(string[,] matrix)
    {
        List<string> maxSequenceInRows = new List<string>();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            List<string> currentSequence = new List<string>();
            currentSequence.Add(matrix[i, 0]);
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (!currentSequence[0].Equals(matrix[i, j]))
                {
                    if (currentSequence.Count > maxSequenceInRows.Count)
                    {
                        maxSequenceInRows.Clear();
                        maxSequenceInRows = CopyList(maxSequenceInRows, currentSequence);
                    }
                    currentSequence.Clear();
                }
                currentSequence.Add(matrix[i, j]);
            }
            if (currentSequence.Count > maxSequenceInRows.Count)
            {
                maxSequenceInRows.Clear();
                maxSequenceInRows = CopyList(maxSequenceInRows, currentSequence);
            }
        }
        return maxSequenceInRows;
    }

    private static List<string> MaxSequenceInColumns(string[,] matrix)
    {
        List<string> maxSequenceInColumns = new List<string>();
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            List<string> currentSequence = new List<string>();
            currentSequence.Add(matrix[0, i]);
            for (int j = 1; j < matrix.GetLength(0); j++)
            {
                if (!currentSequence[0].Equals(matrix[j, i]))
                {
                    if (currentSequence.Count > maxSequenceInColumns.Count)
                    {
                        maxSequenceInColumns.Clear();
                        maxSequenceInColumns = CopyList(maxSequenceInColumns, currentSequence);
                    }
                    currentSequence.Clear();
                }
                currentSequence.Add(matrix[j, i]);
            }
            if (currentSequence.Count > maxSequenceInColumns.Count)
            {
                maxSequenceInColumns.Clear();
                maxSequenceInColumns = CopyList(maxSequenceInColumns, currentSequence);
            }
        }
        return maxSequenceInColumns;
    }

    private static List<string> MaxSequenceInDiagonal(string[,] matrix)
    {
        List<string> maxSequenceInDiagonal = new List<string>();
        List<string> currentSequence = new List<string>();
        currentSequence.Add(matrix[0, 0]);
        int currentRow = 1;
        int currentColumn = 1;
        int rowReached = 0;
        int columnReached = 0;
        do
        {
            if (rowReached >= matrix.GetLength(0) - 1)
            {
                break;
            }
            if (currentRow > matrix.GetLength(0) - 1)
            {
                currentRow = rowReached;
                columnReached++;
                currentColumn = columnReached;
            }
            else if (currentColumn >= matrix.GetLength(1))
            {
                if (columnReached >= matrix.GetLength(1) - 1)
                {
                    rowReached++;
                    columnReached = 0;
                }
                else
                {
                    columnReached++;
                }
                currentRow = rowReached;
                currentColumn = columnReached;
            }
            else
            {
                if (!currentSequence[0].Equals(matrix[currentRow, currentColumn]))
                {
                    if (currentSequence.Count > maxSequenceInDiagonal.Count)
                    {
                        maxSequenceInDiagonal.Clear();
                        maxSequenceInDiagonal = CopyList(maxSequenceInDiagonal, currentSequence);
                    }
                    currentSequence.Clear();
                }
                currentSequence.Add(matrix[currentRow, currentColumn]);
                currentColumn++;
                currentRow++;
            }
        }
        while (true);
        return maxSequenceInDiagonal;
    }

    private static List<string> CopyList(List<string> stringCopiedInto, List<string> stringBeingCopied)
    {
        foreach (var stringPart in stringBeingCopied)
        {
            stringCopiedInto.Add(stringPart);
        }
        return stringCopiedInto;
    }
}
