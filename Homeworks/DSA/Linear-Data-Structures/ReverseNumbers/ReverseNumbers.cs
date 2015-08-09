// Write a program that reads N integers from the
// console and reverses them using a stack. Use the
// Stack<int> class.

namespace ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    class ReverseNumbers
    {
        static void Main()
        {
            Console.Write("Enter count: ");
            int count = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            for (int ind = 0; ind < count; ind++)
            {
                Console.Write("Enter number: ");
                numbers.Push(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
