//Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation.

namespace NumberAsWords
{
    using System;
    class NumberAsWords
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number in range [0...999]: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(NumberAsWord(number));
        }

        private static string NumberAsWord(int number)
        {
            if (number > 99)
            {
                return Hundreds(number);
            }
            else if (number > 9)
            {
                return Tens(number);
            }
            else
            {
                return DigitAsWord(number);
            }
        }

        private static string Tens(int number)
        {
            string tens = "";
            string num = number.ToString();
            if (num[num.Length - 2] == '1')
            {
                tens += DigitAsWord(int.Parse(num[num.Length - 2] + "" + num[num.Length - 1]));
            }
            else
            {
                tens += DigitAsWord(int.Parse(num[num.Length - 2] + "") * 10);
                if (number % 10 != 0)
                {
                    tens += "-" + DigitAsWord(int.Parse(num[num.Length - 1] + ""));
                }
            }
            return tens;
        }

        private static string Hundreds(int number)
        {
            string hundred = DigitAsWord((number / 100) % 10) + " hundred";

            if (((number / 10) % 10) != 0 || (number % 10) != 0)
            {
                hundred += " and ";
                if ((number / 10) % 10 > 0)
                {
                    hundred += Tens(number - (100 * ((number / 100) % 10)));
                }
                else
                {
                    hundred += DigitAsWord(number % 10);
                }
            }
            
            return hundred;
        }

        private static string DigitAsWord(int p)
        {
            switch (p)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                case 10: return "ten";
                case 11: return "eleven";
                case 12: return "twelve";
                case 13: return "thirteen";
                case 14: return "fourteen";
                case 15: return "fifteen";
                case 16: return "sixteen";
                case 17: return "seventeen";
                case 18: return "eighteen";
                case 19: return "nineteen";
                case 20: return "twenty";
                case 30: return "thirty";
                case 40: return "forty";
                case 50: return "fifty";
                case 60: return "sixty";
                case 70: return "seventy";
                case 80: return "eight";
                case 90: return "ninety";
                default: return "Invalid";
            }
        }
    }
}
