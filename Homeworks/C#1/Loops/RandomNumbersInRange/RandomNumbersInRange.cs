//Write a program that enters 3 integers n, 
//min and max (min = max) and prints n 
//random numbers in the range [min...max].

namespace RandomNumbersInRange
{
    using System;
    class RandomNumbersInRange
    {
        static void Main(string[] args)
        {
            Console.Write("Enter count: ");
            int count = int.Parse(Console.ReadLine());

            if (count < 1)
            {
                Console.WriteLine("No numbers to show.");
                return;
            }

            Console.Write("Enter min of range: ");
            int min = int.Parse(Console.ReadLine());
            Console.Write("Enter max of range: ");
            int max = int.Parse(Console.ReadLine());

            if (min > max)
            {
                int temp = min;
                min = max;
                max = temp;
            }

            int[] numbers = new int[count];
            GetRandomNumbers(min, max, numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void GetRandomNumbers(int min, int max, int[] numbers)
        {
            Random random = new Random();

            for (int index = 0; index < numbers.Length; index++)
            {
                numbers[index] = random.Next(min, max + 1);
            }
        }
    }
}
