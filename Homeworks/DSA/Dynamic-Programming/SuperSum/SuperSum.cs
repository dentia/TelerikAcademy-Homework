namespace SuperSum
{
    using System;
    using System.Linq;

    public class SuperSum
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var k = input[0];
            var n = input[1];
            Console.WriteLine(CalculateSuperSum(k, n));
        }

        private static int CalculateSuperSum(int k, int n)
        {
            var ret = 0;
            if (k == 0)
            {
                return n;
            }

            for (var i = 1; i <= n; i++)
            {
                ret += CalculateSuperSum(k - 1, i);
            }

            return ret;
        }
    }
}
