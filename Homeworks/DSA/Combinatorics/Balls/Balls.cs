namespace Balls
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class Balls
    {
        private static readonly BigInteger[] Factorials = new BigInteger[31];

        public static void Main()
        {
            var balls = Console.ReadLine();
            var groupedBalls = new Dictionary<char, BigInteger>();
            
            foreach (var ball in balls)
            {
                if (!groupedBalls.ContainsKey(ball))
                {
                    groupedBalls.Add(ball, 1);
                }
                else
                {
                    groupedBalls[ball] += 1;
                }
            }

            BigInteger ballsCount = 0;
            BigInteger factorialProducts = 1L;

            foreach (var group in groupedBalls)
            {
                ballsCount += group.Value;
                factorialProducts *= Factorial(group.Value);
            }

            BigInteger ballsCountFactorial = Factorial(ballsCount);
            Console.WriteLine(ballsCountFactorial / factorialProducts);
        }

        public static BigInteger Factorial(BigInteger num)
        {
            if (Factorials[(int)num] != 0)
            {
                return Factorials[(int)num];
            }

            if (num == 1)
            {
                Factorials[(int)num] = 1;
                return 1;
            }

            Factorials[(int)num] = num * Factorial(num - 1);
            return Factorials[(int)num];
        }
    }
}
