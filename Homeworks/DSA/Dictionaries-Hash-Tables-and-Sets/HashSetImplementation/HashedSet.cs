namespace HashSetImplementation
{
    using System.Collections;
    using System.Collections.Generic;

    using HashTableImplementation;

    public class HashedSet<T> : IEnumerable<T>
    {
        private CustomHashTable<int, T> elements;

        public HashedSet()
        {
            this.elements = new CustomHashTable<int, T>();
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Add(T element)
        {
            this.elements.Add(element.GetHashCode(), element);
        }

        public void Remove(T element)
        {
            this.elements.Remove(element.GetHashCode());
        }
        
        public void Clear()
        {
            this.elements.Clear();
        }

        public T Find(T element)
        {
            T elementToReturn;

            if (this.elements.Find(element.GetHashCode(), out elementToReturn))
            {
                return elementToReturn;
            }

            return default(T);
        }

        public HashedSet<T> IntersectsWith(HashedSet<T> other)
        {
            var result = new HashedSet<T>();

            foreach (var myNode in this)
            {
                foreach (var otherNode in other)
                {
                    if (myNode.Equals(otherNode))
                    {
                        result.Add(myNode);
                    }
                }
            }

            return result;
        }

        public HashedSet<T> Union(HashedSet<T> other)
        {
            var result = new HashedSet<T>();

            foreach (var myNode in this)
            {
                result.Add(myNode);
            }

            foreach (var otherNode in other)
            {
                result.Add(otherNode);
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var pair in this.elements)
            {
                yield return pair.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(", ", this);
        }
    }
}
