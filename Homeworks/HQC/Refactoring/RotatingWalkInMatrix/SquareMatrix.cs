namespace RotatingWalkInMatrix
{
    using System;
    using System.Linq;
    using System.Text;

    public class SquareMatrix
    {
        private const int MinSize = 1;
        private const int MaxSize = 100;
        private int size;
        private int[,] matrix;

        public SquareMatrix(int size)
        {
            this.Size = size;
            this.matrix = new int[this.Size, this.Size];
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < SquareMatrix.MinSize || value > SquareMatrix.MaxSize)
                {
                    throw new ArgumentException(string.Format("Matrix size should be in range [{0}; {1}]", SquareMatrix.MinSize, SquareMatrix.MaxSize));
                }

                this.size = value;
            }
        }

        public int[,] Matrix
        {
            get
            {
                return (int[,])this.matrix.Clone();
            }
        }

        public void RotatingWalkFill()
        {
            Coordinates position = this.matrix.GetStartingPosition();
            Direction direction = Direction.DownRight;
            int rowChange = RotatingWalkUtils.GetRowChange(direction);
            int colChange = RotatingWalkUtils.GetColChange(direction);
            int cellValue = 1;

            while (cellValue <= this.Size * this.Size)
            {
                this.matrix[position.Row, position.Col] = cellValue;

                if (!this.matrix.CanContinueInDirection(position.Row + rowChange, position.Col + colChange))
                {
                    bool neighboursAreFilled = false;

                    if (this.matrix.NeighboursAreFilled(position.Row, position.Col))
                    {
                        neighboursAreFilled = true;

                        position = this.matrix.GetStartingPosition();
                        if (position == null)
                        {
                            break;
                        }

                        direction = Direction.DownRight;
                    }
                    else
                    {
                        direction = this.matrix.GetNextDirection(direction, position.Row, position.Col);
                    }

                    rowChange = RotatingWalkUtils.GetRowChange(direction);
                    colChange = RotatingWalkUtils.GetColChange(direction);

                    if (neighboursAreFilled)
                    {
                        continue;
                    }
                }

                position.Row += rowChange;
                position.Col += colChange;
                cellValue += 1;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    result.AppendFormat("{0, -5}", this.matrix[row, col]);
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
