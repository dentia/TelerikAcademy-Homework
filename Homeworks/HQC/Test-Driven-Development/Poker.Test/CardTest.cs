namespace Poker.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CardShouldCompareCardsCorrectly_EqualCard()
        {
            var cardA = new Card(CardFace.Jack, CardSuit.Spades);
            var cardB = new Card(CardFace.Jack, CardSuit.Spades);

            Assert.IsTrue(cardA.Equals(cardB));
        }

        [TestMethod]
        public void CardShouldCompareCardsCorrectly_DifferentCards()
        {
            var cardA = new Card(CardFace.Jack, CardSuit.Spades);
            var cardB = new Card(CardFace.Queen, CardSuit.Hearts);

            Assert.IsFalse(cardA.Equals(cardB));
        }

        [TestMethod]
        public void CardShouldReturnToStringCorrectly()
        {
            var card = new Card(CardFace.Jack, CardSuit.Spades);
            var expected = "Jack of Spades";

            Assert.AreEqual(expected, card.ToString());
        }
    }
}
