namespace Hash.Tests
{
    using HashSetImplementation;
    using NUnit.Framework;

    [TestFixture]
    public class HashedSetTests
    {
        [Test]
        public void ShouldCreateObjectInstanceWithCorrectDefaultValues()
        {
            var set = new HashedSet<int>();
            Assert.AreEqual(0, set.Count);
        }

        [Test]
        public void ShouldCorrectlyAddAllValues()
        {
            var set = new HashedSet<int>();
            set.Add(1);
            set.Add(3);
            set.Add(5);
            set.Add(7);
            set.Add(9);

            Assert.AreEqual(5, set.Count);
        }

        [Test]
        public void ShouldNotAddDuplicateValues()
        {
            var set = new HashedSet<int>();
            set.Add(1);
            set.Add(1);
            set.Add(1);
            set.Add(1);
            set.Add(1);

            Assert.AreEqual(1, set.Count);
        }
        
        [Test]
        public void ShouldReturnCorrectIntersection()
        {
            var set = new HashedSet<int>();
            set.Add(1);
            set.Add(2);
            var otherSet = new HashedSet<int>();
            otherSet.Add(2);
            otherSet.Add(3);

            CollectionAssert.AreEqual(new[] { 2 }, set.IntersectsWith(otherSet));
        }

        [Test]
        public void ShouldReturnCorrectUnion()
        {
            var set = new HashedSet<int>();
            set.Add(1);
            set.Add(2);
            var otherSet = new HashedSet<int>();
            otherSet.Add(2);
            otherSet.Add(3);

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, set.Union(otherSet));
        }

        [Test]
        public void ShouldRemoveElementsCorrectly()
        {
            var set = new HashedSet<int>();
            set.Add(5);
            Assert.AreEqual(1, set.Count);
            set.Remove(5);
            Assert.AreEqual(0, set.Count);
        }
    }
}
