//Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order.

namespace NumbersInRandomPosition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class NumbersInRandomPosition
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            bool increment = number >= 1;
            List<int> numbers = GetNumbers(number, increment);
            Random random = new Random();

            var result = numbers.OrderBy(item => random.Next());

            Console.WriteLine(string.Join(", ", result));
        }

        private static List<int> GetNumbers(int number, bool increment)
        {
            List<int> numbers = new List<int>();
            if (number == 0)
            {
                numbers.Add(1);
                numbers.Add(0);
            }
            else
            {
                for (int i = 1; Math.Abs(i) <= Math.Abs(number); )
                {
                    numbers.Add(i);
                    if (increment) ++i;
                    else --i;
                }
            }
            return numbers;
        }
    }
}
