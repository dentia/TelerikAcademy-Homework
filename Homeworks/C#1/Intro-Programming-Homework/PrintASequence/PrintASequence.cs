//Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...

namespace PrintASequence
{
    using System;
    class PrintASequence
    {
        static void Main(string[] args)
        {
            int[] numberSequence = new int[10];

            for (int number = 0; number < 10; number++)
            {
                if (number % 2 == 0) numberSequence[number] = number + 2;
                else numberSequence[number] = -(number + 2);
            }

            Console.WriteLine(string.Join(", ", numberSequence));
        }
    }
}
