
namespace NumberCalculations
{
    using System;
    using System.Numerics;
    using System.Linq;
    class NumberSequence<T>
        where T : IComparable
    {
        private T[] numbers;
        private T min;
        private T max;
        private T sum;
        private T product;
        private T average;

        public NumberSequence(T[] numbers)
        {
            this.numbers = numbers;
            GetResults();
        }

        public T Min
        {
            get
            {
                return this.min;
            }
            private set
            {
                this.min = value;
            }
        }

        public T Max
        {
            get
            {
                return this.max;
            }
            private set
            {
                this.max = value;
            }
        }

        public T Sum
        {
            get
            {
                return this.sum;
            }
            private set
            {
                this.sum = value;
            }
        }

        public T Product
        {
            get
            {
                return this.product;
            }
            private set
            {
                this.product = value;
            }
        }

        public T Average
        {
            get
            {
                return this.average;
            }
            private set
            {
                this.average = value;
            }
        }

        private void GetResults()
        {
            this.Min = this.numbers.Min();
            this.Max = this.numbers.Max();
            dynamic product = 1;
            dynamic sum = 0;

            foreach (var number in numbers)
            {
                product *= number;
                sum += number;
            }

            this.Product = (T)product;
            this.Sum = (T)sum;
            this.Average = (T)(this.sum / (dynamic)this.numbers.Length);
        }

        public override string ToString()
        {
            return String.Format(@"
[{5}]
MIN:    {0, -15} SUM:    {2, -15}
MAX:    {1, -15} PROD:   {3, -15}
AVG:    {4}
", this.Min, this.Max, this.Sum, this.Product, 
 this.Average, String.Join(", ", this.numbers));
        }
    }
}
