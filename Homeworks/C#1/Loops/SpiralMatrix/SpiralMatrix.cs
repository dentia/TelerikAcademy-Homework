//Write a program that reads from the console a positive integer number n 
//(1 = n = 20) and prints a matrix holding the numbers from 1 to n*n in 
//the form of square spiral like in the examples below.

using System;
namespace SpiralMatrix
{
    class SpiralMatrix
    {
        static void Main(string[] args)
        {
            Console.Write("Enter matrix size: ");
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            var position = new Pair<int, int>(0, 0);
            var direction = Direction.Right;
            bool nextMoveIsPossible;
            int number = 1;

            while (number <= size * size)
            {
                matrix[position.Height, position.Width] = number;

                nextMoveIsPossible = NextMoveIsPossible(size, matrix, position, direction);
                if (!nextMoveIsPossible)
                {
                    direction = ChangeDirection(direction);
                }

                position = MoveCell(position, direction);
                ++number;
            }

            PrintMatrix(size, matrix);
        }

        private static void PrintMatrix(int size, int[,] matrix)
        {
            for (int height = 0; height < size; height++)
            {
                for (int width = 0; width < size; width++)
                {
                    Console.Write("{0,-5}", matrix[height, width]);
                }
                Console.WriteLine();
            }
        }

        private static Pair<int, int> MoveCell(Pair<int, int> position, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    position.Height -= 1;
                    break;
                case Direction.Right:
                    position.Width += 1;
                    break;
                case Direction.Down:
                    position.Height += 1;
                    break;
                case Direction.Left:
                    position.Width -= 1;
                    break;
            }
            return position;
        }

        private static Direction ChangeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return Direction.Right;
                case Direction.Right:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Left;
                case Direction.Left:
                    return Direction.Up;
                default: throw new Exception("Invalid direction");
            }
        }

        private static bool NextMoveIsPossible(int size, int[,] matrix, Pair<int, int> position, Direction direction)
        {
            bool nextMoveIsPossible;
            switch (direction)
            {
                case Direction.Up:
                    nextMoveIsPossible = position.Height - 1 >= 0 && matrix[position.Height - 1, position.Width] == 0;
                    break;
                case Direction.Right:
                    nextMoveIsPossible = position.Width + 1 < size && matrix[position.Height, position.Width + 1] == 0;
                    break;
                case Direction.Down:
                    nextMoveIsPossible = position.Height + 1 < size && matrix[position.Height + 1, position.Width] == 0;
                    break;
                case Direction.Left:
                    nextMoveIsPossible = position.Width - 1 >= 0 && matrix[position.Height, position.Width - 1] == 0;
                    break;
                default: throw new Exception("Invalid direction");
            }
            return nextMoveIsPossible;
        }
    }
}
