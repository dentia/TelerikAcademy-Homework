namespace ZeroSubset
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class SubsetSumGenerator
    {
        internal int sum;
        private int[] numbers;
        private List<string> allSubsets;
        public SubsetSumGenerator(int sum, int[] numbers)
        {
            this.sum = sum;
            this.numbers = numbers;
            allSubsets = new List<string>();
        }

        public List<string> GetAllSums()
        {
            for (int length = 1; length <= this.numbers.Length; length++)
            {
                int[] array = new int[length];
                GenerateSubsets(array, 0, 0, this.numbers.Length);
            }
            return allSubsets;
        }
        public void GenerateSubsets(int[] tempArray, int currentIndex, int startIndex, int range)
        {
            if (currentIndex == tempArray.Length)
            {
                if (tempArray.Sum() == this.sum) allSubsets.Add(SubsetToString(tempArray));
                return;
            }
            else
            {
                for (int index = startIndex; index < range; index++)
                {
                    tempArray[currentIndex] = numbers[index];
                    GenerateSubsets(tempArray, currentIndex + 1, index + 1, range);
                }
            }
        }

        private string SubsetToString(int[] numbers)
        {
            StringBuilder result = new StringBuilder();

            for (int index = 0; index < numbers.Length; index++)
            {
                if (index > 0) result.Append((numbers[index] >= 0) ? " + " : " - ");
                result.Append(Math.Abs(numbers[index]));
            }
            result.Append(" = " + this.sum);

            return result.ToString();
        }
    }
}