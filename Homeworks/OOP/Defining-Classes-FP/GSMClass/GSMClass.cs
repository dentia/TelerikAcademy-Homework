
namespace MobilePhoneComponents
{
    using System;
    using Tests;
    class GSMClass
    {
        static void Main(string[] args)
        {
            MobilePhoneTests mpt = new MobilePhoneTests();

            Console.WriteLine("CREATING PHONE: ");
            Console.WriteLine(mpt.TestPhoneCreation());
            Console.WriteLine("OPERATIONS WITH CALLS: ");
            Console.WriteLine(mpt.TestCalls());
        }
    }
}
