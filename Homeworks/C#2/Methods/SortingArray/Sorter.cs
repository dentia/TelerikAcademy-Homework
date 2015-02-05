
namespace SortingArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Sorter
    {
        private int[] numbers;

        public Sorter(int[] array)
        {
            this.numbers = array;
        }

        public int[] Sort(SortMethod method)
        {
            if (method == SortMethod.ASC)
            {
                SortAsc();
            }
            else
            {
                SortDesc();
            }

            return this.numbers;
        }

        private void SortDesc()
        {
            int startIndex = 0;
            for (int index = startIndex; index < this.numbers.Length; index++)
            {
                int currentMaxIndex = MaxInRangeDesc(startIndex++, this.numbers.Length);
                int maxValue = this.numbers[currentMaxIndex];

                int swap = this.numbers[index];

                this.numbers[index] = maxValue;
                this.numbers[currentMaxIndex] = swap;
            }
        }

        private void SortAsc()
        {
            int endIndex = this.numbers.Length;
            for (int index = endIndex - 1; index >= 0; index--)
            {
                int currentMaxIndex = MaxInRangeAsc(0, endIndex--);
                int maxValue = this.numbers[currentMaxIndex];

                int swap = this.numbers[index];

                this.numbers[index] = maxValue;
                this.numbers[currentMaxIndex] = swap;
            }
        }

        private int MaxInRangeAsc(int startIndex, int endIndex)
        {
            return Array.IndexOf(this.numbers,
                this.numbers
                .Select((value, index) => new { Value = value, Index = index })
                .Where(x => x.Index >= startIndex && x.Index < endIndex)
                .Max(x => x.Value));
        }

        private int MaxInRangeDesc(int startIndex, int endIndex)
        {
            return Array.LastIndexOf(this.numbers,
                this.numbers
                .Select((value, index) => new { Value = value, Index = index })
                .Where(x => x.Index >= startIndex && x.Index < endIndex)
                .Max(x => x.Value));
        }
    }
}
