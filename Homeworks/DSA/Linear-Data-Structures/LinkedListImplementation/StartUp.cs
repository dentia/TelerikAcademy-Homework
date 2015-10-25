namespace LinkedListImplementation
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var list = new LinkedList<int>();
            var firstItem = new ListItem<int>(1);
            list.FirstItem = firstItem;
            firstItem.NextItem = new ListItem<int>(2);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
