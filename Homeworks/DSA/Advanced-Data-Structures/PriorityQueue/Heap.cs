namespace PriorityQueue
{
    using System;

    public class Heap<T> where T : IComparable<T>
    {
        private const int InitialCapacity = 16;

        private readonly bool isMin;

        private T[] elements;
        private int currentIndex = -1;

        public Heap(bool isMinPriority)
        {
            this.elements = new T[InitialCapacity];
            this.isMin = isMinPriority;
        }

        public int Count
        {
            get
            {
                return this.currentIndex + 1;
            }
        }

        public T First()
        {
            return this.elements[0];
        }

        public void Add(T element)
        {
            this.ResizeIfNeeded();
            this.elements[++this.currentIndex] = element;
            this.RearangeOnAdd(this.currentIndex);
        }

        public void DeleteFirst()
        {
            var element = this.elements[0];
            this.elements[0] = this.elements[this.currentIndex];
            this.elements[this.currentIndex] = element;

            this.currentIndex--;
            this.RearangeOnDelete(0);
        }

        public override string ToString()
        {
            return string.Join(", ", this.elements);
        }

        private void RearangeOnAdd(int index)
        {
            var parentIndex = index / 2;
            var comparedToParent = this.elements[index].CompareTo(this.elements[parentIndex]);

            if (this.isMin ? comparedToParent < 0 : comparedToParent > 0)
            {
                var currentElement = this.elements[index];
                this.elements[index] = this.elements[parentIndex];
                this.elements[parentIndex] = currentElement;

                this.RearangeOnAdd(parentIndex);
            }
        }

        private void RearangeOnDelete(int index)
        {
            var left = (index * 2) + 1;
            var right = left + 1;

            if (left <= this.currentIndex)
            {
                var comparedToLeft = this.elements[index].CompareTo(this.elements[left]);

                if (this.isMin ? comparedToLeft > 0 : comparedToLeft < 0)
                {
                    var element = this.elements[index];
                    this.elements[index] = this.elements[left];
                    this.elements[left] = element;

                    this.RearangeOnDelete(left);
                }
                else if (right <= this.currentIndex)
                {
                    var element = this.elements[index];
                    this.elements[index] = this.elements[right];
                    this.elements[right] = element;

                    this.RearangeOnDelete(right);
                }
            }
        }

        private void ResizeIfNeeded()
        {
            if (this.currentIndex + 1 == this.elements.Length)
            {
                var newElements = new T[this.elements.Length * 2];

                for (int ind = 0; ind < this.elements.Length; ind++)
                {
                    newElements[ind] = this.elements[ind];
                }

                this.elements = newElements;
            }
        }
    }
}
