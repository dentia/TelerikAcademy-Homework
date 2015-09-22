namespace ChainOfResponsibility.Comparers
{
    using System.Collections.Generic;

    class FullCardComparer : EqualityComparer<Cards.Card>
    {
        public override bool Equals(Cards.Card x, Cards.Card y)
        {
            return (x.Suit == y.Suit && x.Rank == y.Rank);
        }

        public override int GetHashCode(Cards.Card obj)
        {
            return obj.Suit.GetHashCode() + obj.Rank.GetHashCode();
        }
    }
}
