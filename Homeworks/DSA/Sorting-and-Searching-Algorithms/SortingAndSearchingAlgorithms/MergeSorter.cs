namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.SortArray(collection, 0, collection.Count - 1);
        }

        private void SortArray(IList<T> collection, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            var mid = (left + right) / 2;
            this.SortArray(collection, left, mid);
            this.SortArray(collection, mid + 1, right);

            this.MergeArrays(collection, left, mid + 1, right);
        }

        private void MergeArrays(IList<T> numbers, int left, int mid, int right)
        {
            var numbersCount = right - left + 1;
            var leftEnd = mid - 1;
            var position = left;
            var temp = new T[numbers.Count];

            while ((left <= leftEnd) && (mid <= right))
            {
                if (numbers[left].CompareTo(numbers[mid]) < 1)
                {
                    temp[position++] = numbers[left++];
                }
                else
                {
                    temp[position++] = numbers[mid++];
                }
            }

            while (left <= leftEnd)
            {
                temp[position++] = numbers[left++];
            }

            while (mid <= right)
            {
                temp[position++] = numbers[mid++];
            }

            for (var index = numbersCount - 1; index >= 0; index--)
            {
                numbers[right] = temp[right];
                --right;
            }
        }
    }
}
