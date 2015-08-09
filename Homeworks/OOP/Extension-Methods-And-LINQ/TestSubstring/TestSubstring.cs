//Implement an extension method Substring(int index, int length) for the 
//class StringBuilder that returns new StringBuilder and has the same 
//functionality as Substring in the class String.

namespace TestSubstring
{
    using System;
    using System.Text;
    using ExtensionMethods;
    class TestSubstring
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("Only THIS will remain after the substring.");
            Console.WriteLine(sb);
            sb = sb.Substring(5, 4);
            Console.WriteLine(sb);
        }
    }
}
