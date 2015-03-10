
namespace Bank
{
    using System;
    public class MortgageAccount : Account
    {
        public MortgageAccount(Customer client, decimal balance, decimal interest)
            : base(client, balance, interest)
        {

        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Client is Company)
            {
                if (months <= 12)
                {
                    return months * (this.Balance * 0.5m);
                }
                else
                {
                    return (12 * (this.Balance * 0.5m)) + ((months - 12) * ((this.InterestRate / 100) * this.Balance));
                }
            }
            else
            {
                if (months <= 6)
                {
                    return 0.0m;
                }
                else
                {
                    return (months - 6) * ((this.InterestRate / 100.0m) * this.Balance);
                }
            }
        }

        public override string ToString()
        {
            return String.Format("MORTGAGE - {0} - {1:C}", this.Client.Name, this.Balance);
        }
    }
}
