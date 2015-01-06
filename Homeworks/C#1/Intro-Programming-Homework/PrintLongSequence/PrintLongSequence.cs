//Write a program that prints the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7, …

namespace PrintLongSequence
{
    using System;
    class PrintLongSequence
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[1000];

            for (int number = 0; number < 1000; number++)
            {
                if (number % 2 == 0) numbers[number] = number + 2;
                else numbers[number] = -(number + 2);
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
