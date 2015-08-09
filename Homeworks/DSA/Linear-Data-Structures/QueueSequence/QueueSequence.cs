// We are given the following sequence:
// S1 = N;
// S2 = S1 + 1;
// S3 = 2*S1 + 1;
// S4 = S1 + 2;
// S5 = S2 + 1;
// S6 = 2*S2 + 1;
// S7 = S2 + 2;
// ...
// Using the Queue<T> class write a program to print
// its first 50 members for given N.
// Example: N=2 -> 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

namespace QueueSequence
{
    using System;
    using System.Collections.Generic;
    class QueueSequence
    {
        static void Main()
        {
            List<int> sequence = GetSequence(2, 50);
            Console.WriteLine(string.Join(", ", sequence));
        }

        private static List<int> GetSequence(int starNum, int length)
        {
            List<int> sequence = new List<int>(){starNum};
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(starNum);
            int steps = 0;
            int workingNum = starNum;

            while (steps < length - 1)
            {
                switch (steps % 3)
                {
                    case 0: workingNum = queue.Dequeue();
                        queue.Enqueue(workingNum + 1);
                        sequence.Add(workingNum + 1);
                        break;
                    case 1:
                        queue.Enqueue(2 * workingNum + 1);
                        sequence.Add(2 * workingNum + 1);
                        break;
                    case 2:
                        queue.Enqueue(workingNum + 2);
                        sequence.Add(workingNum + 2);
                        break;
                }

                ++steps;
            }

            return sequence;
        }
    }
}
