
namespace NumbersAsArray
{
    using System;
    using System.Linq;
    class BigNumber
    {
        const int MAX_LENGTH = 10001;
        const char ZERO = '0';
        private string number;
        private int length;

        public BigNumber(string number)
        {
            this.Number = number;
            this.Length = this.Number.Length;
        }

        string Number
        {
            get
            {
                return this.number;
            }

            set
            {
                if (value.Any(x => !Char.IsDigit(x)))
                {
                    throw new FormatException("The number must be positive and contain only digits.");
                }

                this.number = value;
            }
        }

        public int Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                this.length = value;
            }
        }

        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            int maxLength = Math.Max(a.Length, b.Length)+1;
            char[] result = new char[maxLength];
            char[] aArr = a.ToString().PadLeft(maxLength, ZERO).ToCharArray();
            char[] bArr = b.ToString().PadLeft(maxLength, ZERO).ToCharArray();
            aArr = aArr.Reverse().ToArray();
            bArr = bArr.Reverse().ToArray();

            int tempSum;
            int tens = 0;

            for (int index = 0; index < result.Length; index++)
            {
                tempSum = (aArr[index] - ZERO) + (bArr[index] - ZERO) + tens;
                tens = tempSum / 10;
                tempSum %= 10;

                result[index] = (char)(tempSum + ZERO);
            }

            result = result.Reverse().ToArray();

            return new BigNumber(new String(result).TrimStart('0'));
        }

        public override string ToString()
        {
            return this.Number;
        }
    }
}
