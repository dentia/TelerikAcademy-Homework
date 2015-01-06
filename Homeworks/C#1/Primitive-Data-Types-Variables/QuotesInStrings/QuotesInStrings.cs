//Declare two string variables and assign them with following value: The "use" of quotations causes difficulties.
//Do the above in two different ways - with and without using quoted strings.
//Print the variables to ensure that their value was correctly defined.

namespace QuotesInStrings
{
    using System;
    class QuotesInStrings
    {
        static void Main(string[] args)
        {
            string ecaping = "The \"use\" of quotations causes difficulties.";
            string doubleQuote = @"The ""use"" of quotations causes difficulties.";

            System.Console.WriteLine(ecaping);
            System.Console.WriteLine(doubleQuote);
        }
    }
}
