
namespace TestMethods
{
    using System;
    using SayHello;
    using AppearanceCount;
    class TestMethods
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Greeting:            " + GreetingTest());
            Console.WriteLine("Appearance Count:    " + AppearanceCountTest());
        }

        private static string AppearanceCountTest()
        {
            if (AppearanceCount.CountElementAppearance(new int[] { 1, 2, 3 }, 2) != 1 ||
                AppearanceCount.CountElementAppearance(new int[] { 1, 2, 3, 4, 5 }, 8) != 0 ||
                AppearanceCount.CountElementAppearance(new int[] { 7, 7, 7, 7, 7, 7, 7 }, 7) != 7)
                return "Fail";

            return "Success";
        }

        private static string GreetingTest()
        {
            if ((SayHello.ReturnGreeting("Peter") != "Hello, Peter!") ||
                SayHello.ReturnGreeting("Mary-Jane") != "Hello, Mary-Jane!")
                return "Fail";

            return "Success";
        }
    }
}
