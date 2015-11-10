namespace BiDictionary
{
    using System;
    using System.Collections.Generic;

    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, V>
    {
        private readonly MultiDictionary<K1, V> firstKeyDictionary;
        private readonly MultiDictionary<K2, V> secondKeyDictionary;
        private readonly MultiDictionary<Tuple<K1, K2>, V> bothKeyDictionary;

        public BiDictionary(bool allowDuplictes)
        {
            this.firstKeyDictionary = new MultiDictionary<K1, V>(allowDuplictes);
            this.secondKeyDictionary = new MultiDictionary<K2, V>(allowDuplictes);
            this.bothKeyDictionary = new MultiDictionary<Tuple<K1, K2>, V>(allowDuplictes);
        }

        public void Add(K1 key1, K2 key2, V value)
        {
            this.firstKeyDictionary.Add(key1, value);
            this.secondKeyDictionary.Add(key2, value);
            this.bothKeyDictionary.Add(new Tuple<K1, K2>(key1, key2), value);
        }

        public ICollection<V> FindByFirstKey(K1 key)
        {
            return this.firstKeyDictionary[key];
        }

        public ICollection<V> FindBySecondKey(K2 key)
        {
            return this.secondKeyDictionary[key];
        }

        public ICollection<V> FindByBothKeys(K1 key1, K2 key2)
        {
            return this.bothKeyDictionary[new Tuple<K1, K2>(key1, key2)];
        }
    }
}
