// Write a program that sorts an array of strings using the quick sort algorithm.

namespace QuickSort
{
    using System;
    using System.Linq;
    class QuickSort
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Eneter numbers, separated by a comma: ");
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
            int pivot;

            if (left < right)
            {
                pivot = Partition(numbers, left, right);

                if (pivot > 1)
                {
                    SortArray(numbers, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    SortArray(numbers, pivot + 1, right);
                }
            }
        }

        private static int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];

            while (true)
            {
                while (numbers[left] < pivot) ++left;
                while (numbers[right] > pivot) --right;

                if (numbers[right] == numbers[left] && numbers[left] == pivot)
                    ++left;

                if (left < right)
                {
                    numbers[left] ^= numbers[right];
                    numbers[right] ^= numbers[left];
                    numbers[left] ^= numbers[right];
                }
                else
                    return right;
            }
        }
    }
}
