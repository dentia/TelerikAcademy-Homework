//Which of the following values can be assigned to a variable of type float and which to a variable 
//of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?
//Write a program to assign the numbers in variables and print them to ensure no precision is lost.

namespace FloatOrDouble
{
    using System;
    using System.Collections.Generic;
    class FloatOrDouble
    {
        static void Main(string[] args)
        {
            List<object> numbers = new List<object>();

            numbers.Add(Convert.ToSingle(12.345));
            numbers.Add(Convert.ToSingle(3456.091));
            numbers.Add(Convert.ToDouble(34.567839023));
            numbers.Add(Convert.ToDouble(8923.1234857));

            foreach (var number in numbers)
            {
                Console.WriteLine("{0, -12}\t{1}", number, number.GetType());
            }
        }
    }
}
