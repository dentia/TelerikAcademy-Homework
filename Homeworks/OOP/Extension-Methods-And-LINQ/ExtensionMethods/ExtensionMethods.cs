
namespace ExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    public static class ExtensionMethods
    {
        #region stringBuilder_substring

        //Implement an extension method Substring(int index, int length) for the class StringBuilder that 
        //returns new StringBuilder and has the same functionality as Substring in the class String.
        public static StringBuilder Substring(this StringBuilder sb, int startIndex, int length)
        {
            StringBuilder result = new StringBuilder();

            ValidateSubstringInput(sb.Length, startIndex, length);

            for (int position = 0; position < length; position++)
            {
                result.Append(sb[startIndex + position]);
            }

            return result;
        }

        private static void ValidateSubstringInput(int sbLength, int startIndex, int length)
        {
            if (startIndex < 0 || startIndex >= sbLength)
            {
                throw new IndexOutOfRangeException();
            }

            if (length < 0)
            {
                throw new ArgumentException("Length must be greater than zero.");
            }

            if (startIndex + length >= sbLength)
            {
                throw new ArgumentException("The length of the substring is too big.");
            }
        }
        #endregion

        #region IEnumerable_extensionMethods

        //Implement a set of extension methods for IEnumerable<T> that implement the 
        //following group functions: sum, product, min, max, average.
        public static T Sum<T>(this IEnumerable<T> collection)
            where T : IConvertible, IComparable
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException("The collection is empty!");
            }

            dynamic sum = 0;
            foreach (var element in collection)
                sum += element;

            return sum;
        }

        public static T Min<T>(this IEnumerable<T> collection)
            where T : IConvertible, IComparable
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException("The collection is empty!");
            }

            T min = collection.First();
            foreach (var element in collection)
                if (element.CompareTo(min) < 0)
                    min = element;

            return min;
        }

        public static T Max<T>(this IEnumerable<T> collection)
            where T : IConvertible, IComparable
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException("The collection is empty!");
            }

            T max = collection.First();
            foreach (var element in collection)
                if (element.CompareTo(max) > 0)
                    max = element;

            return max;
        }

        public static double Average<T>(this IEnumerable<T> collection)
            where T : IConvertible, IComparable
        {
            double sum = 0.0;
            return (dynamic)collection.Aggregate(sum, (acc, val) => acc + (dynamic)val) / (dynamic)collection.Count();
        }

        public static T Product<T>(this IEnumerable<T> collection)
            where T : IConvertible, IComparable
        {
            T product = (dynamic)1;
            return collection.Aggregate(product, (acc, val) => acc * (dynamic)val);
        }
        #endregion
    }
}
