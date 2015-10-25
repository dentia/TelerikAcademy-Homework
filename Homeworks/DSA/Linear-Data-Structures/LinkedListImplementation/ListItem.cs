namespace LinkedListImplementation
{
    public class ListItem<T>
    {
        public ListItem(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public ListItem<T> NextItem { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
