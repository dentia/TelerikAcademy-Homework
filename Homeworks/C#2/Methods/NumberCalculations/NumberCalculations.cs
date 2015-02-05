//Write methods to calculate minimum, maximum, average, 
//sum and product of given set of integer numbers.
//Use variable number of arguments.
//&&
//Modify your last program and try to make it work for any 
//number type, not just integer (e.g. decimal, float, byte, etc.)

namespace NumberCalculations
{
    using System;
    using System.Linq;
    class NumberCalculations
    {
        static void Main(string[] args)
        {
            int[] intArr = new int[] { -23, -1, 12, 45, 13, 2, 1, 90, 4 };
            double[] doubleArr = new double[] { 1.2, 2.3, 3.4, 4.5, 5.6, 6.7, 7.8 };
            byte[] byteArr = new byte[] { 2, 1, 5, 3, 2 };

            NumberSequence<int> intSequence = new NumberSequence<int>(intArr);
            Console.WriteLine(intSequence);
            NumberSequence<double> doubleSequence = new NumberSequence<double>(doubleArr);
            Console.WriteLine(doubleSequence);
            NumberSequence<byte> byteSequence = new NumberSequence<byte>(byteArr);
            Console.WriteLine(byteSequence);
        }
    }
}
