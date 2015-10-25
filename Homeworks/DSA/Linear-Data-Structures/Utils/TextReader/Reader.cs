namespace Utils.TextReader
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Utils.Maze;

    public class Reader : IReader<int>
    {
        private readonly TextReader reader;

        public Reader()
            : this(Console.In)
        {
        }

        public Reader(TextReader reader)
        {
            this.reader = reader;
        }

        public IEnumerable<int> ReadList(Predicate<string> shouldStopReading, Predicate<string> isValidEntry)
        {
            var result = new List<int>();

            using (this.reader)
            {
                while (true)
                {
                    var input = this.reader.ReadLine();

                    if (shouldStopReading(input))
                    {
                        break;
                    }
                    else if (!isValidEntry(input))
                    {
                        throw new ArgumentException("Invalid entry.");
                    }
                    else
                    {
                        result.Add(int.Parse(input));
                    }
                }
            }

            return result;
        }

        public int ReadOne()
        {
            return int.Parse(this.reader.ReadLine());
        }

        public Maze ReadMatrix()
        {
            var size = this.ReadOne();
            var maze = new Maze(size, size);

            for (int row = 0; row < size; row++)
            {
                var currentRow = this.ReadRow();
                if (currentRow.Length != size)
                {
                    throw new ArgumentException("Invalid columns size.");
                }

                var currentCol = currentRow.Select(
                    x =>
                        {
                            switch (x)
                            {
                                case "x":
                                    return -1;
                                case "0":
                                    return 0;
                                case "*":
                                    return -2;
                                default:
                                    throw new ArgumentException("Invalid symbol.");
                            }
                        }).ToArray();

                for (int col = 0; col < size; col++)
                {
                    if (currentCol[col] == -2)
                    {
                        maze.StartingCell = new Coordinates(row, col);
                    }

                    maze[row, col] = currentCol[col];
                }
            }

            return maze;
        }

        private string[] ReadRow()
        {
            return this.reader.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
    }
}
