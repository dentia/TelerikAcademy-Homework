// Implement the ADT queue as dynamic linked list.
// Use generics (LinkedQueue<T>) to allow storing
// different data types in the queue.

namespace Queue
{
    class QueueTest
    {
        static void Main()
        {
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            System.Console.WriteLine("Count: " + queue.Count);

            while (queue.Count > 0)
            {
                System.Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
