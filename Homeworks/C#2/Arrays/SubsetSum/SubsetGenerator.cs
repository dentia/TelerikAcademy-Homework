
namespace SubsetSum
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    class SubsetGenerator
    {
        private HashSet<string> subsets;
        private int sum;
        private int[] numbers;

        public SubsetGenerator(int[] numbers, int sum)
        {
            this.subsets = new HashSet<string>();
            this.sum = sum;
            this.numbers = numbers;
        }

        public string GetResult(int? elementCount)
        {
            if (elementCount.HasValue) //a count is set
            {
                bool[] used = new bool[this.numbers.Length];
                int[] vector = new int[(int)elementCount];

                GenerateSubset(0, 0, used, vector);
            }
            else
            {
                for (int count = 1; count <= this.numbers.Length; count++)
                {
                    bool[] used = new bool[this.numbers.Length];
                    int[] vector = new int[count];

                    GenerateSubset(0, 0, used, vector);
                }
            }

            return String.Join("\n", this.subsets);
        }

        private void GenerateSubset(int index, int startIndex, bool[] used, int[] vector)
        {
            if (index == vector.Length)
            {
                if (vector.Sum() == this.sum)
                    subsets.Add(String.Format("({0})", String.Join(", ", vector)));
                
                return;    
            }

            for (int currentIndex = startIndex; currentIndex < this.numbers.Length; currentIndex++)
            {
                if (!used[currentIndex])
                {
                    used[currentIndex] = true;
                    vector[index] = this.numbers[currentIndex];

                    GenerateSubset(index + 1, currentIndex + 1, used, vector);

                    used[currentIndex] = false;
                }
            }
        }
    }
}
