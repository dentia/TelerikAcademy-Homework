//Declare two integer variables a and b and assign them with 
//5 and 10 and after that exchange their values by using some programming logic.
//Print the variable values before and after the exchange.

namespace ExchangeVariableValues
{
    using System;
    class ExchangeVariableValues
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int second = int.Parse(Console.ReadLine());
            Console.Clear();
            PrintNumbers(first, second);

            first ^= second;
            second ^= first;
            first ^= second;

            Console.WriteLine("After exchange: ");
            PrintNumbers(first, second);
        }

        private static void PrintNumbers(int first, int second)
        {
            string separator =  new String('_', 20);

            Console.WriteLine(separator);
            Console.WriteLine("A\t{0,10}", first);
            Console.WriteLine("B\t{0,10}", second);
            Console.WriteLine(separator);
        }
    }
}
