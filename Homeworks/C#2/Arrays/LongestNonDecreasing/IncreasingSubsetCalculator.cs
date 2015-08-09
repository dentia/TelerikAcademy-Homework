
namespace LongestNonDecreasing
{
    using System;
    using System.Text;
    class IncreasingSubsetCalculator
    {
        private int MIN = int.MinValue;
        private int MAX = int.MaxValue;
        private int[] numbers;
        private int[,] matrix;
        private int count;

        public IncreasingSubsetCalculator(int[] numbers)
        {
            this.numbers = numbers;
            this.count = numbers.Length + 1;
            matrix = new int[count, count];
        }

        private StringBuilder result = new StringBuilder();
        public string GetSubset()
        {
            PrefillMatrix();
            int lastIndex = CalculateSubset();

            return GetSequence(lastIndex);
        }

        private string GetSequence(int lastIndex)
        {
            int[] subset = new int[lastIndex];
            int index = subset.Length - 1;
            int row = this.count - 2;
            int col = lastIndex;

            do
            {
                if (this.matrix[row, col] == this.matrix[row - 1, col]) 
                    --row;
                else
                    subset[index--] = this.matrix[row, col--];

            } while (row > 0);

            return String.Format("({0})", String.Join(", ", subset));
        }

        private int CalculateSubset()
        {
            int lastIndex = 1;

            for (int row = 1; row < this.count - 1; row++)
            {
                for (int col = 1; col < this.count - 1; col++)
                {
                    if ((this.matrix[row - 1, col - 1] <= this.numbers[row]) && 
                        (this.matrix[row - 1, col] >= this.numbers[row]) &&
                        (this.matrix[row - 1, col - 1] <= this.matrix[row - 1, col]))
                    {
                        this.matrix[row, col] = this.numbers[row];
                        if (col > lastIndex) 
                            lastIndex = col;
                    }
                    else
                        this.matrix[row, col] = this.matrix[row - 1, col];
                }
            }

            return lastIndex;
        }

        private void PrefillMatrix()
        {
            for (int row = 0; row < this.count; row++)
            {
                this.matrix[row, 0] = MIN;
                for (int col = 1; col < this.count; col++)
                {
                    this.matrix[row, col] = MAX;
                }
            }
        } 
    }
}
