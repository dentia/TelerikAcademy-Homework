namespace Labyrinth
{
    using System;

    using Utils;
    using Utils.Maze;
    using Utils.TextReader;

    public class StartUp
    {
        private const int StartCellValue = -2;
        private const int WallCellValue = -1;
        private const int EmptyCellValue = 0;

        [STAThread]
        public static void Main()
        {
            new[] 
            {
                new[] { "6" },
                new[] { "0 0 0 x 0 x" },
                new[] { "0 x 0 x 0 x" },
                new[] { "0 * x 0 x 0" },
                new[] { "0 x 0 0 0 0" },
                new[] { "0 0 0 x x 0" },
                new[] { "0 0 0 x 0 x" }
            }.CopyMatrixToClipboard();
            Console.WriteLine("The sample input is copied to Your clipboard - just paste it in the console.");

            var reader = new Reader();
            var maze = reader.ReadMatrix();
            FillMazeWithPaths(maze, maze.StartingCell.Row, maze.StartingCell.Col, 1);
            Console.WriteLine(maze);
        }

        private static void FillMazeWithPaths(Maze maze, int row, int col, int step)
        {
            if (!IsInRange(row, col, maze.Rows, maze.Cols))
            {
                return;
            }

            if (maze[row, col] == WallCellValue)
            {
                return;
            }

            if (maze[row, col] != StartCellValue && maze[row, col] != EmptyCellValue && step > maze[row, col])
            {
                return;
            }

            maze[row, col] = step;

            FillMazeWithPaths(maze, row - 1, col, step + 1);
            FillMazeWithPaths(maze, row + 1, col, step + 1);
            FillMazeWithPaths(maze, row, col - 1, step + 1);
            FillMazeWithPaths(maze, row, col + 1, step + 1);
        }

        private static bool IsInRange(int row, int col, int mazeRows, int mazeCols)
        {
            var inRowRange = row >= 0 && row < mazeRows;
            var inColRange = col >= 0 && col < mazeCols;

            return inRowRange && inColRange;
        }
    }
}
