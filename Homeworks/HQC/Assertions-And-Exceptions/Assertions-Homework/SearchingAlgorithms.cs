namespace Assertions_Homework
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public static class SearchingAlgorithms
    {
        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null.");
            Debug.Assert(value != null, "Search value is null.");
            Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "Start index is out of range.");
            Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "End index is out of range.");
            Debug.Assert(startIndex <= endIndex, "Start index is greater than end index.");
            Debug.Assert(AssertionUtils.IsSorted(arr), "Array is not sorted.");
            
            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;

                switch (arr[midIndex].CompareTo(value))
                {
                    case 0:
                        return midIndex;
                    case -1:
                        startIndex = midIndex + 1;
                        break;
                    case 1:
                        endIndex = midIndex - 1;
                        break;
                }
            }

            // Searched value not found
            Debug.Assert(!AssertionUtils.HasValue(arr, value), "The array has the searchead value but returns -1.");
            return -1;
        }
    }
}
