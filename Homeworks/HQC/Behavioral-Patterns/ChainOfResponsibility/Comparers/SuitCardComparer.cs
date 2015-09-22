namespace ChainOfResponsibility.Comparers
{
    using System.Collections.Generic;

    public class SuitCardComparer : EqualityComparer<Cards.Card>
    {
        public override bool Equals(Cards.Card x, Cards.Card y)
        {
            return (x.Suit == y.Suit);
        }

        public override int GetHashCode(Cards.Card obj)
        {
            return (int) obj.Suit;
        }
    }
}
