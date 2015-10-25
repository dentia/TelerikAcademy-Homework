namespace QueueImplementation
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var queue = new LinkedQueue<int>();
            new List<int> { 1, 2, 3, 4, 5 }.ForEach(x => queue.Enqueue(x));

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
