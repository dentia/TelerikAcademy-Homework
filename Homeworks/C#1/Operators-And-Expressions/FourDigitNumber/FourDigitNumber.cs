//Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
//Calculates the sum of the digits (in our example 2 + 0 + 1 + 1 = 4).
//Prints on the console the number in reversed order: dcba (in our example 1102).
//Puts the last digit in the first position: dabc (in our example 1201).
//Exchanges the second and the third digits: acbd (in our example 2101).
//The number has always exactly 4 digits and cannot start with 0.

namespace FourDigitNumber
{
    using System;
    using System.Linq;
    class FourDigitNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a four-digit number: ");
            int[] digits = Console.ReadLine()
                .Trim()
                .ToCharArray()
                .Select(x => Int32.Parse(x.ToString()))
                .ToArray();

            if (digits.Length != 4)
            {
                Console.WriteLine("The number must have exactly 4 digits.");
                return;
            }
            if (digits[0] == 0)
            {
                Console.WriteLine("The number cannot start with 0.");
                return;
            }
            Console.Clear();


            Console.WriteLine(@"
{4}

Sum of digits:      {0}
Reversed digits:    {1}
Last digit-first:   {2}
Swap 2nd and 3rd:   {3}
"
                .Trim(),
                SumDigits(digits), ReverseDigits(digits), LastDigitFirst(digits), 
                SwapSecondAndThird(digits), string.Join("", digits));
        }

        static int SumDigits(int[] digits)
        {
            int sum = 0;
            foreach (var digit in digits)
            {
                sum += digit;
            }
            return sum;
        }

        static string ReverseDigits(int[] digits)
        {
            string reversedDigits = string.Join("", digits.Reverse());
            return reversedDigits;
        }

        static string LastDigitFirst(int[] digits)
        {
            string lastDigitFirst = "" + digits[digits.Length - 1];
            for (int i = 0; i < digits.Length - 1; i++)
            {
                lastDigitFirst += digits[i];
            }

            return lastDigitFirst;
        }

        static string SwapSecondAndThird(int[] digits)
        {
            return digits[0].ToString() + digits[2] + digits[1] + digits[3];
        }
    }
}
