//Declare a Boolean variable called isFemale and assign an appropriate value corresponding to your gender.
//Print it on the console.

namespace BooleanVariable
{
    using System;
    class BooleanVariable
    {
        static void Main(string[] args)
        {
            bool isFemale = true;
            Console.Write("Am I female? ");
            Console.WriteLine(isFemale ? "Yes" : "No");
        }
    }
}
