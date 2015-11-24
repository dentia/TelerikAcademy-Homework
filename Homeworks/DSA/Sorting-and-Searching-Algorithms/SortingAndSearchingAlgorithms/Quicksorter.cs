namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.QuickSort(collection);
        }

        private void QuickSort(IList<T> collection, Comparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            this.RecursiveQuickSort(collection, 0, collection.Count - 1, comparer);
        }

        private void RecursiveQuickSort(IList<T> collection, int left, int right, Comparer<T> comparer)
        {
            var pivot = collection[(left + right) / 2];

            var i = left;
            var j = right;

            while (i <= j)
            {
                while (comparer.Compare(collection[i], pivot) < 0)
                {
                    i++;
                }

                while (comparer.Compare(collection[j], pivot) > 0)
                {
                    j--;
                }

                if (i > j)
                {
                    continue;
                }

                var temp = collection[i];
                collection[i] = collection[j];
                collection[j] = temp;

                i++;
                j--;
            }

            if (left < j)
            {
                this.RecursiveQuickSort(collection, left, j, comparer);
            }

            if (i < right)
            {
                this.RecursiveQuickSort(collection, i, right, comparer);
            }
        }
    }
}
