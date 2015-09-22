namespace ChainOfResponsibility.Comparers
{
    using System.Collections.Generic;

    using Cards;

    public class SuitCardComparer : IEqualityComparer<Card>
    {
        public bool Equals(Card x, Card y)
        {
            return (x.Suit == y.Suit);
        }

        public int GetHashCode(Card obj)
        {
            return (int) obj.Suit;
        }
    }
}
