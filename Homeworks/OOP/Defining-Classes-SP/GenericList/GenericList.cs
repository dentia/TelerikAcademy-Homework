
namespace GenericList
{
    using System;
    using System.Text;
    public class GenericList<T>
        where T : IComparable
    {
        private T[] list;
        private int lastInd;

        public GenericList(int size)
        {
            this.list = new T[size];
            this.lastInd = -1;
        }

        public int Count
        {
            get
            {
                return this.lastInd + 1;
            }
        }

        public T Max()
        {
            T result = default(T);

            if (this.Count > 0)
            {
                result = this.list[0];

                for (int ind = 1; ind <= this.lastInd; ind++)
                {
                    if (result.CompareTo(this.list[ind]) < 0)
                    {
                        result = this.list[ind];
                    }
                }
            }

            return result;
        }

        public T Min()
        {
            T result = default(T);

            if (this.Count > 0)
            {
                result = this.list[0];

                for (int ind = 1; ind <= this.lastInd; ind++)
                {
                    if (result.CompareTo(this.list[ind]) > 0)
                    {
                        result = this.list[ind];
                    }
                }
            }

            return result;
        }

        public T this[int index]
        {
            get
            {
                CheckRange(index);
                return this.list[index];
            }
            set
            {
                CheckRange(index);
                this.list[index] = value;
            }
        }

        public void Add(T element)
        {
            if (lastInd + 1 == this.list.Length)
            {
                DoubleListSize();
            }

            this.list[++lastInd] = element;
        }

        public void InsertAt(int index, T element)
        {
            CheckRange(index);

            if (lastInd + 1 == this.list.Length)
            {
                DoubleListSize();
            }

            for (int ind = this.lastInd + 1; ind > index; ind--)
            {
                this.list[ind] = this.list[ind - 1];
            }
            this.list[index] = element;
            ++lastInd;
        }

        public void RemoveAt(int index)
        {
            CheckRange(index);

            for (int ind = index + 1; ind <= this.lastInd; ind++)
            {
                this.list[ind - 1] = this.list[ind];
            }

            this.list[this.lastInd--] = default(T);
        }

        public int IndexOf(T element)
        {
            int index = -1;

            for (int ind = 0; ind <= this.lastInd; ind++)
            {
                if (this.list[ind].Equals(element))
                {
                    index = ind;
                    break;
                }
            }

            return index;
        }

        public void Clear()
        {
            for (int ind = 0; ind <= this.lastInd; ind++)
            {
                this.list[ind] = default(T);
            }

            this.lastInd = -1;
        }

        private void DoubleListSize()
        {
            int newSize = (this.list.Length == 0) ? 2 : this.list.Length * 2;

            T[] newList = new T[newSize];
            for (int ind = 0; ind <= this.lastInd; ind++)
            {
                newList[ind] = this.list[ind];
            }

            this.list = newList;
        }

        private void CheckRange(int index)
        {
            if (index < 0 || index > this.lastInd)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int ind = 0; ind <= this.lastInd; ind++)
            {
                result.AppendLine(String.Format("{0,-5}{1}", String.Format("[{0}]", ind), this.list[ind]));
            }

            return result.ToString().Trim();
        }
    }
}
