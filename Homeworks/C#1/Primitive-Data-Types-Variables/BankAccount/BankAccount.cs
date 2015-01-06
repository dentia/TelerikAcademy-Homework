//A bank account has a holder name (first name, middle name and last name), 
//available amount of money (balance), bank name, IBAN, 3 credit card numbers associated with the account.
//Declare the variables needed to keep the information for a single bank account 
//using the appropriate data types and descriptive names.

namespace BankAccount
{
    using System;
    class BankAccount
    {
        static void Main(string[] args)
        {
            //Select the commented lines below  
            //Ctrl+K+U -> Ctrl+C ->Ctrl+K+C
            //Paste them into the console

//Wessex Bank plc
//FName MName LName
//234.567
//GB82 WEST 1234 5698 7654 32
//5337 8172 9295 0938
//3112 2913 0550 5467
//4929 9302 3989 5624

            Account bankAccount = new Account();
            bankAccount.FillInfo();
            Console.Clear();
            Console.WriteLine(bankAccount);
        }
    }
}
