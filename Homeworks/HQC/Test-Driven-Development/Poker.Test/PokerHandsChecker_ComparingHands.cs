namespace Poker.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PokerHandsChecker_ComparingHands
    {
        #region IHand_constants_for_all_combinations

        private static readonly IHand StraightFlush_AceToFive = new Hand(new List<ICard>() 
        { 
            new Card(CardFace.Ace, CardSuit.Clubs),
            new Card(CardFace.Two, CardSuit.Clubs),
            new Card(CardFace.Three, CardSuit.Clubs),
            new Card(CardFace.Four, CardSuit.Clubs),
            new Card(CardFace.Five, CardSuit.Clubs)
        });

        private static readonly IHand StraightFlush_TenToAce = new Hand(new List<ICard>() 
        { 
            new Card(CardFace.Ten, CardSuit.Spades),
            new Card(CardFace.Jack, CardSuit.Spades),
            new Card(CardFace.Queen, CardSuit.Spades),
            new Card(CardFace.King, CardSuit.Spades),
            new Card(CardFace.Ace, CardSuit.Spades)
        });

        private static readonly IHand StraightFlush_FourToEight = new Hand(new List<ICard>() 
        { 
            new Card(CardFace.Four, CardSuit.Hearts),
            new Card(CardFace.Five, CardSuit.Hearts),
            new Card(CardFace.Six, CardSuit.Hearts),
            new Card(CardFace.Seven, CardSuit.Hearts),
            new Card(CardFace.Eight, CardSuit.Hearts)
        });

        private static readonly IHand FourOfAKind_Fives_Three = new Hand(new List<ICard>() 
        { 
            new Card(CardFace.Five, CardSuit.Diamonds),
            new Card(CardFace.Five, CardSuit.Spades),
            new Card(CardFace.Five, CardSuit.Hearts),
            new Card(CardFace.Five, CardSuit.Clubs),
            new Card(CardFace.Three, CardSuit.Spades)
        });

        private static readonly IHand FourOfAKind_Fives_Eight = new Hand(new List<ICard>() 
        { 
            new Card(CardFace.Five, CardSuit.Diamonds),
            new Card(CardFace.Five, CardSuit.Spades),
            new Card(CardFace.Five, CardSuit.Hearts),
            new Card(CardFace.Five, CardSuit.Clubs),
            new Card(CardFace.Eight, CardSuit.Spades)
        });

        private static readonly IHand FourOfAKind_Sixes_Three = new Hand(new List<ICard>() 
        { 
            new Card(CardFace.Six, CardSuit.Diamonds),
            new Card(CardFace.Six, CardSuit.Spades),
            new Card(CardFace.Six, CardSuit.Hearts),
            new Card(CardFace.Six, CardSuit.Clubs),
            new Card(CardFace.Eight, CardSuit.Spades)
        });

        private static readonly IHand FullHouse_SixesOverEights = new Hand(new List<ICard>() 
        { 
            new Card(CardFace.Six, CardSuit.Diamonds),
            new Card(CardFace.Six, CardSuit.Spades),
            new Card(CardFace.Six, CardSuit.Hearts),
            new Card(CardFace.Eight, CardSuit.Clubs),
            new Card(CardFace.Eight, CardSuit.Spades)
        });

        private static readonly IHand FullHouse_QueensOverJacks = new Hand(new List<ICard>() 
        { 
            new Card(CardFace.Queen, CardSuit.Diamonds),
            new Card(CardFace.Queen, CardSuit.Spades),
            new Card(CardFace.Queen, CardSuit.Hearts),
            new Card(CardFace.Jack, CardSuit.Clubs),
            new Card(CardFace.Jack, CardSuit.Spades)
        });

        private static readonly IHand Straight_FiveToNine = new Hand(new List<ICard>() 
        { 
            new Card(CardFace.Seven, CardSuit.Clubs),
            new Card(CardFace.Eight, CardSuit.Diamonds),
            new Card(CardFace.Nine, CardSuit.Clubs),
            new Card(CardFace.Six, CardSuit.Spades),
            new Card(CardFace.Five, CardSuit.Hearts)
        });

        private static readonly IHand Straight_EightToQueen = new Hand(new List<ICard>() 
        { 
            new Card(CardFace.Nine, CardSuit.Clubs),
            new Card(CardFace.Eight, CardSuit.Diamonds),
            new Card(CardFace.Ten, CardSuit.Clubs),
            new Card(CardFace.Queen, CardSuit.Spades),
            new Card(CardFace.Jack, CardSuit.Hearts)
        });

        private static readonly IHand Flush_ToAce = new Hand(new List<ICard>()
        { 
            new Card(CardFace.Ten, CardSuit.Clubs),
            new Card(CardFace.Two, CardSuit.Clubs),
            new Card(CardFace.Queen, CardSuit.Clubs),
            new Card(CardFace.Six, CardSuit.Clubs),
            new Card(CardFace.Ace, CardSuit.Clubs)
        });

        private static readonly IHand Flush_ToSeven = new Hand(new List<ICard>() 
        { 
            new Card(CardFace.Ace, CardSuit.Hearts),
            new Card(CardFace.Two, CardSuit.Hearts),
            new Card(CardFace.Seven, CardSuit.Hearts),
            new Card(CardFace.Six, CardSuit.Hearts),
            new Card(CardFace.Four, CardSuit.Hearts)
        });

        private static readonly IHand ThreeOfAKind_Five_Three_Two = new Hand(new List<ICard>()
        { 
            new Card(CardFace.Five, CardSuit.Hearts),
            new Card(CardFace.Five, CardSuit.Clubs),
            new Card(CardFace.Five, CardSuit.Spades),
            new Card(CardFace.Three, CardSuit.Hearts),
            new Card(CardFace.Two, CardSuit.Diamonds)
        });

        private static readonly IHand ThreeOfAKind_Five_Queen_Two = new Hand(new List<ICard>()
        { 
            new Card(CardFace.Five, CardSuit.Hearts),
            new Card(CardFace.Five, CardSuit.Clubs),
            new Card(CardFace.Five, CardSuit.Spades),
            new Card(CardFace.Queen, CardSuit.Hearts),
            new Card(CardFace.Two, CardSuit.Diamonds)
        });

        private static readonly IHand ThreeOfAKind_Ace_Six_Two = new Hand(new List<ICard>() 
        { 
            new Card(CardFace.Ace, CardSuit.Hearts),
            new Card(CardFace.Ace, CardSuit.Clubs),
            new Card(CardFace.Ace, CardSuit.Spades),
            new Card(CardFace.Six, CardSuit.Hearts),
            new Card(CardFace.Two, CardSuit.Diamonds)
        });

        private static readonly IHand TwoPair_Queens_Jacks_Eight = new Hand(new List<ICard>()
        { 
            new Card(CardFace.Queen, CardSuit.Hearts),
            new Card(CardFace.Queen, CardSuit.Clubs),
            new Card(CardFace.Jack, CardSuit.Spades),
            new Card(CardFace.Jack, CardSuit.Hearts),
            new Card(CardFace.Eight, CardSuit.Diamonds)
        });

        private static readonly IHand TwoPair_Queens_Jacks_Three = new Hand(new List<ICard>() 
        { 
            new Card(CardFace.Queen, CardSuit.Hearts),
            new Card(CardFace.Queen, CardSuit.Clubs),
            new Card(CardFace.Jack, CardSuit.Spades),
            new Card(CardFace.Jack, CardSuit.Hearts),
            new Card(CardFace.Three, CardSuit.Diamonds)
        });

        private static readonly IHand TwoPair_Queens_Fives_Eight = new Hand(new List<ICard>() 
        { 
            new Card(CardFace.Queen, CardSuit.Hearts),
            new Card(CardFace.Queen, CardSuit.Clubs),
            new Card(CardFace.Five, CardSuit.Spades),
            new Card(CardFace.Five, CardSuit.Hearts),
            new Card(CardFace.Eight, CardSuit.Diamonds)
        });

        private static readonly IHand TwoPair_Kings_Jacks_Eight = new Hand(new List<ICard>()
        { 
            new Card(CardFace.King, CardSuit.Hearts),
            new Card(CardFace.King, CardSuit.Clubs),
            new Card(CardFace.Jack, CardSuit.Spades),
            new Card(CardFace.Jack, CardSuit.Hearts),
            new Card(CardFace.Eight, CardSuit.Diamonds)
        });

        private static readonly IHand OnePair_Queens_Jack_Eight_Five = new Hand(new List<ICard>() 
        { 
            new Card(CardFace.Queen, CardSuit.Hearts),
            new Card(CardFace.Queen, CardSuit.Clubs),
            new Card(CardFace.Jack, CardSuit.Spades),
            new Card(CardFace.Five, CardSuit.Hearts),
            new Card(CardFace.Eight, CardSuit.Diamonds)
        });

        private static readonly IHand OnePair_Sixes_Nine_Eight_Five = new Hand(new List<ICard>()
        { 
            new Card(CardFace.Six, CardSuit.Hearts),
            new Card(CardFace.Six, CardSuit.Clubs),
            new Card(CardFace.Jack, CardSuit.Spades),
            new Card(CardFace.Five, CardSuit.Hearts),
            new Card(CardFace.Eight, CardSuit.Diamonds)
        });

        private static readonly IHand HighCard_King_Eight = new Hand(new List<ICard>()
        { 
            new Card(CardFace.King, CardSuit.Hearts),
            new Card(CardFace.Eight, CardSuit.Clubs),
            new Card(CardFace.Five, CardSuit.Spades),
            new Card(CardFace.Three, CardSuit.Hearts),
            new Card(CardFace.Two, CardSuit.Diamonds)
        });

        private static readonly IHand HighCard_King_Jack = new Hand(new List<ICard>()
        { 
            new Card(CardFace.King, CardSuit.Hearts),
            new Card(CardFace.Jack, CardSuit.Clubs),
            new Card(CardFace.Five, CardSuit.Spades),
            new Card(CardFace.Three, CardSuit.Hearts),
            new Card(CardFace.Two, CardSuit.Diamonds)
        });

        private static readonly IHand HighCard_Ace = new Hand(new List<ICard>()
        { 
            new Card(CardFace.Ace, CardSuit.Hearts),
            new Card(CardFace.Jack, CardSuit.Clubs),
            new Card(CardFace.Five, CardSuit.Spades),
            new Card(CardFace.Three, CardSuit.Hearts),
            new Card(CardFace.Two, CardSuit.Diamonds)
        });

        #endregion

        private static readonly IPokerHandsChecker Checker = new PokerHandsChecker();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ComparingNullHands()
        {
            IHand firstHand = null;
            IHand secondHand = null;
            var checker = new PokerHandsChecker();

            checker.CompareHands(firstHand, secondHand);
        }

        [TestMethod]
        public void HighCardVsHighCard_Equal()
        {
            Assert.AreEqual(0, Checker.CompareHands(HighCard_Ace, HighCard_Ace));
        }

        [TestMethod]
        public void HighCardVsHigherHighCard()
        {
            Assert.AreEqual(-1, Checker.CompareHands(HighCard_King_Eight, HighCard_Ace));
        }

        [TestMethod]
        public void HighCardVsHighCard_KickerVsLowerKicker()
        {
            Assert.AreEqual(1, Checker.CompareHands(HighCard_King_Jack, HighCard_King_Eight));
        }

        [TestMethod]
        public void HighCardVsOnePair()
        {
            Assert.AreEqual(-1, Checker.CompareHands(HighCard_Ace, OnePair_Queens_Jack_Eight_Five));
        }

        [TestMethod]
        public void HighCardVsTwoPair()
        {
            Assert.AreEqual(1, Checker.CompareHands(TwoPair_Queens_Fives_Eight, HighCard_Ace));
        }

        [TestMethod]
        public void HighCardVsThreeOfAKind()
        {
            Assert.AreEqual(1, Checker.CompareHands(ThreeOfAKind_Ace_Six_Two, HighCard_Ace));
        }

        [TestMethod]
        public void HighCardVsStraight()
        {
            Assert.AreEqual(-1, Checker.CompareHands(HighCard_King_Eight, Straight_FiveToNine));
        }

        [TestMethod]
        public void HighCardVsFlush()
        {
            Assert.AreEqual(1, Checker.CompareHands(Flush_ToAce, HighCard_Ace));
        }

        [TestMethod]
        public void HighCardVsFullHouse()
        {
            Assert.AreEqual(-1, Checker.CompareHands(HighCard_King_Eight, FullHouse_QueensOverJacks));
        }

        [TestMethod]
        public void HighCardVsFourOfAKind()
        {
            Assert.AreEqual(1, Checker.CompareHands(FourOfAKind_Fives_Eight, HighCard_Ace));
        }

        [TestMethod]
        public void HighCardVsStraightFlush()
        {
            Assert.AreEqual(-1, Checker.CompareHands(HighCard_King_Jack, StraightFlush_AceToFive));
        }

        [TestMethod]
        public void OnePairVsOnePair_Equal()
        {
            Assert.AreEqual(0, Checker.CompareHands(OnePair_Queens_Jack_Eight_Five, OnePair_Queens_Jack_Eight_Five));
        }

        [TestMethod]
        public void OnePairVsHigherOnePair()
        {
            Assert.AreEqual(1, Checker.CompareHands(OnePair_Queens_Jack_Eight_Five, OnePair_Sixes_Nine_Eight_Five));
        }

        [TestMethod]
        public void OnePairVsTwoPair()
        {
            Assert.AreEqual(-1, Checker.CompareHands(OnePair_Queens_Jack_Eight_Five, TwoPair_Queens_Fives_Eight));
        }

        [TestMethod]
        public void OnePairVsThreeOfAKind()
        {
            Assert.AreEqual(-1, Checker.CompareHands(OnePair_Queens_Jack_Eight_Five, ThreeOfAKind_Five_Queen_Two));
        }

        [TestMethod]
        public void OnePairVsStraight()
        {
            Assert.AreEqual(-1, Checker.CompareHands(OnePair_Queens_Jack_Eight_Five, Straight_FiveToNine));
        }

        [TestMethod]
        public void OnePairVsFlush()
        {
            Assert.AreEqual(-1, Checker.CompareHands(OnePair_Queens_Jack_Eight_Five, Flush_ToSeven));
        }

        [TestMethod]
        public void OnePairVsFullHouse()
        {
            Assert.AreEqual(1, Checker.CompareHands(FullHouse_QueensOverJacks, OnePair_Queens_Jack_Eight_Five));
        }

        [TestMethod]
        public void OnePairVsFourOfAKind()
        {
            Assert.AreEqual(1, Checker.CompareHands(FourOfAKind_Fives_Eight, OnePair_Queens_Jack_Eight_Five));
        }

        [TestMethod]
        public void OnePairVsStraightFlush()
        {
            Assert.AreEqual(1, Checker.CompareHands(StraightFlush_AceToFive, OnePair_Queens_Jack_Eight_Five));
        }

        [TestMethod]
        public void TwoPairVsTwoPair_Equal()
        {
            Assert.AreEqual(0, Checker.CompareHands(TwoPair_Queens_Fives_Eight, TwoPair_Queens_Fives_Eight));
        }

        [TestMethod]
        public void TwoPairVsHigherTwoPair()
        {
            Assert.AreEqual(-1, Checker.CompareHands(TwoPair_Queens_Fives_Eight, TwoPair_Queens_Jacks_Eight));
        }

        [TestMethod]
        public void TwoPairVsTwoPair_HigherKicker()
        {
            Assert.AreEqual(-1, Checker.CompareHands(TwoPair_Queens_Jacks_Three, TwoPair_Queens_Jacks_Eight));
        }

        [TestMethod]
        public void TwoPairVsThreeOfAKind()
        {
            Assert.AreEqual(-1, Checker.CompareHands(TwoPair_Queens_Jacks_Three, ThreeOfAKind_Five_Queen_Two));
        }

        [TestMethod]
        public void TwoPairVsStraight()
        {
            Assert.AreEqual(-1, Checker.CompareHands(TwoPair_Queens_Jacks_Three, Straight_FiveToNine));
        }

        [TestMethod]
        public void TwoPairVsTwoFlush()
        {
            Assert.AreEqual(-1, Checker.CompareHands(TwoPair_Queens_Jacks_Three, Flush_ToSeven));
        }

        [TestMethod]
        public void TwoPairVsFullHouse()
        {
            Assert.AreEqual(-1, Checker.CompareHands(TwoPair_Queens_Jacks_Three, FullHouse_QueensOverJacks));
        }

        [TestMethod]
        public void TwoPairVsFourOfAKind()
        {
            Assert.AreEqual(1, Checker.CompareHands(FourOfAKind_Sixes_Three, TwoPair_Queens_Jacks_Three));
        }

        [TestMethod]
        public void TwoPairVsStraightFlush()
        {
            Assert.AreEqual(1, Checker.CompareHands(StraightFlush_FourToEight, TwoPair_Queens_Jacks_Three));
        }

        [TestMethod]
        public void ThreeOfAKindVsHigherThreeOfAKind()
        {
            Assert.AreEqual(-1, Checker.CompareHands(ThreeOfAKind_Five_Queen_Two, ThreeOfAKind_Ace_Six_Two));
        }

        [TestMethod]
        public void ThreeOfAKindVsThreeOfAKind_HigherKicker()
        {
            Assert.AreEqual(-1, Checker.CompareHands(ThreeOfAKind_Five_Three_Two, ThreeOfAKind_Five_Queen_Two));
        }

        [TestMethod]
        public void ThreeOfAKindVsStraight()
        {
            Assert.AreEqual(1, Checker.CompareHands(Straight_FiveToNine, ThreeOfAKind_Ace_Six_Two));
        }

        [TestMethod]
        public void ThreeOfAKindVsFlush()
        {
            Assert.AreEqual(1, Checker.CompareHands(Flush_ToAce, ThreeOfAKind_Ace_Six_Two));
        }

        [TestMethod]
        public void ThreeOfAKindVsFullHouse()
        {
            Assert.AreEqual(1, Checker.CompareHands(FullHouse_SixesOverEights, ThreeOfAKind_Ace_Six_Two));
        }

        [TestMethod]
        public void ThreeOfAKindVsFourOfAKind()
        {
            Assert.AreEqual(1, Checker.CompareHands(FourOfAKind_Fives_Three, ThreeOfAKind_Ace_Six_Two));
        }

        [TestMethod]
        public void ThreeOfAKindVsStraightFlush()
        {
            Assert.AreEqual(-1, Checker.CompareHands(ThreeOfAKind_Ace_Six_Two, StraightFlush_AceToFive));
        }

        [TestMethod]
        public void StraightVsStraight_Equal()
        {
            Assert.AreEqual(0, Checker.CompareHands(Straight_FiveToNine, Straight_FiveToNine));
        }

        [TestMethod]
        public void StraightVsHigherStraight()
        {
            Assert.AreEqual(1, Checker.CompareHands(Straight_EightToQueen, Straight_FiveToNine));
        }

        [TestMethod]
        public void StraightVsFlush()
        {
            Assert.AreEqual(1, Checker.CompareHands(Flush_ToAce, Straight_FiveToNine));
        }

        [TestMethod]
        public void StraightVsFullHouse()
        {
            Assert.AreEqual(-1, Checker.CompareHands(Straight_EightToQueen, FullHouse_QueensOverJacks));
        }

        [TestMethod]
        public void StraightVsFourOfAKind()
        {
            Assert.AreEqual(-1, Checker.CompareHands(Straight_EightToQueen, FourOfAKind_Fives_Three));
        }

        [TestMethod]
        public void StraightVsStraightFlush()
        {
            Assert.AreEqual(-1, Checker.CompareHands(Straight_EightToQueen, StraightFlush_AceToFive));
        }

        [TestMethod]
        public void FlushVsFlush_Equal()
        {
            Assert.AreEqual(0, Checker.CompareHands(Flush_ToAce, Flush_ToAce));
        }

        [TestMethod]
        public void FlushVsHigherFlush()
        {
            Assert.AreEqual(1, Checker.CompareHands(Flush_ToAce, Flush_ToSeven));
        }

        [TestMethod]
        public void FlushVsFullHouse()
        {
            Assert.AreEqual(1, Checker.CompareHands(FullHouse_SixesOverEights, Flush_ToSeven));
        }

        [TestMethod]
        public void FlushVsFourOfAKind()
        {
            Assert.AreEqual(1, Checker.CompareHands(FourOfAKind_Fives_Eight, Flush_ToSeven));
        }

        [TestMethod]
        public void FlushVsStraightFlush()
        {
            Assert.AreEqual(1, Checker.CompareHands(StraightFlush_FourToEight, Flush_ToSeven));
        }

        [TestMethod]
        public void FullHouseVsHigherFullHouse()
        {
            Assert.AreEqual(-1, Checker.CompareHands(FullHouse_SixesOverEights, FullHouse_QueensOverJacks));
        }

        [TestMethod]
        public void FullHouseVsFourOfAKind()
        {
            Assert.AreEqual(-1, Checker.CompareHands(FullHouse_SixesOverEights, FourOfAKind_Fives_Three));
        }

        [TestMethod]
        public void FullHouseVsStraightFlush()
        {
            Assert.AreEqual(-1, Checker.CompareHands(FullHouse_SixesOverEights, StraightFlush_TenToAce));
        }

        [TestMethod]
        public void FourOfAkindVsStraightFlush()
        {
            Assert.AreEqual(1, Checker.CompareHands(StraightFlush_TenToAce, FourOfAKind_Sixes_Three));
        }

        [TestMethod]
        public void StraightFlushVsStraightFlush_Equal()
        {
            Assert.AreEqual(0, Checker.CompareHands(StraightFlush_FourToEight, StraightFlush_FourToEight));
        }

        [TestMethod]
        public void StraightFlushVsHigherStraightFlush()
        {
            Assert.AreEqual(1, Checker.CompareHands(StraightFlush_TenToAce, StraightFlush_AceToFive));
        }
    }
}