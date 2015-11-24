namespace Algorithms.Tests
{
    using System.Security.Cryptography.X509Certificates;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SortingAndSearchingAlgorithms;

    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void ShouldReturnTrueWhenElementExists()
        {
            var collection = new SortableCollection<int>(new[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 });
            Assert.IsTrue(collection.BinarySearch(4));
        }

        [TestMethod]
        public void ShouldReturnFalseWhenElementDoesntExist()
        {
            var collection = new SortableCollection<int>(new[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 });
            Assert.IsFalse(collection.BinarySearch(24));
        }
    }
}
