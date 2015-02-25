//Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
//Create an instance of the GSM class.
//Add few calls.
//Display the information about the calls.
//Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
//Remove the longest call from the history 
//and calculate the total price again.
//Finally clear the call history and print it.

namespace GSMClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class CallTest
    {
        private MobilePhone phone = MobilePhone.IPhone6Plus;

        public void AddSomeCalls()
        {
            Call[] calls = {
                new Call(DateTime.Now, new ContactInformation("Nikolay", "0876 543 012"), 124.5),
                new Call(new DateTime(2014, 3, 12), new ContactInformation("Phoebe", "02/0876012"), 14),
                new Call(DateTime.Now, new ContactInformation("Marry", "+359 0876 543 012"), 55.5),
                new Call(new DateTime(2015, 2, 25), new ContactInformation("Nikolay", "0876 543 012"), 333.3)};

            foreach (var call in calls)
            {
                this.phone.AddCall(call);
            }
        }

        public void RemoveLongestCall()
        {
            Call longest = this.phone.CallHistory
                .OrderByDescending(x => x.Duration)
                .FirstOrDefault();

            this.phone.DeleteCall(longest);
        }

        public void RemoveAllCalls()
        {
            this.phone.DeleteCallHistory();
        }

        public void PrintCalls()
        {
            Console.WriteLine(new String('_', 20));
            List<Call> calls = this.phone.CallHistory;

            foreach (var call in calls)
            {
                Console.WriteLine(call);
            }
            Console.WriteLine(new String('-', 20));
        }
    }
}
