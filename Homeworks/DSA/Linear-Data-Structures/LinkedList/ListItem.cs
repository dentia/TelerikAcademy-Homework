// Define a class ListItem<T> that has two fields: value (of
// type T) and NextItem (of type ListItem<T>). 

namespace LinkedList
{
    class ListItem<T>
    {
        public ListItem(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public ListItem<T> NextItem { get; set; }
    }
}
