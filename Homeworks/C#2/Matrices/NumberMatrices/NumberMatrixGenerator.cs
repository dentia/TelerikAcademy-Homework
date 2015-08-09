
namespace NumberMatrices
{
    class NumberMatrixGenerator
    {
        private int size;
        private int[,] matrix;

        public NumberMatrixGenerator(int size)
        {
            this.size = size;
        }

        public int[,] GetMatrix(MatrixType type)
        {
            switch (type)
            {
                case MatrixType.Type_A:
                    GetMatrixTypeA();
                    break;
                case MatrixType.Type_B:
                    GetMatrixTypeB();
                    break;
                case MatrixType.Type_C:
                    GetMatrixTypeC();
                    break;
                case MatrixType.Type_D:
                    GetMatrixTypeD();
                    break;
                default:
                    break;
            }

            return this.matrix;
        }

        private void GetMatrixTypeA()
        {
            this.matrix = new int[this.size, this.size];

            int number = 1;

            for (int col = 0; col < this.size; col++)
            {
                for (int row = 0; row < this.size; row++)
                {
                    this.matrix[row, col] = number++;
                }
            }
        }

        private void GetMatrixTypeB()
        {
            this.matrix = new int[this.size, this.size];
            int number = 1;
            int currentRow = 0;
            int change = -1;

            for (int col = 0; col < this.size; col++)
            {
                change *= -1;
                for (int row = 0; row < this.size; row++)
                {
                    this.matrix[currentRow, col] = number++;
                    currentRow += change;
                }
                currentRow += -change;
            }
        }

        private void GetMatrixTypeC()
        {
            this.matrix = new int[this.size, this.size];
            int number = 1;
            int currentRow;

            for (int row = this.size - 1; row >= 0; row--)
            {
                currentRow = row;
                for (int col = 0; col < this.size - row; col++)
                {
                    this.matrix[currentRow++, col] = number++;
                }
            }

            number = this.size * this.size;

            for (int row = 0; row < size - 1; row++)
            {
                currentRow = row;
                for (int col = this.size - 1; currentRow >= 0; col--)
                {
                    this.matrix[currentRow--, col] = number--;
                }
            }
        }

        private void GetMatrixTypeD()
        {
            this.matrix = new int[this.size, this.size];
            int[] rowDRUL = new int[] { 1, 0, -1, 0 };
            int[] colDRUL = new int[] { 0, 1, 0, -1 };
            int direction = 0;
            int number = 1;
            int row = 0;
            int col = 0;
            int nextRow;
            int nextCol;

            while (number <= this.size * this.size)
            {
                this.matrix[row, col] = number++;
                nextRow = row + rowDRUL[direction];
                nextCol = col + colDRUL[direction];

                if ((nextRow < 0 || nextRow >= this.size) ||
                    (nextCol < 0 || nextCol >= this.size) ||
                    this.matrix[nextRow, nextCol] != 0)
                {
                    direction = (direction + 1) % 4;
                }

                row += rowDRUL[direction];
                col += colDRUL[direction];
            }
        }
    }
}
