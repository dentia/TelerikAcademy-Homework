namespace SortingTester
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public static class AssertionUtils
    {
        public static void AssertCollection<T>(T[] collection) where T : IComparable
        {
            Debug.Assert(collection != null, "Colection is null.");
            Debug.Assert(collection.Length > 0, "Colection is empty.");
        }

        public static bool IsSorted<T>(T[] collection) where T : IComparable
        {
            T lastElement = collection.First();

            for (int ind = 1; ind < collection.Length; ind++)
            {
                T currentElement = collection[ind];

                if (lastElement.CompareTo(currentElement) > 0)
                {
                    return false;
                }

                lastElement = currentElement;
            }

            return true;
        }
    }
}
