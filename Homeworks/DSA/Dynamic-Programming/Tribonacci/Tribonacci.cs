namespace Tribonacci
{
    using System;
    using System.Linq;

    public class Tribonacci
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var a = input[0];
            var b = input[1];
            var c = input[2];
            var position = input[3];

            switch (position)
            {
                case 1:
                    Console.WriteLine(a);
                    break;
                case 2:
                    Console.WriteLine(b);
                    break;
                case 3:
                    Console.WriteLine(c);
                    break;
                default:
                    Console.WriteLine(GetTribonacci(a, b, c, position));
                    break;
            }
        }

        private static long GetTribonacci(long a, long b, long c, int position)
        {
            for (var i = 4; i <= position; i++)
            {
                var tribNew = a + b + c;
                a = b;
                b = c;
                c = tribNew;
            }

            return c;
        }
    }
}
