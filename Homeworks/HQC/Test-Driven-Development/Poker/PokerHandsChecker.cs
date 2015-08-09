namespace Poker
{
    using System;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public const int ValidHandCardsCount = 5;

        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("hand", "Hand cannot be null.");
            }

            if (hand.Cards.Count != PokerHandsChecker.ValidHandCardsCount)
            {
                throw new ArgumentException("Invalid hand.");
            }

            if (hand.Cards.Distinct().Count() != PokerHandsChecker.ValidHandCardsCount)
            {
                throw new ArgumentException("Duplicate cards.");
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            var isStraight = true;

            var sorted = hand.Cards.Select(value => (int)value.Face).OrderBy(value => value).ToArray();

            if (sorted.Contains((int)CardFace.Ace) && sorted.Contains((int)CardFace.Two))
            {
                var index = Array.IndexOf(sorted, (int)CardFace.Ace);
                sorted[index] = 1;
                sorted = sorted.OrderBy(value => value).ToArray();
            }

            for (int ind = 0; ind < sorted.Length - 1; ind++)
            {
                if (sorted[ind] + 1 != sorted[ind + 1])
                {
                    isStraight = false;
                    break;
                }
            }

            bool isFlush = hand.Cards.GroupBy(card => card.Suit).Count() == 1;

            return isStraight && isFlush;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var group = hand.Cards.GroupBy(card => card.Face);
            return group.Any(gr => gr.Count() == 4);
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var group = hand.Cards.GroupBy(card => card.Face);
            return group.Any(gr => gr.Count() == 3) && group.Any(gr => gr.Count() == 2);
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            return hand.Cards.GroupBy(card => card.Suit).Count() == 1 && !this.IsStraightFlush(hand);
        }

        public bool IsStraight(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            if (hand.Cards.GroupBy(card => card.Suit).Count() == 1)
            {
                return false;
            }

            var sorted = hand.Cards.Select(value => (int)value.Face).OrderBy(value => value).ToArray();

            if (sorted.Contains((int)CardFace.Ace) && sorted.Contains((int)CardFace.Two))
            {
                var index = Array.IndexOf(sorted, (int)CardFace.Ace);
                sorted[index] = 1;
                sorted = sorted.OrderBy(value => value).ToArray();
            }

            for (int ind = 0; ind < sorted.Length - 1; ind++)
            {
                if (sorted[ind] + 1 != sorted[ind + 1])
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var group = hand.Cards.GroupBy(card => card.Face);
            return group.Any(gr => gr.Count() == 3) && !group.Any(gr => gr.Count() == 2);
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            return hand.Cards.GroupBy(card => card.Face).Count(group => group.Count() == 2) == 2;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var group = hand.Cards.GroupBy(card => card.Face);
            return group.Count(gr => gr.Count() == 2) == 1 && !group.Any(gr => gr.Count() == 3);
        }

        public bool IsHighCard(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var group = hand.Cards.GroupBy(card => card.Face);
            return !this.IsFlush(hand) && group.Count() == PokerHandsChecker.ValidHandCardsCount;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (!this.IsValidHand(firstHand) || !this.IsValidHand(secondHand))
            {
                throw new ArgumentException("Invalid hand.");
            }

            var firstHandType = this.GetHandType(firstHand);
            var secondHandType = this.GetHandType(secondHand);

            if (firstHandType != secondHandType)
            {
                return firstHandType.CompareTo(secondHandType);
            }
            else
            {
                switch (firstHandType)
                {
                    case Hand.Type.HighCard:
                        return this.CompareHighCardHands(firstHand, secondHand);
                    case Hand.Type.OnePair:
                        return this.CompareOnePairHands(firstHand, secondHand);
                    case Hand.Type.TwoPair:
                        return this.CompareTwoPairHands(firstHand, secondHand);
                    case Hand.Type.ThreeOfAKind:
                        return this.CompareThreeOfAKindHands(firstHand, secondHand);
                    case Hand.Type.Straight:
                    case Hand.Type.StraightFlush:
                        return this.CompareStraightHands(firstHand, secondHand);
                    case Hand.Type.Flush:
                        return this.CompareFlushHands(firstHand, secondHand);
                    case Hand.Type.FullHouse:
                        return this.CompareFullHouseHands(firstHand, secondHand);
                    case Hand.Type.FourOfAKind:
                        return this.CompareFourOfAKindHands(firstHand, secondHand);
                    default:
                        throw new ArgumentException("Invalid hand.");
                }
            }
        }

        private Hand.Type GetHandType(IHand hand)
        {
            if (this.IsStraightFlush(hand))
            {
                return Hand.Type.StraightFlush;
            }
            else if (this.IsFourOfAKind(hand))
            {
                return Hand.Type.FourOfAKind;
            }
            else if (this.IsFullHouse(hand))
            {
                return Hand.Type.FullHouse;
            }
            else if (this.IsFlush(hand))
            {
                return Hand.Type.Flush;
            }
            else if (this.IsStraight(hand))
            {
                return Hand.Type.Straight;
            }
            else if (this.IsThreeOfAKind(hand))
            {
                return Hand.Type.ThreeOfAKind;
            }
            else if (this.IsTwoPair(hand))
            {
                return Hand.Type.TwoPair;
            }
            else if (this.IsOnePair(hand))
            {
                return Hand.Type.OnePair;
            }
            else if (this.IsHighCard(hand))
            {
                return Hand.Type.HighCard;
            }
            else
            {
                throw new ArgumentException("Invalid hand");
            }
        }

        private int GetHighestCardValue(IHand hand)
        {
            return hand.Cards.Select(value => (int)value.Face).Max();
        }

        private int CompareFourOfAKindHands(IHand firstHand, IHand secondHand)
        {
            var firstCardsValues = firstHand.Cards.Select(card => (int)card.Face).ToArray();
            var secondCardsValues = secondHand.Cards.Select(card => (int)card.Face).ToArray();
            var firstFourValue = firstCardsValues.Where(value => firstCardsValues.Count(x => x == value) == 4).ToArray()[0];
            var secondFourValue = secondCardsValues.Where(value => secondCardsValues.Count(x => x == value) == 4).ToArray()[0];

            if (firstFourValue != secondFourValue)
            {
                return firstFourValue.CompareTo(secondFourValue);
            }
            else
            {
                var firstKickerValue = firstCardsValues.Where(value => firstCardsValues.Count(x => x == value) == 1).ToArray()[0];
                var secondKickerValue = secondCardsValues.Where(value => secondCardsValues.Count(x => x == value) == 1).ToArray()[0];

                return firstKickerValue.CompareTo(secondKickerValue);
            }
        }

        private int CompareFullHouseHands(IHand firstHand, IHand secondHand)
        {
            var firstCardsValues = firstHand.Cards.Select(card => (int)card.Face).ToArray();
            var secondCardsValues = secondHand.Cards.Select(card => (int)card.Face).ToArray();
            var firstThreeValue = firstCardsValues.Where(value => firstCardsValues.Count(x => x == value) == 3).ToArray()[0];
            var secondThreeValue = secondCardsValues.Where(value => secondCardsValues.Count(x => x == value) == 3).ToArray()[0];

            if (firstThreeValue != secondThreeValue)
            {
                return firstThreeValue.CompareTo(secondThreeValue);
            }
            else
            {
                var firstTwoValue = firstCardsValues.Where(value => firstCardsValues.Count(x => x == value) == 2).ToArray()[0];
                var secondTwoValue = secondCardsValues.Where(value => secondCardsValues.Count(x => x == value) == 2).ToArray()[0];

                return firstTwoValue.CompareTo(secondTwoValue);
            }
        }

        private int CompareFlushHands(IHand firstHand, IHand secondHand)
        {
            var firstSortedValues = firstHand.Cards.Select(card => (int)card.Face).OrderByDescending(value => value).ToArray();
            var secondSortedValues = secondHand.Cards.Select(card => (int)card.Face).OrderByDescending(value => value).ToArray();

            for (int card = 0; card < PokerHandsChecker.ValidHandCardsCount; card++)
            {
                var compareValue = firstSortedValues[card].CompareTo(secondSortedValues[card]);

                if (compareValue != 0)
                {
                    return compareValue;
                }
            }

            return 0;
        }

        private int CompareStraightHands(IHand firstHand, IHand secondHand)
        {
            var firstCardValues = firstHand.Cards.Select(card => (int)card.Face).ToArray();
            var secondCardValues = secondHand.Cards.Select(card => (int)card.Face).ToArray();

            if (firstCardValues.Contains((int)CardFace.Ace) && firstCardValues.Contains((int)CardFace.Two))
            {
                var aceIndex = Array.IndexOf(firstCardValues, (int)CardFace.Ace);
                firstCardValues[aceIndex] = 1;
            }

            if (secondCardValues.Contains((int)CardFace.Ace) && secondCardValues.Contains((int)CardFace.Two))
            {
                var aceIndex = Array.IndexOf(secondCardValues, (int)CardFace.Ace);
                secondCardValues[aceIndex] = 1;
            }

            return firstCardValues.Max().CompareTo(secondCardValues.Max());
        }

        private int CompareThreeOfAKindHands(IHand firstHand, IHand secondHand)
        {
            var firstCardValues = firstHand.Cards.Select(card => (int)card.Face).ToArray();
            var secondCardValues = secondHand.Cards.Select(card => (int)card.Face).ToArray();
            var firstThreeValue = firstCardValues.Where(value => firstCardValues.Count(x => x == value) == 3).ToArray()[0];
            var secondThreeValue = secondCardValues.Where(value => secondCardValues.Count(x => x == value) == 3).ToArray()[0];

            if (firstThreeValue != secondThreeValue)
            {
                return firstThreeValue.CompareTo(secondThreeValue);
            }
            else
            {
                var firstHigherKicker = firstCardValues.Where(value => firstCardValues.Count(x => x == value) == 1).ToArray().Max();
                var secondHigherKicker = secondCardValues.Where(value => secondCardValues.Count(x => x == value) == 1).ToArray().Max();

                if (firstHigherKicker != secondHigherKicker)
                {
                    return firstHigherKicker.CompareTo(secondHigherKicker);
                }
                else
                {
                    var firstLowerKicker = firstCardValues.Where(value => firstCardValues.Count(x => x == value) == 1).ToArray().Min();
                    var secondLowerKicker = secondCardValues.Where(value => secondCardValues.Count(x => x == value) == 1).ToArray().Min();

                    return firstLowerKicker.CompareTo(secondLowerKicker);
                }
            }
        }

        private int CompareTwoPairHands(IHand firstHand, IHand secondHand)
        {
            var firstCardValues = firstHand.Cards.Select(card => (int)card.Face).ToArray();
            var secondCardValues = secondHand.Cards.Select(card => (int)card.Face).ToArray();
            var firstHigherPairValue = firstCardValues.Where(value => firstCardValues.Count(x => x == value) == 2).Max();
            var secondHigherPairValue = secondCardValues.Where(value => secondCardValues.Count(x => x == value) == 2).Max();

            if (firstHigherPairValue != secondHigherPairValue)
            {
                return firstHigherPairValue.CompareTo(secondHigherPairValue);
            }
            else
            {
                var firstLowerPairValue = firstCardValues.Where(value => firstCardValues.Count(x => x == value) == 2).Min();
                var secondLowerPairValue = secondCardValues.Where(value => secondCardValues.Count(x => x == value) == 2).Min();

                if (firstLowerPairValue != secondLowerPairValue)
                {
                    return firstLowerPairValue.CompareTo(secondLowerPairValue);
                }
                else
                {
                    var firstKickerValue = firstCardValues.Where(value => firstCardValues.Count(x => x == value) == 1).ToArray()[0];
                    var secondKickerValue = secondCardValues.Where(value => secondCardValues.Count(x => x == value) == 1).ToArray()[0];

                    return firstKickerValue.CompareTo(secondKickerValue);
                }
            }
        }

        private int CompareOnePairHands(IHand firstHand, IHand secondHand)
        {
            var firstCardValues = firstHand.Cards.Select(card => (int)card.Face).ToArray();
            var secondCardValues = secondHand.Cards.Select(card => (int)card.Face).ToArray();
            var firstPairValue = firstCardValues.Where(value => firstCardValues.Count(x => x == value) == 2).ToArray()[0];
            var secondPairValue = secondCardValues.Where(value => secondCardValues.Count(x => x == value) == 2).ToArray()[0];

            if (firstPairValue != secondPairValue)
            {
                return firstPairValue.CompareTo(secondPairValue);
            }
            else
            {
                var firstKickers = firstCardValues.Where(value => firstCardValues.Count(x => x == value) == 1).OrderByDescending(value => value).ToArray();
                var secondKickers = secondCardValues.Where(value => secondCardValues.Count(x => x == value) == 1).OrderByDescending(value => value).ToArray();

                for (int ind = 0; ind < 3; ind++)
                {
                    var compareValue = firstKickers[ind].CompareTo(secondKickers[ind]);

                    if (compareValue != 0)
                    {
                        return compareValue;
                    }
                }

                return 0;
            }
        }

        private int CompareHighCardHands(IHand firstHand, IHand secondHand)
        {
            var firstHighCardValues = firstHand.Cards.Select(card => (int)card.Face).OrderByDescending(value => value).ToArray();
            var secondHighCardValues = secondHand.Cards.Select(card => (int)card.Face).OrderByDescending(value => value).ToArray();

            for (int card = 0; card < PokerHandsChecker.ValidHandCardsCount; card++)
            {
                var compareValue = firstHighCardValues[card].CompareTo(secondHighCardValues[card]);

                if (compareValue != 0)
                {
                    return compareValue;
                }
            }

            return 0;
        }
    }
}