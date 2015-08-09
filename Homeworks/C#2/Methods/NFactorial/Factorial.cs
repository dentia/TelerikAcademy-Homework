
namespace NFactorial
{
    using System;
    using System.Numerics;
    class Factorial
    {
        private BigInteger[] factorial;
        private int range;

        public Factorial(int range)
        {
            this.Range = range;
            this.factorial = new BigInteger[range + 1];
            this.factorial[0] = new BigInteger(1);

            CalculateFactorials();
        }

        public int Range
        {
            get
            {
                return this.range;
            }
            private set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException
                        ("range must be positive and less than 100");
                }

                this.range = value;
            }
        }

        public BigInteger this[int number]
        {
            get
            {
                if (number < 0 || number > this.Range)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.factorial[number];
            }
        }

        public void CalculateFactorials()
        {
            for (int number = 1; number <= this.Range; number++)
            {
                this.factorial[number] = this.factorial[number - 1] * number;
            }
        }

        public BigInteger Get(int number)
        {
            return this.factorial[number];
        }
    }
}
