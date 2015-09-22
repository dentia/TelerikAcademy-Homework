namespace ChainOfResponsibility.Comparers
{
    using System.Collections.Generic;

    using Cards;

    class FullCardComparer : IEqualityComparer<Card>
    {
        public bool Equals(Card x, Card y)
        {
            return (x.Suit == y.Suit && x.Rank == y.Rank);
        }

        public int GetHashCode(Card obj)
        {
            return obj.Suit.GetHashCode() + obj.Rank.GetHashCode();
        }
    }
}
