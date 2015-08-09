namespace Poker.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HandTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HandThrowsExceptionWhenListOfCardsIsNull()
        {
            IList<ICard> cards = null;
            var hand = new Hand(cards);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HandThrowsExceptionWhenListOfCardsContainsNull()
        {
            IList<ICard> cards = new List<ICard>() { new Card(CardFace.Queen, CardSuit.Hearts), null };
            var hand = new Hand(cards);
        }

        [TestMethod]
        public void HandReturnsCorrectToString()
        {
            IList<ICard> cards = new List<ICard>() { new Card(CardFace.Queen, CardSuit.Hearts), new Card(CardFace.King, CardSuit.Hearts) };
            var hand = new Hand(cards);
            var expected = "Queen of Hearts | King of Hearts";
            Assert.AreEqual(expected, hand.ToString());
        }
    }
}