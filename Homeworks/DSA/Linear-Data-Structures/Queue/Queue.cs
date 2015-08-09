namespace Queue
{
    using System;
    using System.Collections.Generic;

    class Queue<T>
    {
        private LinkedList<T> queue;

        public Queue()
        {
            this.queue = new LinkedList<T>();
        }

        public int Count { get { return this.queue.Count; } }

        public void Enqueue(T element)
        {
            this.queue.AddLast(element);
        }

        public T Peek()
        {
            if (this.queue.Count == 0)
            {
                throw new ArgumentException("The queue does not contain any elements.");
            }

            return this.queue.First.Value;
        }

        public T Dequeue()
        {
            T element = this.Peek();
            this.queue.RemoveFirst();
            return element;
        }
    }
}
