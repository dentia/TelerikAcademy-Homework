
namespace GSMClass
{
    using System;
    class GSMClass
    {
        static void Main(string[] args)
        {
            
            var gsmTester = new GSMTest();
            Console.WriteLine("GSM Test:\n");
            gsmTester.LoadSomePhones();
            gsmTester.PrintPhones();


            Console.WriteLine("\n\nPress any key to continue to Call tests:");
            Console.Read();
            Console.Clear();


            var callTester = new CallTest();

            callTester.AddSomeCalls();
            callTester.PrintCalls();

            callTester.RemoveLongestCall();
            callTester.PrintCalls();

            callTester.RemoveAllCalls();
            callTester.PrintCalls();
        }
    }
}
