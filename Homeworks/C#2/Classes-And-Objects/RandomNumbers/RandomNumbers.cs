//Write a program that generates and prints to the console 10 random values in the range [100, 200].

namespace RandomNumbers
{
    using System;
    class RandomNumbers
    {
        const int MIN = 100;
        const int MAX = 201;
        const int COUNT = 10;
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] randomNumbers = new int[COUNT];

            for (int current = 0; current < COUNT; current++)
            {
                randomNumbers[current] = random.Next(MIN, MAX);
            }

            Console.WriteLine(String.Join(Environment.NewLine, randomNumbers));
        }
    }
}
