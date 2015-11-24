namespace Algorithms.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SortingAndSearchingAlgorithms;

    [TestClass]
    public class MergeSorterTests
    {
        [TestMethod]
        public void ShouldSortCorrectlySortedCollection()
        {
            var collection = new SortableCollection<int>(new[] { 1, 2, 3, 4, 5, 6, 7 });
            var expectedCollection = new List<int>(collection.Items);
            expectedCollection.Sort();
            collection.Sort(new MergeSorter<int>());
            CollectionAssert.AreEqual(expectedCollection, collection.Items.ToList());
        }

        [TestMethod]
        public void ShouldSortCorrectlyDoubles()
        {
            var collection = new SortableCollection<double>(new[] { 1.4, -8.6, 2, 13.1, 13.2, 55, 55, 55.1, 55.01 });
            var expectedCollection = new List<double>(collection.Items);
            expectedCollection.Sort();
            collection.Sort(new MergeSorter<double>());
            CollectionAssert.AreEqual(expectedCollection, collection.Items.ToList());
        }

        [TestMethod]
        public void ShouldSortCorrectlyOnlyNegativeValues()
        {
            var collection = new SortableCollection<double>(new[] { -1.4, -8.6, -2, -13.1, -13.2, -55, -55, -55.1, -55.01 });
            var expectedCollection = new List<double>(collection.Items);
            expectedCollection.Sort();
            collection.Sort(new MergeSorter<double>());
            CollectionAssert.AreEqual(expectedCollection, collection.Items.ToList());
        }

        [TestMethod]
        public void ShouldSortCorrectlyCharacters()
        {
            var collection = new SortableCollection<char>(new[] { 'a', 'c', 'b' });
            collection.Sort(new MergeSorter<char>());
            CollectionAssert.AreEqual(new[] { 'a', 'b', 'c' }, collection.Items.ToArray());
        }
    }
}
