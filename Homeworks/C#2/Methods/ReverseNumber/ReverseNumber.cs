//Write a method that reverses the digits of given decimal number.

namespace ReverseNumber
{
    using System;
    using System.Text;

    class ReverseNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();

            Console.WriteLine(Reverse(input));
        }

        private static double Reverse(string number)
        {
            char[] num = number.ToCharArray();
            char[] result = new char[num.Length];

            for (int index = 0; index < result.Length; index++) 
                if (!Char.IsDigit(num[index])) 
                    result[index] = num[index];

            for (int resultInd = result.Length - 1, numInd = 0;
                 resultInd >= 0 && numInd < num.Length;
                 resultInd--, numInd++) 
            {
                while (result[resultInd]!='\0')
                    --resultInd;

                while (!Char.IsDigit(num[numInd])) 
                    ++numInd;

                result[resultInd] = num[numInd];
            }

            return double.Parse(new String(result));
        }
    }
}
