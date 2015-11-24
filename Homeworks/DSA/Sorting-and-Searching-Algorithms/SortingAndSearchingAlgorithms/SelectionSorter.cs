namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.SelectionSort(collection);
        }

        private void SelectionSort(IList<T> collection, Comparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;

            for (var i = 0; i < collection.Count - 1; i++)
            {
                var minInd = i;

                for (var j = i + 1; j < collection.Count; j++)
                {
                    if (comparer.Compare(collection[i], collection[j]) > 0)
                    {
                        minInd = j;
                    }
                }

                if (minInd == i)
                {
                    continue;
                }

                var temp = collection[i];
                collection[i] = collection[minInd];
                collection[minInd] = temp;
            }
        }
    }
}
