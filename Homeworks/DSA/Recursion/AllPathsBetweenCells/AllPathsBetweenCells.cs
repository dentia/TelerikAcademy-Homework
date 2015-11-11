namespace AllPathsBetweenCells
{
    using System;
    using System.Collections.Generic;

    public static class AllPathsBetweenCells
    {
        private const int EmptyCell = 0;
        private const int VisitedCell = 1;

        private static readonly Vector[] Directions =
            {
                new Vector(0, 1), 
                new Vector(0, -1), 
                new Vector(1, 0),
                new Vector(-1, 0)
            };

        public static void Main()
        {
            var maze = new[,]
                           {
                               { 0, 0, -1, 0 }, 
                               { 0, 0, 0, -1 }, 
                               { 0, 0, -1, 0 }, 
                               { -1, 0, 0, 0 }
                           };
            var result = new List<LinkedList<Vector>>();
            result.PutAllPaths(new Vector(3, 3), new Vector(0, 0), new LinkedList<Vector>(), maze);

            foreach (var path in result)
            {
                Console.WriteLine(string.Join(", ", path));
            }
        }

        public static void PutAllPaths(this List<LinkedList<Vector>> allPaths, Vector toPont, Vector position, LinkedList<Vector> path, int[,] maze)
        {
            if (maze[position.Y, position.X] != EmptyCell)
            {
                return;
            }

            maze[position.Y, position.X] = VisitedCell;
            path.AddLast((Vector)position.Clone());

            if (position.CompareTo(toPont) == 0)
            {
                allPaths.Add(new LinkedList<Vector>(path));
            }
            else
            {
                foreach (var direction in Directions)
                {
                    if (IsInRange(
                        position.Y + direction.Y,
                        position.X + direction.X,
                        maze.GetLength(0),
                        maze.GetLength(1)))
                    {
                        allPaths.PutAllPaths(
                            toPont,
                            new Vector(y: position.Y + direction.Y, x: position.X + direction.X),
                            path,
                            maze);
                    }
                }
            }

            path.RemoveLast();
            maze[position.Y, position.X] = EmptyCell;
        }

        private static bool IsInRange(int y, int x, int rows, int cols)
        {
            var rowIsInRange = y >= 0 && y < rows;
            var colIsInRange = x >= 0 && x < cols;

            return rowIsInRange && colIsInRange;
        }
    }
}
