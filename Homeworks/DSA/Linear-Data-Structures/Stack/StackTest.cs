// Implement the ADT stack as auto-resizable array.
// Resize the capacity on demand (when no space is
// available to add / insert a new element).

namespace Stack
{
    class StackTest
    {
        static void Main()
        {
            Stack<int> stack = new Stack<int>(2);

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            System.Console.WriteLine("Count: " + stack.Count);

            while (stack.Count > 0)
            {
                System.Console.WriteLine(stack.Pop());
            }
        }
    }
}
