
namespace BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    class BitArray : IEnumerable<int>, IComparable
    {
        private ulong number;

        public BitArray(ulong number)
        {
            this.Number = number;
        }

        public ulong Number
        {
            get { return number; }
            set { number = value; }
        }

        public int this[int pos]
        {
            get
            {
                if (pos < 0 || pos >= 64)
                {
                    throw new IndexOutOfRangeException("Invalid position.");
                }

                return ((int)(this.Number >> pos) & 1);
            }
            set
            {
                if (pos < 0 || pos >= 64)
                {
                    throw new IndexOutOfRangeException("Invalid position.");
                }

                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("Invalid bit value.");
                }

                if (((int)(this.Number >> pos) & 1) != value)
                {
                    this.Number ^= (1ul << pos);
                }
            }
        }

        public static bool operator ==(BitArray ba1, BitArray ba2)
        {
            return (ba1.Equals(ba2));
        }

        public static bool operator !=(BitArray ba1, BitArray ba2)
        {
            return !(ba1.Equals(ba2));
        }



        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int pos = 0; pos < 64; pos++)
            {
                result.Insert(0, ((this.Number >> pos) & 1));
            }

            return result.ToString();
        }

        public override int GetHashCode()
        {
            return this.Number.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Number.Equals((obj as BitArray).Number);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int pos = 0; pos < 64; pos++)
            {
                yield return this[pos];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int CompareTo(object obj)
        {
            return this.Number.CompareTo((obj as BitArray).Number);
        }
    }
}
