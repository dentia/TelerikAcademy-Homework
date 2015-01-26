//Write a program that reads a rectangular matrix 
//of size N x M and finds in it the square 3 x 3 
//that has maximal sum of its elements.

namespace MaxSumInMatrix
{
    using System;
    using System.Linq;
    class MaxSumInMatrix
    {
        const int SUBMATRIX_SIZE = 3;
        static int[,] matrix;
        static void Main(string[] args)
        {
            GetMatrixFromConsole();
/*
    7
    8
    1, -2, 4, 1, -3, 5, 6, -3
    4, 1, 2, -6, 7, 2, -5, 1
    3, 1, -4, 3, 6, 1, 2, -2
    -3, 4, -2, 1, 1, 0, 2, 1
    -4, 5, 2, 1, 3, -2, 1, 3
    5, 2, 1, 3, -4, 5, 1, 3
    2, -3, 4, 2, 1, 2, -1, 5
*/
            //PrintWorkMatrix(matrix);
            Console.Clear();

            int lastRowIndex = int.MinValue;
            int lastColIndex = int.MinValue;
            int maxSum = int.MinValue;

            int[,] sumRows = (int[,])matrix.Clone();
            sumRows = CalculateRowSums(matrix, sumRows);

            int[,] submatrixSum = new int[matrix.GetLength(0), matrix.GetLength(1)];
            CalculateSubmatrixSum
                (sumRows, ref lastRowIndex, ref lastColIndex, ref maxSum, ref submatrixSum);

            PrintSubmatrix(matrix, lastRowIndex, lastColIndex, maxSum);
        }

        private static void PrintSubmatrix(int[,] matrix, int x, int y, int maxSum)
        {
            bool first;
            Console.WriteLine("The best sum is: " + maxSum);
            for (int row = y - SUBMATRIX_SIZE + 1; row <= y; row++)
            {
                first = true;
                Console.Write("[");
                for (int col = x - SUBMATRIX_SIZE + 1; col <= x; col++)
                {
                    if (!first) 
                        Console.Write(",");
                    Console.Write("{0,4}", matrix[row, col]);
                    first = false;
                }
                Console.Write("]");
                Console.WriteLine();
            }
        }

        private static void CalculateSubmatrixSum
            (int[,] sumRows, ref int x, ref int y, ref int best, ref int[,] subMatrixSum)
        {
            for (int col = 4; col < subMatrixSum.GetLength(1); col++)
            {
                int sum = sumRows[3, col] + sumRows[2, col];
                for (int row = 4, k = 1; row < subMatrixSum.GetLength(0); row++, k++)
                {
                    sum += sumRows[row, col] - sumRows[k, col];
                    subMatrixSum[row, col] = sum;
                    if (sum > best)
                    {
                        best = sum;
                        x = col;
                        y = row;
                    }
                }
            }
        }

        private static int[,] CalculateRowSums(int[,] matrix, int[,] sumRows)
        {
            for (int row = 2; row < sumRows.GetLength(0); row++)
            {
                int sum = matrix[row, 2];
                for (int col = 3, k = 0; col < sumRows.GetLength(1); col++, k++)
                {
                    sum += matrix[row, col] - matrix[row, k];
                    sumRows[row, col] = sum;
                }
            }

            return sumRows;
        }

        private static void GetMatrixFromConsole()
        {
            Console.Write("Enter matrix rows: ");
            int rowCount = int.Parse(Console.ReadLine());
            Console.Write("Enter matrix columns: ");
            int colCount = int.Parse(Console.ReadLine());
            matrix = new int[rowCount + 2, colCount + 2];

            if (rowCount < SUBMATRIX_SIZE || colCount < SUBMATRIX_SIZE)
            {
                Console.WriteLine("The size of the matrix is too small.");
                Environment.Exit(0);
            }

            Console.WriteLine("Enter each row on separate line and the numbers, separated by a comma: ");
            int[] tempRow;
            for (int currentRow = 2; currentRow < rowCount + 2; currentRow++)
            {
                tempRow = Console.ReadLine()
                    .Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();

                if (tempRow.Length != colCount)
                {
                    Console.WriteLine("The numbers you entered are more or less than the array size.");
                    Environment.Exit(0);
                }
                for (int currentCol = 2; currentCol < colCount + 2; currentCol++)
                {
                    matrix[currentRow, currentCol] = tempRow[currentCol - 2];
                }
            }

           // PrintWorkMatrix(matrix);
        }

        private static void PrintWorkMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,4}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
