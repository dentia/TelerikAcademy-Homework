//Declare a character variable and assign it with the symbol that has
//Unicode code 42 (decimal) using the \u00XX syntax, and then print it.

namespace UnicodeCharacter
{
    using System;
    class UnicodeCharacter
    {
        static void Main(string[] args)
        {
            char character = '\u002A';
            Console.WriteLine((character == '*') ? true : false);
            Console.WriteLine(character);
        }
    }
}
