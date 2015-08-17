using NUnit.Framework;
using Santase.Logic.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santase.Tests
{
    [TestFixture]
    class DeckTests
    {
        private const int DeckSize = 24;

        [Test]
        [ExpectedException]
        public void DrawNextCardOnEmptyDeck_ShouldThrowException()
        {
            var deck = new Deck();

            for (int card = 0; card <= DeckSize; card++)
            {
                deck.GetNextCard();
            }
        }

        [TestCase(4)]
        [TestCase(8)]
        [TestCase(15)]
        [TestCase(17)]
        [TestCase(24)]
        public void ExpectedDeckToReturnNDifferentCards(int count)
        {
            var deck = new Deck();
            var cards = new List<Card>();

            for (int card = 0; card < count; card++)
            {
                cards.Add(deck.GetNextCard());
            }

            var comparer = new CardComparer();
            cards = cards.Distinct(comparer).ToList();

            Assert.AreEqual(count, cards.Count);
        }

        [Test]
        public void TwoEqualCardsAreConsideredTheSame()
        {
            var first = new Card(CardSuit.Club, CardType.Ace);
            var second = new Card(CardSuit.Club, CardType.Ace);

            Assert.AreEqual(first, second);
        }

        [Test]
        public void DistinctOnTwoCardsReturnsLenghtOf1()
        {
            var cards = new List<Card>() { new Card(CardSuit.Diamond, CardType.King), new Card(CardSuit.Diamond, CardType.King) };
            var comparer = new CardComparer();
            cards = cards.Distinct(comparer).ToList();

            Assert.AreEqual(1, cards.Count);

        }
        
        [Test]
        public void ExpectTheTrumpCardToBeTakenLast()
        {
            var deck = new Deck();
            var trumpCard = deck.GetTrumpCard;
            Card lastCard = deck.GetNextCard();

            while (deck.CardsLeft > 0)
            {
                lastCard = deck.GetNextCard();
            }

            Assert.AreSame(trumpCard, lastCard);
        }

        [Test]
        public void ExpectTheTrumpCardToBeChanged()
        {
            var deck = new Deck();
            var initialTrumpCard = deck.GetTrumpCard;
            var newTrumpCard = deck.GetNextCard();

            deck.ChangeTrumpCard(newTrumpCard);

            Assert.AreNotSame(initialTrumpCard, deck.GetTrumpCard, "The trump card stayed the same");
            Assert.AreSame(newTrumpCard, deck.GetTrumpCard, "The trump card is not the new one");
        }
    }
}
