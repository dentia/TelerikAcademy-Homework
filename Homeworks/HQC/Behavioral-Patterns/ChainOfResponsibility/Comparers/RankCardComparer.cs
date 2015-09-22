namespace ChainOfResponsibility.Comparers
{
    using System.Collections.Generic;

    class RankCardComparer : EqualityComparer<Cards.Card>
    {
        public override bool Equals(Cards.Card x, Cards.Card y)
        {
            return (x.Rank == y.Rank);
        }

        public override int GetHashCode(Cards.Card obj)
        {
            return obj.Rank.GetHashCode();
        }
    }
}
