namespace ChainOfResponsibility
{
    using Cards;
    using Checkers;

    class Program
    {
        static void Main()
        {
            var combinationChecker = GetChecker();
            
            var hand = new Hand()
                .AddCard(new Card(Suit.Clubs, Rank.Two))
                .AddCard(new Card(Suit.Diamonds, Rank.Two))
                .AddCard(new Card(Suit.Clubs, Rank.Queen))
                .AddCard(new Card(Suit.Diamonds, Rank.Queen))
                .AddCard(new Card(Suit.Clubs, Rank.Ten));

            var checkerHelper = new CheckerHelper();

            combinationChecker.Check(checkerHelper, hand);
        }

        static PokerCombinationChecker GetChecker()
        {
            var highCard = new HighCardChecker();
            var onePair = new OnePairChecker()
                .SuccessiveHand(highCard);
            var twoPair = new TwoPairChecker()
                .SuccessiveHand(onePair);
            var threeOfAKind = new ThreeOfAKindChecker()
                .SuccessiveHand(twoPair);
            var straight = new StraightChecker()
                .SuccessiveHand(threeOfAKind);
            var flush = new FlushChecker()
                .SuccessiveHand(straight);
            var fullHouse = new FullHouseChecker()
                .SuccessiveHand(flush);
            var fourOfAKind = new FourOfAKindChecker()
                .SuccessiveHand(fullHouse);
            var straightFlush = new StraightFlushChecker()
                .SuccessiveHand(fourOfAKind);

            return straightFlush;
        }
    }
}
