// Write a class Matrix, to holds a matrix of integers. 
//Overload the operators for adding, subtracting and 
//multiplying of matrices, indexer for accessing the matrix content and ToString().

namespace ClassMatrix
{
    using System;
    class Test
    {
        static void Main(string[] args)
        {
            Matrix<int> firstMatrix = new Matrix<int>(2, 3);
            Matrix<int> secondMatrix = new Matrix<int>(3, 3);

            FillFirstMatrix_Multiplication(firstMatrix);
            FillSecondMatrix_Multiplication(secondMatrix);

            Matrix<int> multiplication = firstMatrix * secondMatrix;

            firstMatrix = new Matrix<int>(2, 2);
            secondMatrix = new Matrix<int>(2, 2);

            FillFirstMatrix_Add_Substract(firstMatrix);
            FillSecondMatrix_Add_Substract(secondMatrix);

            Matrix<int> addition = firstMatrix + secondMatrix;
            Matrix<int> substraction = firstMatrix - secondMatrix;

            Console.Clear();
            Console.WriteLine(@"
Multiplication:
{0}

Addition:
{1}

Substraction:
{2}", multiplication, addition, substraction);
        }

        private static void FillSecondMatrix_Add_Substract(Matrix<int> secondMatrix)
        {
            int[,] sMatrix = new int[,] { { 4, 3 }, { 2, 1 } };
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    secondMatrix[row, col] = sMatrix[row, col];
                }
            }
        }

        private static void FillFirstMatrix_Add_Substract(Matrix<int> firstMatrix)
        {
            int[,] fMatrix = new int[,] { { 1, 2 }, { 3, 4 } };
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    firstMatrix[row, col] = fMatrix[row, col];
                }
            }
        }

        private static void FillSecondMatrix_Multiplication(Matrix<int> secondMatrix)
        {
            int[,] sMatrix = new int[,] { { 3, 4, 5 }, { 1, 1, 4 }, { 2, 1, 4 } };
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    secondMatrix[row, col] = sMatrix[row, col];
                }
            }
        }

        private static void FillFirstMatrix_Multiplication(Matrix<int> firstMatrix)
        {
            int[,] fMatrix = new int[,] { { 2, 3, 1 }, { 2, -7, 4 } };
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    firstMatrix[row, col] = fMatrix[row, col];
                }
            }
        }
    }
}
