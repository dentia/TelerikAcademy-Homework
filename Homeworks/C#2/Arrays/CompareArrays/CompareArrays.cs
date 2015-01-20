//Write a program that compares two char arrays lexicographically (letter by letter).

namespace CompareArrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class CompareArrays
    {
        static void Main(string[] args)
        {
            Comparer comparer = new Comparer();
            string result;
            Console.WriteLine(@"Select data type:
I   ->  Integer
C   ->  Character
D   ->  Double");

            result = GetResult(comparer);

            Console.WriteLine(result);
        }

        private static string GetResult(Comparer comparer)
        {
            string result;
            switch (Console.ReadLine().ToUpper()[0])
            {
                case 'I':
                    int[] firstIntArray = GetIntArray();
                    int[] secondIntArray = GetIntArray();
                    result = comparer.CompareArrays(firstIntArray, secondIntArray).ToString();
                    break;
                case 'C':
                    char[] firstCharArray = GetCharArray();
                    char[] secondCharArray = GetCharArray();
                    result = comparer.CompareArrays(firstCharArray, secondCharArray).ToString();
                    break;
                case 'D':
                    double[] firstDoubleArray = GetDoubleArray();
                    double[] secondDoubleArray = GetDoubleArray();
                    result = comparer.CompareArrays(firstDoubleArray, secondDoubleArray).ToString();
                    break;
                default:
                    result = "Invalid input!";
                    break;
            }
            return result;
        }

        private static double[] GetDoubleArray()
        {
            Console.WriteLine("Enter integers, separated by comma: ");
            return Console.ReadLine()
                .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x))
                .ToArray();
        }

        private static char[] GetCharArray()
        {
            Console.WriteLine("Enter character sequence: ");
            return Console.ReadLine().ToCharArray();
        }

        private static int[] GetIntArray()
        {
            Console.WriteLine("Enter numbers, separated by comma: ");
            return Console.ReadLine()
                .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
        }
    }
}
