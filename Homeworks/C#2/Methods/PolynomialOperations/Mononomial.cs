
namespace PolynomialOperations
{
    using System;
    class Mononomial
    {
        private uint power;
        private decimal coefficient;

        public Mononomial(decimal coefficient, uint power)
        {
            this.Coefficient = coefficient;
            this.Power = power;
        }

        public uint Power
        {
            get
            {
                return this.power;
            }
            private set
            {
                this.power = value;
            }
        }

        public decimal Coefficient
        {
            get
            {
                return this.coefficient;
            }
            private set
            {
                this.coefficient = value;
            }
        }
    }
}
