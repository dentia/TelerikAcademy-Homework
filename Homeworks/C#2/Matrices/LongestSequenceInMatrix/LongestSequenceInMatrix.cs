//We are given a matrix of strings of size N x M. 
//Sequences in the matrix we define as sets of several 
//neighbor elements located on the same line, column or diagonal. 
//Write a program that finds the longest sequence of equal strings in the matrix.
/*
   ha   fifi    ho  hi
   fo   ha      hi  xx
   xxx  ho      ha  xx      
                        * -> ha, ha, ha
   ____________________________
   s    qq  s
   pp   pp  s
   pp   qq  s              
                        * -> s, s, s   
 */


namespace LongestSequenceInMatrix
{
    using System;
    using System.Linq;
    class LongestSequenceInMatrix
    {
        static string bestSequence = String.Empty;
        static int bestCount = 0;
        static string[,] matrix;
        static void Main(string[] args)
        {

            GetMatrixFromConsole();
            Console.Clear();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    CheckForSequence(matrix, row, col);
                }
            }
            Console.WriteLine(bestSequence);

        }

        private static void CheckForSequence(string[,] matrix, int row, int col)
        {
            int diagonal = CheckDiagonal(matrix, row, col);
            int right = CheckRight(matrix, row, col);
            int down = CheckDown(matrix, row, col);

            if (diagonal > bestCount || 
                right > bestCount || 
                down > bestCount)
            {
                bestCount = Math.Max(Math.Max(right, diagonal), down);
                bestSequence = string.Join(", ", 
                    Enumerable
                    .Repeat(matrix[row, col], bestCount)
                    .ToArray());
            }
        }

        private static int CheckDown(string[,] matrix, int row, int col)
        {
            int count = 0;
            string checkString = matrix[row, col];
            for (int i = row; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] == checkString)
                    ++count;
                else
                    break;
            }
            return count;
        }

        private static int CheckRight(string[,] matrix, int row, int col)
        {
            int count = 0;
            string checkString = matrix[row, col];
            for (int j = col; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] == checkString)
                    ++count;
                else
                    break;
            }
            return count;
        }

        private static int CheckDiagonal(string[,] matrix, int row, int col)
        {
            int count = 0;
            string checkString = matrix[row, col];
            for (int i = row, j = col; i < matrix.GetLength(0) && j < matrix.GetLength(1); i++, j++)
            {
                if (matrix[i, j] == checkString)
                    ++count;
                else 
                    break;
            }

            return count;
        }

        private static void GetMatrixFromConsole()
        {
            Console.Write("Enter matrix rows: ");
            int rowCount = int.Parse(Console.ReadLine());
            Console.Write("Enter matrix columns: ");
            int colCount = int.Parse(Console.ReadLine());
            matrix = new string[rowCount, colCount];

            Console.WriteLine("Enter each row on separate line, where the numbers are separated by space: ");
            string[] tempRow;
            for (int i = 0; i < rowCount; i++)
            {
                tempRow = Console.ReadLine()
                    .Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x)
                    .ToArray();

                if (tempRow.Length != colCount)
                {
                    Console.WriteLine("The numbers you entered are more or less than the array size.");
                    Environment.Exit(0);
                }
                for (int j = 0; j < colCount; j++)
                {
                    matrix[i, j] = tempRow[j];
                }
            }

            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,5}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
