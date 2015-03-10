
namespace Bank
{
    using System;
    using System.Linq;
    class TestBank
    {
        static void Main()
        {
            Bank bank = LoadAccounts();
            Console.WriteLine(bank);
        }

        private static Bank LoadAccounts()
        {
            Bank bank = new Bank();

            bank.AddAccount(new MortgageAccount(new Individual("Another name"), 50000.0m, 25));
            bank.AddAccount(new DepositAccount(new Company("Company"), 7500.0m, 12));
            bank.AddAccount(new LoanAccount(new Company("'notherCompany"), 175000.0m, 22));
            bank.AddAccount(new MortgageAccount(new Individual("Poor Guy"), 30500.0m, 50));
            bank.AddAccount(new DepositAccount(new Company("McCompany"), 12450.0m, 13));
            bank.AddAccount(new LoanAccount(new Individual("Freddy"), 129.0m, 2));

            return bank;
        }
    }
}
