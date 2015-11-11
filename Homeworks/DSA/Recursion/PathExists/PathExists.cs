namespace PathExists
{
    using System;

    public static class PathExists
    {
        private static readonly int[][] Directions =
            {
                new[] { 1, 0 }, 
                new[] { -1, 0 }, 
                new[] { 0, 1 },
                new[] { 0, -1 }
            };

        public static void Main()
        {
            var visited = new bool[100, 100];
            new int[100, 100].PathExistsBetween(visited, 0, 0);
            Console.WriteLine(visited[99, 99]);
        }

        public static void PathExistsBetween(this int[,] maze, bool[,] visited, int y, int x)
        {
            if (!IsInRange(y, x, maze.GetLength(0), maze.GetLength(1)))
            {
                return;
            }

            if (visited[y, x])
            {
                return;
            }

            visited[y, x] = true;

            foreach (var direction in Directions)
            {
                maze.PathExistsBetween(visited, y + direction[0], x + direction[1]);
            }
        }

        private static bool IsInRange(int y, int x, int rows, int cols)
        {
            var rowIsInRange = y >= 0 && y < rows;
            var colIsInRange = x >= 0 && x < cols;

            return rowIsInRange && colIsInRange;
        }
    }
}
