namespace ChainOfResponsibility.Checkers
{
    using System.Collections.Generic;
    using System.Linq;

    using Cards;
    using Comparers;

    public class CheckerHelper
    {
        private const int CardsInHandCount = 5;
        
        private readonly IEqualityComparer<Card> fullComparer = new FullCardComparer();
        private readonly IEqualityComparer<Card> rankComparer = new RankCardComparer();
        private readonly IEqualityComparer<Card> suitComparer = new SuitCardComparer();

        public bool HasNOfAKind(Hand hand, int n)
        {
            return hand.Cards.GroupBy(x => x.Rank).Any(x => x.Count() == n);
        }

        public bool HasNRankGroups(Hand hand, int n)
        {
            return hand.Cards.GroupBy(x => x.Rank).Count() == n;
        }

        public bool IsFlush(Hand hand)
        {
            return hand.Cards.Distinct(suitComparer).Count() == 1;
        }

        public bool IsStraight(Hand hand)
        {
            if (hand.Cards.Distinct(rankComparer).Count() != CardsInHandCount)
            {
                return false;
            }
            else
            {
                var cardValues = hand.Cards.Select((x) =>
                {
                    if (x.Rank != Rank.Ace)
                    {
                        return this.GetRankValue(x.Rank);
                    }
                    else
                    {
                        bool higherAce = hand.Cards.Any(y => y.Rank == Rank.King);
                        return this.GetRankValue(x.Rank, higherAce);
                    }
                })
                    .OrderBy(x => x)
                    .ToArray();

                for (int i = 1; i < CardsInHandCount; i++)
                {
                    if (cardValues[i] - 1 != cardValues[i - 1])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public bool IsValidHand(Hand hand)
        {
            if (hand.Cards.Distinct(fullComparer).Count() != CardsInHandCount)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private int GetRankValue(Rank rank, bool higherAce = true)
        {
            if (rank == Rank.Ace)
            {
                if (higherAce)
                {
                    return (int)rank + (int)Rank.King;
                }
                else
                {
                    return (int)rank;
                }
            }
            else
            {
                return (int)rank;
            }
        }
    }
}
