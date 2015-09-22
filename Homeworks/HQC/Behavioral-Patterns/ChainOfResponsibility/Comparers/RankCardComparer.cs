namespace ChainOfResponsibility.Comparers
{
    using System.Collections.Generic;

    using Cards;

    class RankCardComparer : IEqualityComparer<Card>
    {
        public bool Equals(Card x, Card y)
        {
            return (x.Rank == y.Rank);
        }

        public int GetHashCode(Card obj)
        {
            return obj.Rank.GetHashCode();
        }
    }
}
