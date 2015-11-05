namespace Hash.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using HashTableImplementation;
    using NUnit.Framework;

    [TestFixture]
    public class HashTableTests
    {
        [Test]
        public void ShouldCreateObjectInstanceWithRightDefaultParameters()
        {
            var table = new CustomHashTable<int, int>();
            Assert.AreEqual(0, table.Count);
        }

        [Test]
        public void ShouldAddCorrectNumberOfElements()
        {
            var table = new CustomHashTable<int, int>();
            table.Add(1, 1);
            table.Add(2, 2);
            table.Add(3, 3);
            Assert.AreEqual(3, table.Count);
        }

        [Test]
        public void ShouldReturnCorrectValueByKey()
        {
            var table = new CustomHashTable<int, int>();
            table.Add(1, 111);
            var result = 0;
            var found = table.Find(1, out result);

            Assert.AreEqual(111, result);
            Assert.IsTrue(found);
        }

        [Test]
        public void ShouldReturnDefaultValueWhenKey()
        {
            var table = new CustomHashTable<int, int>();
            table.Add(1, 111);
            var result = 555;
            var found = table.Find(8, out result);

            Assert.AreEqual(default(int), result);
            Assert.IsFalse(found);
        }

        [Test]
        public void ShouldAutoResizeInnerCollection()
        {
            var table = new CustomHashTable<int, int>(1);
            table.Add(1, 111);
            table.Add(2, 211);
            table.Add(3, 131);

            Assert.AreEqual(3, table.Count);
        }

        [Test]
        public void ShouldReturnKeysCorrectly()
        {
            var table = new CustomHashTable<int, int>();
            var keys = new[] { 1, 2, 3 };

            foreach (int key in keys)
            {
                table.Add(key, key * 100);
            }

            CollectionAssert.AreEqual(keys, table.Keys);
        }

        [Test]
        public void ShouldReturnDefaultValueAfterElementIsRemoved()
        {
            var table = new CustomHashTable<int, int>();
            table.Add(7, 7);
            int result;

            Assert.IsTrue(table.Find(7, out result));
            table.Remove(7);
            Assert.IsFalse(table.Find(7, out result));
            Assert.AreEqual(default(int), result);
        }

        [Test]
        public void ShouldIterateCorrectly()
        {
            var result = new List<KeyValuePair<int, int>>();
            var keys = new[] { 1, 3, 5, 7, 9 };
            var values = new[] { 10, 30, 50, 70, 90 };

            var table = new CustomHashTable<int, int>();
            foreach (var key in keys)
            {
                table.Add(key, key * 10);
            }

            foreach (var pair in table)
            {
                result.Add(pair);
            }

            Assert.AreEqual(keys, result.Select(x => x.Key));
            Assert.AreEqual(values, result.Select(x => x.Value));
        }
    }
}
