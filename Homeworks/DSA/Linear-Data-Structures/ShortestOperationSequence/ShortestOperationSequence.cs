// We are given numbers N and M and the following
// operations:
// a) N = N+1
// b) N = N+2
// c) N = N*2
// Write a program that finds the shortest sequence of
// operations from the list above that starts from N
// and finishes in M. Hint: use a queue.
//  Example: N = 5, M = 16
//  Sequence: 5 -> 7 -> 8 -> 16

namespace ShortestOperationSequence
{
    using System;
    using System.Collections.Generic;

    class ShortestOperationSequence
    {
        static void Main()
        {
            Console.WriteLine(string.Join(" -> ", GetSequence(19, 1402)));
        }

        private static Stack<int> GetSequence(int n, int m)
        {
            Stack<int> sequence = new Stack<int>();
            int workingNumber = m;
            sequence.Push(workingNumber);

            while (workingNumber > n)
            {
                if (workingNumber / 2 >= n)
                {
                    if (workingNumber % 2 == 0)
                    {
                        workingNumber /= 2;
                    }
                    else
                    {
                        workingNumber--;
                    }
                }
                else
                {
                    if (workingNumber - 2 >= n)
                    {
                        workingNumber -= 2;
                    }
                    else
                    {
                        workingNumber--;
                    }
                }
                sequence.Push(workingNumber);
            }

            return sequence;
        }
    }
}
