
using System;
using System.Reflection;
namespace Bank
{
    public class LoanAccount : Account
    {
        public LoanAccount(Customer client, decimal balance, decimal interest)
            : base(client, balance, interest)
        {

        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Client is Individual)
            {
                months = Math.Max(0, months - 3);
            }
            else
            {
                months = Math.Max(0, months - 2);
            }

            return months * ((this.InterestRate / 100.0m) * this.Balance);
        }

        public override string ToString()
        {
            return String.Format("LOAN - {0} - {1:C}", this.Client.Name, this.Balance);
        }
    }
}
