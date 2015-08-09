namespace SortingTester
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public static class SortingAlgorithms
    {
        public static void InsertionSort<T>(T[] collection, Comparer<T> comparer = null) where T : IComparable
        {
            AssertionUtils.AssertCollection(collection);
            comparer = comparer ?? Comparer<T>.Default;

            for (int i = 0; i < collection.Length - 1; i++)
            {
                int index = i + 1;
                while (index > 0)
                {
                    if (comparer.Compare(collection[index - 1], collection[index]) > 0)
                    {
                        T temp = collection[index - 1];
                        collection[index - 1] = collection[index];
                        collection[index] = temp;
                    }

                    --index;
                }
            }

            AssertionUtils.IsSorted(collection);
        }

        public static void SelectionSort<T>(T[] collection, Comparer<T> comparer = null) where T : IComparable
        {
            AssertionUtils.AssertCollection(collection);
            comparer = comparer ?? Comparer<T>.Default;

            for (int i = 0; i < collection.Length - 1; i++)
            {
                int minInd = i;

                for (int j = i + 1; j < collection.Length; j++)
                {
                    if (comparer.Compare(collection[i], collection[j]) > 0)
                    {
                        minInd = j;
                    }
                }

                if (minInd != i)
                {
                    T temp = collection[i];
                    collection[i] = collection[minInd];
                    collection[minInd] = temp;
                }
            }

            AssertionUtils.IsSorted(collection);
        }

        public static void QuickSort<T>(T[] collection, Comparer<T> comparer = null) where T : IComparable
        {
            AssertionUtils.AssertCollection(collection);
            comparer = comparer ?? Comparer<T>.Default;
            QuickSort_Recursive(collection, 0, collection.Length - 1, comparer);

            AssertionUtils.IsSorted(collection);
        }

        private static void QuickSort_Recursive<T>(T[] collection, int left, int right, Comparer<T> comparer) where T : IComparable
        {
            T pivot = collection[(left + right) / 2];

            int i = left;
            int j = right;

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

                if (i <= j)
                {
                    T temp = collection[i];
                    collection[i] = collection[j];
                    collection[j] = temp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuickSort_Recursive(collection, left, j, comparer);
            }

            if (i < right)
            {
                QuickSort_Recursive(collection, i, right, comparer);
            }
        }
    }
}
