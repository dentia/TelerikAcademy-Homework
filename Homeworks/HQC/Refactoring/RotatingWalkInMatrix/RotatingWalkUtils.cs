namespace RotatingWalkInMatrix
{
    using System;

    public static class RotatingWalkUtils
    {
        private const int DirectionsCount = 8;
        private static readonly int[] RowChange = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static readonly int[] ColChange = { 1, 0, -1, -1, -1, 0, 1, 1 };

        public static bool NeighboursAreFilled(this int[,] matrix, int row, int col)
        {
            int upperRow = row > 0 ? row - 1 : row;
            int lowerRow = row < matrix.GetLength(0) - 1 ? row + 1 : row;
            int leftCol = col > 0 ? col - 1 : col;
            int rightCol = col < matrix.GetLength(1) - 1 ? col + 1 : col;

            for (int r = upperRow; r <= lowerRow; r++)
            {
                for (int c = leftCol; c <= rightCol; c++)
                {
                    if (matrix[r, c] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static Coordinates GetStartingPosition(this int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        return new Coordinates(row, col);
                    }
                }
            }

            return null;
        }

        public static bool CanContinueInDirection(this int[,] matrix, int row, int col)
        {
            if (!matrix.IsInRange(row, col))
            {
                return false;
            }

            if (matrix[row, col] != 0)
            {
                return false;
            }

            return true;
        }

        public static Direction GetNextDirection(this int[,] matrix, Direction direction, int row, int col)
        {
            for (int i = 0; i < DirectionsCount; i++)
            {
                Direction currentDirection = (Direction)(((int)direction + i) % DirectionsCount);
                int currentRow = row + GetRowChange(currentDirection);
                int currentCol = col + GetColChange(currentDirection);
                if (matrix.CanContinueInDirection(currentRow, currentCol))
                {
                    return currentDirection;
                }
            }

            throw new InvalidOperationException("The matrix is filled.");
        }

        public static int GetRowChange(Direction direction)
        {
            return RowChange[(int)direction];
        }

        public static int GetColChange(Direction direction)
        {
            return ColChange[(int)direction];
        }

        private static bool IsInRange(this int[,] matrix, int row, int col)
        {
            bool rowIsInRange = row >= 0 && row < matrix.GetLength(0);
            bool colIsInRange = col >= 0 && col < matrix.GetLength(1);

            return rowIsInRange && colIsInRange;
        }
    }
}
