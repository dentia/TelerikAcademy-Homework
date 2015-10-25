namespace QueueImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedQueue<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> internalList;

        public LinkedQueue()
        {
            this.internalList = new LinkedList<T>();
        }

        public int Count
        {
            get
            {
                return this.internalList.Count;
            }
        }

        public void Enqueue(T item)
        {
            this.internalList.AddLast(item);
        }

        public T Dequeue()
        {
            if (this.internalList.Count == 0)
            {
                throw new InvalidOperationException("No items to dequeue.");
            }

            var item = this.internalList.First;
            this.internalList.RemoveFirst();

            return item.Value;
        }

        public T Peek()
        {
            if (this.internalList.Count == 0)
            {
                throw new InvalidOperationException("No items to show.");
            }

            return this.internalList.First.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.internalList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
