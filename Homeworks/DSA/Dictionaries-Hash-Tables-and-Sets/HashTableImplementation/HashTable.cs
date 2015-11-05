namespace HashTableImplementation
{
    using System;
    using System.Collections;
        using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CustomHashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private const int InitialCapacity = 16;
        private const double LoadFactor = 0.75;

        private LinkedList<KeyValuePair<K, V>>[] elements;
        private ICollection<K> keys;
        private int elementsCounter;

        public CustomHashTable(int capacity)
        {
            this.elements = new LinkedList<KeyValuePair<K, V>>[capacity];
            this.elementsCounter = 0;
            this.Count = 0;
            this.keys = new HashSet<K>();
        }

        public CustomHashTable()
            : this(InitialCapacity)
        {
        }

        public int Count { get; private set; }

        public ICollection<K> Keys
        {
            get
            {
                return this.keys;
            }
        }

        public V this[K key]
        {
            get
            {
                V value = default(V);

                if (!this.Find(key, out value))
                {
                    throw new KeyNotFoundException("No such key can be found.");
                }

                return value;
            }

            set
            {
                this.Add(key, value);
            }
        }
        
        public void Add(K key, V value)
        {
            this.ResizeIfNeeded();

            this.keys.Add(key);

            var pairToAdd = new KeyValuePair<K, V>(key, value);
            var position = this.GetPosition(key);

            if (this.elements[position] == null)
            {
                this.elements[position] = new LinkedList<KeyValuePair<K, V>>();
                this.elements[position].AddFirst(pairToAdd);
                
                this.Count++;
            }
            else
            {
                this.Remove(key);

                if (this.elements[position].Count == 0)
                {
                    this.Count++;
                }

                this.elements[position].AddLast(pairToAdd);
            }

            this.elementsCounter++;
        }

        public void Remove(K key)
        {
            var position = this.GetPosition(key);
            V valueToRemove = default(V);

            if (this.Find(key, out valueToRemove))
            {
                var pairToRemove = this.elements[position].First(x => x.Key.Equals(key));
                this.elements[position].Remove(pairToRemove);
                this.elementsCounter--;
                this.keys.Remove(key);

                if (this.elements[position].Count == 0)
                {
                    this.Count--;
                }
            }
        }

        public void Clear()
        {
            this.elements = new LinkedList<KeyValuePair<K, V>>[this.elements.Length];
            this.keys = new HashSet<K>();
            this.Count = 0;
            this.elementsCounter = 0;
        }

        public bool Find(K key, out V value)
        {
            int position = this.GetPosition(key);
            if (this.elements[position] != null && this.elements[position].Count != 0)
            {
                foreach (var pair in this.elements[position])
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        return true;
                    }
                }
            }

            value = default(V);
            return false;
        }
        
        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var list in this.elements)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        yield return pair;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var pair in this)
            {
                result.AppendFormat("K: {0}; V: {1}\t|\t", pair.Key, pair.Value);
            }

            return result.ToString().TrimEnd(new[] { '\t', ' ', '|' });
        }

        private int GetPosition(K key)
        {
            return Math.Abs(key.GetHashCode() % this.elements.Length);
        }

        private void ResizeIfNeeded()
        {
            if (this.elementsCounter >= this.elements.Length * LoadFactor)
            {
                var newCustomHashTable = new CustomHashTable<K, V>(this.elements.Length * 2);

                foreach (var pair in this)
                {
                    newCustomHashTable.Add(pair.Key, pair.Value);
                }

                this.elements = newCustomHashTable.elements;
            }
        }
    }
}
