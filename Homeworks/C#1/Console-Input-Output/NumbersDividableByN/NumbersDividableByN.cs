//Write a program that reads two positive 
//integer numbers and prints how many numbers p exist 
//between them such that the reminder of the division by 5 is 0.

namespace NumbersDividableByN
{
    using System;
    class NumbersDividableByN
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first number: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            int end = int.Parse(Console.ReadLine());

            if (start > end)
            {
                start ^= end;
                end ^= start;
                start ^= end;
            }

            int count = 0;

            for (int number = start; number <= end; number++)
                if (number % 5 == 0)
                    ++count;

            Console.WriteLine(count);
        }
    }
}
