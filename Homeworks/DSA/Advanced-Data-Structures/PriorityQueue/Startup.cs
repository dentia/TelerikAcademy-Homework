namespace PriorityQueue
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            MinQueueTest();
            Console.WriteLine();
            MaxQueueTest();
        }

        private static void MinQueueTest()
        {
            Console.WriteLine("Min priority: ");
            var queue = new PriorityQueue<int>(true);

            Console.WriteLine("Count: " + queue.Count);

            queue.Enqueue(9);
            queue.Enqueue(7);
            queue.Enqueue(5);
            queue.Enqueue(3);
            queue.Enqueue(1);

            Console.WriteLine("Count: " + queue.Count);

            Console.WriteLine("Dequeue:");

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }

        private static void MaxQueueTest()
        {
            Console.WriteLine("Max priority: ");
            var queue = new PriorityQueue<int>(false);

            Console.WriteLine("Count: " + queue.Count);

            queue.Enqueue(0);
            queue.Enqueue(2);
            queue.Enqueue(4);
            queue.Enqueue(6);
            queue.Enqueue(8);

            Console.WriteLine("Count: " + queue.Count);

            Console.WriteLine("Dequeue:");

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
