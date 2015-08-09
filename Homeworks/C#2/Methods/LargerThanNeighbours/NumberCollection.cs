
namespace LargerThanNeighbours
{
    using System;
    using System.Text;
    public class NumberCollection
    {
        private int[] numbers;
        private int length;

        public NumberCollection(int[] arrayOfNumbers)
        {
            this.NumberArray = arrayOfNumbers;
            this.Length = arrayOfNumbers.Length;
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

        public int[] NumberArray 
        {
            get
            {
                return this.numbers;
            }
            private set
            {
                this.numbers = value;
            }
        }

        public bool IsGreaterThanNeighbours(int position)
        {
            if (position < 0 || position >= this.Length)
            {
                throw new IndexOutOfRangeException();
            }
            int number = this.NumberArray[position];

            if (position > 0)
            {
                if (number.CompareTo(this.NumberArray[position - 1]) < 1)
                {
                    return false;
                }
            }

            if (position < this.Length - 1)
            {
                if (number.CompareTo(this.NumberArray[position + 1]) < 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
