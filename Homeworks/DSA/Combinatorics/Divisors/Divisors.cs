namespace Divisors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Divisors
    {
        private static readonly List<int> Numbers = new List<int>();

        public static void Main()
        {
            var digits = new int[int.Parse(Console.ReadLine())];

            for (int ind = 0; ind < digits.Length; ind++)
            {
                digits[ind] = int.Parse(Console.ReadLine());
            }

            Array.Sort(digits);
            Permute(digits, 0, digits.Length);

            if (digits.Length == 1)
            {
                Console.WriteLine(digits[0]);
            }
            else
            {
                Console.WriteLine(Numbers.OrderBy(GetDivisorsCount).ThenBy(x => x).First());
            }
        }

        public static int GetDivisorsCount(int num)
        {
            if (num == 1)
            {
                return 1;
            }

            int resuult = 0;

            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    ++resuult;
                }
            }

            return resuult;
        }

        public static void Permute(int[] digits, int start, int n)
        {
            Save(digits);

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (digits[left] != digits[right])
                    {
                        Swap(ref digits[left], ref digits[right]);
                        Permute(digits, left + 1, n);
                    }
                }

                var firstElement = digits[left];
                for (int i = left; i < n - 1; i++)
                {
                    digits[i] = digits[i + 1];
                }

                digits[n - 1] = firstElement;
            }
        }

        public static void Save(int[] digits)
        {
            Numbers.Add(int.Parse(string.Join(string.Empty, digits)));
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
