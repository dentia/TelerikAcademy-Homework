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
            int count = 0;
            
            if (end % 5 == 0 && start % 5 == 0)
                ++count;

            end /= 5;
            start /= 5;
            count += Math.Abs(end - start);

            Console.WriteLine(count);
        }
    }
}
