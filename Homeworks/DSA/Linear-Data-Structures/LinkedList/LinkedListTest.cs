// Implement the data structure linked list. Define a
// class ListItem<T> that has two fields: value (of
// type T) and NextItem (of type ListItem<T>).
// Define additionally a class LinkedList<T> with a
// single field FirstElement (of type ListItem<T>).

namespace LinkedList
{
    class LinkedListTest
    {
        static void Main()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.FirstElement = new ListItem<int>(12);
            list.FirstElement.NextItem = new ListItem<int>(13);
            list.FirstElement.NextItem.NextItem = new ListItem<int>(14);
            list.FirstElement.NextItem.NextItem.NextItem = new ListItem<int>(15);

            var current = list.FirstElement;
            while (current != null)
            {
                System.Console.WriteLine(current.Value);
                current = current.NextItem;
            }
        }
    }
}
