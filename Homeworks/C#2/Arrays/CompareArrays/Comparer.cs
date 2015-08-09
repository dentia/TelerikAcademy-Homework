
namespace CompareArrays
{
    using System;
    using System.Collections.Generic;
    class Comparer
    {
        public ComparisonState CompareArrays<T>(T[] first, T[] second) 
            where T : IComparable
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            if (first.Length.CompareTo(second.Length) != 0)
                return (first.Length > second.Length) ?
                    ComparisonState.First : ComparisonState.Second;

            for (int index = 0; index < first.Length; index++)
            {
                if (!comparer.Equals(first[index], second[index]))
                {
                    return (first[index].CompareTo(second[index]) > 0) ? 
                        ComparisonState.First : ComparisonState.Second;
                }
            }

            return ComparisonState.Equal;
        }
    }
}
