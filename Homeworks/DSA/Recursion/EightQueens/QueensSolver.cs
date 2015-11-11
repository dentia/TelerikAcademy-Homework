namespace EightQueens
{
    using System;

    public class QueensSolver
    {
        private readonly byte[,] board;

        public QueensSolver(int fieldSize)
        {
            this.board = new byte[fieldSize, fieldSize];
            this.SolutionsCount = 0;
        }

        public int SolutionsCount { get; private set; }

        public void FindAllSolutions()
        {
            this.FindSolution(0);
        }

        public void Print()
        {
            for (int row = 0; row < this.board.GetLength(0); row++)
            {
                for (int col = 0; col < this.board.GetLength(1); col++)
                {
                    Console.Write(this.board[row, col] == 4 ? "*" : ".");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private void FindSolution(int row)
        {
            if (row == this.board.GetLength(0))
            {
                ++this.SolutionsCount;
                this.Print();
                return;
            }

            for (int col = 0; col < this.board.GetLength(1); col++)
            {
                if (this.board[row, col] == 0)
                {
                    this.board[row, col] += 1;
                    this.MarkQueen(row, col);

                    this.FindSolution(row + 1);

                    this.board[row, col] -= 1;
                    this.UnmarkQueen(row, col);
                }
            }
        }

        private void UnmarkQueen(int row, int col)
        {
            for (int r = row; r < this.board.GetLength(0); r++)
            {
                this.board[r, col] -= 1;

                if (col + (r - row) < this.board.GetLength(0))
                {
                    this.board[r, col + (r - row)] -= 1;
                }

                if (col - (r - row) >= 0)
                {
                    this.board[r, col - (r - row)] -= 1;
                }
            }
        }

        private void MarkQueen(int row, int col)
        {
            for (int r = row; r < this.board.GetLength(0); r++)
            {
                this.board[r, col] += 1;

                if (col + (r - row) < this.board.GetLength(0))
                {
                    this.board[r, col + (r - row)] += 1;
                }

                if (col - (r - row) >= 0)
                {
                    this.board[r, col - (r - row)] += 1;
                }
            }
        }
    }
}
