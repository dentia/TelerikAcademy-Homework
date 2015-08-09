namespace Exam_LoverOf3
{
    using System;
    using System.Linq;

    internal class MatrixCoordinates
    {
        public MatrixCoordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }

    internal class LoverOf3
    {
        private const int BaseValue = 3;

        internal static void Main()
        {
            MatrixCoordinates dimensions = GetDimensions();
            bool[,] field = new bool[dimensions.Row, dimensions.Col];
            int directionChangesCount = int.Parse(Console.ReadLine());

            TraverseField(dimensions, field, directionChangesCount);

            long result = GetSum(field);
            Console.WriteLine(result);
        }

        private static void TraverseField(MatrixCoordinates size, bool[,] field, int directionChangesCount)
        {
            MatrixCoordinates position = new MatrixCoordinates(field.GetLength(0) - 1, 0);

            field[position.Row, position.Col] = true;

            for (int i = 0; i < directionChangesCount; i++)
            {
                string[] command = GetCommand();
                int moves = int.Parse(command[1]);

                MatrixCoordinates dirChange = GetDirChange(command[0]);

                for (int move = 0; move < moves - 1; move++)
                {
                    if (!IsInRange(size, position.Row + dirChange.Row, position.Col + dirChange.Col))
                    {
                        break;
                    }

                    position.Row += dirChange.Row;
                    position.Col += dirChange.Col;

                    field[position.Row, position.Col] = true;
                }
            }
        }

        private static MatrixCoordinates GetDirChange(string direction)
        {
            switch (direction)
            {
                case "UL":
                case "LU":
                    return new MatrixCoordinates(-1, -1);
                case "UR":
                case "RU":
                    return new MatrixCoordinates(-1, 1);
                case "DL":
                case "LD":
                    return new MatrixCoordinates(1, -1);
                case "DR":
                case "RD":
                    return new MatrixCoordinates(1, 1);
                default:
                    throw new ArgumentException("Invalid direction.");
            }
        }

        private static bool IsInRange(MatrixCoordinates size, int row, int col)
        {
            bool rowIsInRange = row > -1 && row < size.Row;
            bool colIsInRange = col > -1 && col < size.Col;

            return rowIsInRange && colIsInRange;
        }

        private static string[] GetCommand()
        {
            string[] command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return command;
        }

        private static MatrixCoordinates GetDimensions()
        {
            int[] size = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            return new MatrixCoordinates(size[0], size[1]);
        }

        private static long GetSum(bool[,] field)
        {
            long sum = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col])
                    {
                        sum += (field.GetLength(0) - row - 1) * BaseValue + (col * BaseValue);
                    }
                }
            }

            return sum;
        }
    }
}