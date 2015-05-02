// Write a program that removes from given sequence
// all negative numbers.

namespace RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    class RemoveNegativeNumbers
    {
        static void Main()
        {
            Console.WriteLine("Enter numbers on separate lines. The sequence should end with an empty line.");
            List<int> numbers = Common.ReadInput();
            numbers.RemoveAll(number => number < 0);
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}

/*
0
-1
2
-3
4
-5
6
-7
 
 */
