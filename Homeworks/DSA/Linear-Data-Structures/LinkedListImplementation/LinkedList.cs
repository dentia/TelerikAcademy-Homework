namespace LinkedListImplementation
{
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedList()
        {
        }

        public LinkedList(ListItem<T> firstItem)
        {
            this.FirstItem = firstItem;
        }

        public ListItem<T> FirstItem { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            var currentItem = this.FirstItem;

            while (currentItem != null)
            {
                yield return currentItem.Value;

                currentItem = currentItem.NextItem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
