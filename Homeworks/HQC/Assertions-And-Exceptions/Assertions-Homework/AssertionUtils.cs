namespace Assertions_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class AssertionUtils
    {
        public static bool IsSorted<T>(IEnumerable<T> list) where T : IComparable<T>
        {
            if (list.Count() > 0)
            {
                var y = list.First();
                return list.Skip(1).All(x =>
                {
                    bool b = y.CompareTo(x) < 0;
                    y = x;
                    return b;
                });
            }
            else
            {
                return true;
            }
        }

        public static bool HasValue<T>(IEnumerable<T> list, T value) where T : IComparable<T>
        {
            return list.Any(x => x.Equals(value));
        }

        public static bool IsMinValue<T>(IEnumerable<T> list, T value, int starInd, int endInd) where T : IComparable<T>
        {
            return list.Skip(starInd)
                .Take(endInd - starInd)
                .Min()
                .CompareTo(value) > -1;
        }
    }
}
