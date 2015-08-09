
using System;
namespace Bank
{
    public class DepositAccount : Account, IDrawable
    {
        public DepositAccount(Customer client, decimal balance, decimal interest)
            : base(client, balance, interest)
        {

        }

        public void Withdraw(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new ArgumentException("You cannot withdraw more than the balance of the account.");
            }

            this.Balance -= amount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance >= 1000.0m)
            {
                return months * ((this.InterestRate / 100.0m) * this.Balance);
            }

            else return 0.0m;
        }

        public override string ToString()
        {
            return String.Format("DEPOSIT - {0} - {1:C}", this.Client.Name, this.Balance);
        }
    }
}
