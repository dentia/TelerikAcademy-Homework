namespace Sepcification
{
    using System;
    using System.Linq;

    using Cards;
    using ConcreteSpecifications;
    using LogicSpecifications;

    class Program
    {
        static void Main()
        {
            var isAce = new AceCardSpecification();
            var isHighCard = new HighCardSpecification();
            var isRedCard = new RedSuitSpecification();
            
            var blackRoyalFlushesCards = isHighCard.Or(isAce).And(isRedCard.Not());

            var royalFlushes = new Deck().Cards
                .Where(card => blackRoyalFlushesCards.IsSatisfiedBy(card))
                .GroupBy(card => card.Suit)
                .Select((royalFlush) => string.Join(", ", royalFlush));

            Console.WriteLine(string.Join(Environment.NewLine, royalFlushes));
        }
    }
}
