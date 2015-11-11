namespace LargestAreaOfEmtyCells
{
    using System;

    public class LargestAreaOfEmtyCells
    {
        private static readonly int[][] Directions =
            {
                new[] { 1, 0 }, 
                new[] { -1, 0 }, 
                new[] { 0, 1 }, 
                new[] { 0, -1 },
            };

        public static void Main()
        {
            var maze = new bool[10, 10];
            PopulateMaze(maze);

            Console.WriteLine(FindLargestPath(maze));
        }

        public static void PopulateMaze(bool[,] maze)
        {
            maze[0, 3] = true;
            maze[1, 3] = true;
            maze[2, 3] = true;

            for (int col = 0; col <= 3; col++)
            {
                maze[3, col] = true;
            }
        }

        public static int FindLargestPath(bool[,] maze)
        {
            var visited = new bool[maze.GetLength(0), maze.GetLength(1)];
            var maxCount = 0;

            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    if (!visited[row, col])
                    {
                        var currentCount = 0;

                        CountAdjacentCells(maze, visited, row, col, ref currentCount);

                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                        }
                    }
                }
            }

            return maxCount;
        }

        private static void CountAdjacentCells(bool[,] maze, bool[,] visited, int row, int col, ref int count)
        {
            if (!IsInRange(row, col, maze.GetLength(0), maze.GetLength(1)))
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            if (maze[row, col])
            {
                return;
            }

            ++count;
            visited[row, col] = true;

            foreach (var direction in Directions)
            {
                CountAdjacentCells(maze, visited, row + direction[0], col + direction[1], ref count);
            }
        }

        private static bool IsInRange(int row, int col, int rows, int cols)
        {
            var rowIsInRange = row >= 0 && row < rows;
            var colIsInRange = col >= 0 && col < cols;

            return rowIsInRange && colIsInRange;
        }
    }
}
