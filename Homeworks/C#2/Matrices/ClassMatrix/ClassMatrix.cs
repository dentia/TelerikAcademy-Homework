// Write a class Matrix, to holds a matrix of integers. 
//Overload the operators for adding, subtracting and 
//multiplying of matrices, indexer for accessing the matrix content and ToString().

namespace ClassMatrix
{
    using System;
    class ClassMatrix
    {
        static void Main(string[] args)
        {
/*
 Input
 * 
 2, 3, 1
 2, -7, 4
 3, 4, 5
 1, 1, 4
 2, 1, 4
 1, 2
 3, 4
 4, 3
 2, 1
 */

            Matrix firstMatrix = new Matrix(2, 3);
            firstMatrix.FillMatrix();
            Matrix secondMatrix = new Matrix(3, 3);
            secondMatrix.FillMatrix();

            Matrix multiplication = firstMatrix * secondMatrix;

            firstMatrix = new Matrix(2, 2);
            firstMatrix.FillMatrix();
            secondMatrix = new Matrix(2, 2);
            secondMatrix.FillMatrix();

            Matrix addition = firstMatrix + secondMatrix;
            Matrix substraction = firstMatrix - secondMatrix;

            Console.Clear();
            Console.WriteLine(@"
Multiplication:
{0}

Addition:
{1}

Substraction:
{2}", multiplication, addition, substraction);
        }
    }
}
