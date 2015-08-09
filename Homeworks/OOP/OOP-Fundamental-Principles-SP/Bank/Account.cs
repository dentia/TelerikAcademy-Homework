
namespace Bank
{
    using System;
    public abstract class Account : IDepositable
    {
        private Customer customer;
        private decimal balance;
        private decimal interestRate;

        public Account(Customer customer, decimal balance, decimal interest)
        {
            this.Client = customer;
            this.Balance = balance;
            this.InterestRate = interest;
        }

        public Customer Client
        {
            get { return this.customer; }
            set 
            {
                if(value==null)
                {
                    throw new ArgumentNullException();
                }

                this.customer = value; 
            }
        }
        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            set { this.interestRate = value; }
        }

        public abstract decimal CalculateInterest(int months);

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("You cannot deposit negative amount of money.");
            }

            this.Balance += amount;
        }
    }
}
