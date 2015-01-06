//Create a program that assigns null values to an integer and to a double variable.
//Try to print these variables at the console.
//Try to add some number or the null literal to these variables and print the result.
namespace NullValuesArithmetic
{
    using System;
    class NullValuesArithmetic
    {
        static void Main(string[] args)
        {
            int? iNum = null;
            double? dNum = null;
            PrintVariables("null", iNum, dNum);

            iNum += 5;
            dNum += 5;
            PrintVariables("null + 5", iNum, dNum);

            iNum = 5;
            dNum = 5.5;
            PrintVariables("assign values", iNum, dNum);
        }

        private static void PrintVariables(string message, int? iNum, double? dNum)
        {
            string separator = new String('_', 20);
            Console.WriteLine(separator);
            Console.WriteLine(message);
            Console.WriteLine(iNum);
            Console.WriteLine(dNum);
            Console.WriteLine(separator);
        }
    }
}
