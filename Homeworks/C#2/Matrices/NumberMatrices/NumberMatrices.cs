//Write a program that fills and prints a matrix of size 
//(n, n) as shown below: (examples for n = 3)
/*
 *A 1 4 7     B 1 6 7     C 4 7 9     D 1 8 7
 *  2 5 8       2 5 8       2 5 8       2 9 6
 *  3 6 9       3 4 9       1 3 6       3 4 5
 */

namespace NumberMatrices
{
    using System;
    class NumberMatrices
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size: ");
            int size = int.Parse(Console.ReadLine());

            NumberMatrixGenerator matrixGenerator = 
                new NumberMatrixGenerator(size);

            PrintMatrix(matrixGenerator.GetMatrix(MatrixType.Type_A), MatrixType.Type_A);
            PrintMatrix(matrixGenerator.GetMatrix(MatrixType.Type_B), MatrixType.Type_B);
            PrintMatrix(matrixGenerator.GetMatrix(MatrixType.Type_C), MatrixType.Type_C);
            PrintMatrix(matrixGenerator.GetMatrix(MatrixType.Type_D), MatrixType.Type_D);
        }

        private static void PrintMatrix(int[,] matrix, MatrixType type)
        {
            Console.WriteLine(type + "\n");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0, -4}", matrix[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(new String('_', matrix.GetLength(0) * 5));
        }
    }
}
