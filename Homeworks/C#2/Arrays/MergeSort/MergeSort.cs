//Write a program that sorts an array of integers using the merge sort algorithm.

namespace MergeSort
{
    using System;
    using System.Linq;
    class MergeSort
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers, separated by a comma: ");
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            SortArray(numbers, 0, numbers.Length - 1);
            Console.WriteLine(String.Join(", ", numbers));
            //2, -4, 13, -20, 5, 16, 8, 14, -6, -3, -7, 10, 5, 11, 2, 0, 0, -4 
        }

        private static void SortArray(int[] numbers, int left, int right)
        {
            int mid;

            if (left < right)
            {
                mid = (left + right) / 2;

                // Divide the array into two halves until we have an array
                // of one element, because a one-element array is considered
                // sorted
                SortArray(numbers, left, mid);
                SortArray(numbers, mid + 1, right);

                MergeArrays(numbers, left, mid + 1, right);
            }
        }

        private static void MergeArrays(int[] numbers, int left, int mid, int right)
        {
            int numbersCount = right - left + 1;
            int leftEnd = mid - 1;
            int position = left;
            int[] temp = new int[numbers.Length];

            while ((left <= leftEnd) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
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

            for (int index = numbersCount - 1; index >= 0; index--)
            {
                numbers[right] = temp[right];
                --right;
            }
        }
    }
}
