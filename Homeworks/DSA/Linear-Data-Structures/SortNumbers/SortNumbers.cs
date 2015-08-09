// Write a program that reads a sequence of integers
// (List<int>) ending with an empty line and sorts
// them in an increasing order.

namespace SortNumbers
{
    using System;
    using System.Collections.Generic;
    using Common;
    class SortNumbers
    {
        static void Main()
        {
            Console.WriteLine("Enter numbers on separate lines. The sequence should end with an empty line.");
            int[] numbers = Common.ReadInput().ToArray();

            Sort(numbers);

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void Sort(int[] numbers)
        {
            bool swapOccured;

            for (int i = 0; i < numbers.Length; i++)
            {
                swapOccured = false;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[i])
                    {
                        int tmp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = tmp;
                        swapOccured = true;
                    }
                }

                if (!swapOccured) break;
            }
        }
    }
}

/*
90
93
42
42
78
97
18
6
62
29
34
51
19
89
81
71
99
68
46
18
 */
