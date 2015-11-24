namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (var ind = 0; ind < this.Items.Count; ind++)
            {
                if (this.Items[ind].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            return this.BinarySearchRecursive(item, 0, this.Items.Count - 1);
        }

        // O(n)
        public void Shuffle()
        {
            var provider = new RNGCryptoServiceProvider();
            var n = this.Items.Count;
            while (n > 1)
            {
                var box = new byte[1];
                do
                {
                    provider.GetBytes(box);
                }
                while (!(box[0] < n * (byte.MaxValue / n)));

                var k = box[0] % n;
                n--;
                var value = this.Items[k];
                this.Items[k] = this.Items[n];
                this.Items[n] = value;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (var i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }

        private bool BinarySearchRecursive(T key, int min, int max)
        {
            if (min > max)
            {
                return false;
            }
            else
            {
                var mid = (min + max) / 2;
                if (this.Items[mid].CompareTo(key) == 0)
                {
                    return true;
                }
                else if (this.Items[mid].CompareTo(key) > 0)
                {
                    return this.BinarySearchRecursive(key, min, mid - 1);
                }
                else
                {
                    return this.BinarySearchRecursive(key, mid + 1, max);
                }
            }
        }
    }
}
