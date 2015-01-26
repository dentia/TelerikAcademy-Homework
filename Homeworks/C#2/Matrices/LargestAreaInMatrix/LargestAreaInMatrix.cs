//Write a program that finds the largest area of equal 
//neighbor elements in a rectangular matrix and prints its size.

namespace LargestAreaInMatrix
{
    using System;
    using System.Collections.Generic;
    class LargestAreaInMatrix
    {
        static void Main(string[] args)
        {
            char[,] matrix =   {{ '*', '*', '*', '*', '*', '*', '*', '*'},
                                { '*', '1', '3', '2', '2', '2', '4', '*'},
                                { '*', '3', '3', '3', '2', '4', '4', '*'},
                                { '*', '4', '3', '1', '2', '3', '3', '*'},
                                { '*', '4', '3', '1', '3', '3', '1', '*'},
                                { '*', '4', '3', '3', '3', '1', '1', '*'},
                                { '*', '*', '*', '*', '*', '*', '*', '*'}};

            bool[,] visitedCells = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            VisitFrameCells(visitedCells);

            Queue<Coordinates> queue = new Queue<Coordinates>();

            int lonest = 0;
            int tempLength;

            for (int x = 1; x < matrix.GetLength(0) - 1; x++)
            {
                for (int y = 1; y < matrix.GetLength(1) - 1; y++)
                {
                    tempLength = 1;

                    queue.Enqueue(new Coordinates(x, y));
                    visitedCells[x, y] = true;

                    while (queue.Count > 0)
                    {
                        Coordinates temp = queue.Dequeue();

                        for (int tempX = temp.X - 1; tempX <= temp.X + 1; tempX++)
                        {
                            for (int tempY = temp.Y - 1; tempY <= temp.Y + 1; tempY++)
                            {
                                if (!visitedCells[tempX, tempY] && 
                                   (matrix[tempX, tempY] == matrix[temp.X, temp.Y])) 
                                {
                                    queue.Enqueue(new Coordinates(tempX, tempY));
                                    visitedCells[tempX, tempY] = true;
                                    ++tempLength;
                                }
                            }
                        }
                    }

                    if (tempLength > lonest) lonest = tempLength;
                }
            }

            Console.Clear();
            Console.WriteLine("The longest area in this matrix contains {0} equal elements.", lonest);
        }

        private static void VisitFrameCells(bool[,] visitedCells)
        {
            for (int i = 0; i < visitedCells.GetLength(0); i++) 
                if (i == 0 || i == visitedCells.GetLength(0) - 1)
                {
                    for (int j = 0; j < visitedCells.GetLength(1); j++) 
                        if (j == 0 || j == visitedCells.GetLength(1) - 1)
                        {
                            visitedCells[i, j] = true;
                        }
                }
        }
    }
}
