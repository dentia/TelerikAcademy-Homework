namespace StackImplementation
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var stack = new CustomStack<int>();
            new List<int> { 1, 2, 3, 4, 5 }.ForEach(x => stack.Push(x));

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
