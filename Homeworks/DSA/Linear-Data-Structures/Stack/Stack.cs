namespace Stack
{
    using System;

    class Stack<T>
    {
        private const int InitialSize = 5;
        private int size;
        private int pointer;
        private T[] stack;


        public Stack(int size = Stack<T>.InitialSize)
        {
            this.size = size;
            if (this.size < 0)
            {
                throw new ArgumentException("Size cannot be negative.");
            }

            this.pointer = -1;
            this.stack = new T[this.size];
        }

        public int Count { get { return this.pointer + 1; } }

        public void Push(T element)
        {
            ++this.pointer;
            if (this.pointer == this.size)
            {
                this.DoubleSize();
            }

            this.stack[this.pointer] = element;
        }

        public T Peek()
        {
            if (this.pointer < 0)
            {
                throw new NullReferenceException("The stack does not contain any elements.");
            }

            return this.stack[this.pointer];
        }

        public T Pop()
        {
            this.pointer--;

            try
            {
                return this.stack[this.pointer + 1];
            }
            catch (IndexOutOfRangeException)
            {
                throw new NullReferenceException("The stack does not contain any elements.");
            }
        }

        private void DoubleSize()
        {
            T[] tmp = new T[this.size * 2];
            Array.Copy(this.stack, tmp, this.stack.Length);
            this.stack = tmp;
            this.size = this.stack.Length;
        }
    }
}
