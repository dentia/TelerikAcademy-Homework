// 14. * We are given a labyrinth of size N x N. Some of its
// cells are empty (0) and some are full (x). We can
// move from an empty cell to another empty cell if
// they share common wall. Given a starting position
// (*) calculate and fill in the array the minimal
// distance from this position to any other cell in the
// array. Use "u" for all unreachable cells. Example:

namespace MinimalDistanceMaze
{
    using System;

    class MinimalDistanceMaze
    {
        const int StartPointValue = -2;
        const int InaccessiblePointValue = -1;
        const int AccessiblePointValue = 0;
        static int[,] maze = new int[,]{
                {0, 0, 0, -1, 0, -1},
                {0, -1, 0, -1, 0, -1},
                {0, -2, -1, 0, -1, 0},
                {0, -1, 0, 0, 0, 0},
                {0, 0, 0, -1, -1, 0},
                {0, 0, 0, -1, 0, -1}};

        static void Main()
        {
            int startRow = -1, startCol = -1;

            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    if (maze[row, col] == StartPointValue)
                    {
                        startRow = row;
                        startCol = col;
                        break;
                    }
                }
                if (startRow != InaccessiblePointValue && startCol != InaccessiblePointValue) break;
            }

            FillMaze(startRow, startCol, 1);
            PrintMaze(startRow, startCol);
        }

        private static void PrintMaze(int startRow, int startCol)
        {
            var defaultConsoleColor = Console.ForegroundColor;

            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    if (row == startRow && col == startCol)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("{0,-4}", '*');
                        Console.ForegroundColor = defaultConsoleColor;
                    }
                    else if (maze[row, col] == InaccessiblePointValue)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0,-4}", 'x');
                        Console.ForegroundColor = defaultConsoleColor;
                    }
                    else if (maze[row, col] == AccessiblePointValue)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("{0,-4}", 'u');
                        Console.ForegroundColor = defaultConsoleColor;
                    }
                    else
                    {
                        Console.Write("{0,-4}", maze[row, col] - 1);
                    }
                }
                Console.WriteLine();
            }
        }

        private static void FillMaze(int row, int col, int step)
        {
            if (!IsInRange(row, col, maze.GetLength(0), maze.GetLength(1))) return;
            if (maze[row, col] == InaccessiblePointValue) return;
            if (maze[row, col] != StartPointValue && maze[row, col] != AccessiblePointValue && step > maze[row, col]) return;
            maze[row, col] = step;
            FillMaze(row - 1, col, step + 1);
            FillMaze(row + 1, col, step + 1);
            FillMaze(row, col - 1, step + 1);
            FillMaze(row, col + 1, step + 1);
        }

        private static bool IsInRange(int row, int col, int mazeRow, int mazeCol)
        {
            bool inRowRange = row >= 0 && row < mazeRow;
            bool inColRange = col >= 0 && col < mazeCol;

            return inRowRange && inColRange;
        }
    }
}
