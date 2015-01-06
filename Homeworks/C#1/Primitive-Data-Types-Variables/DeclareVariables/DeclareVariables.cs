//Declare five variables choosing for each of them the most appropriate of the types 
//byte, sbyte, short, ushort, int, uint, long, ulong to represent the following values: 52130, -115, 4825932, 97, -10000.
//Choose a large enough type for each number to ensure it will fit in it. Try to compile the code.

namespace DeclareVariables
{
    using System;
    using System.Collections.Generic;
    class DeclareVariables
    {
        static void Main(string[] args)
        {
            List<object> numbers = new List<object>();
            numbers.Add(Convert.ToInt16(-10000));
            numbers.Add(Convert.ToSByte(-115));
            numbers.Add(Convert.ToByte(97));
            numbers.Add(Convert.ToUInt16(52130));
            numbers.Add(Convert.ToInt32(4825932));


            foreach (var number in numbers)
            {
                Console.WriteLine("{0}\t\t{1}", number, number.GetType());
            }
        }
    }
}
