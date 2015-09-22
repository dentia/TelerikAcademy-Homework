namespace ChainOfResponsibility.Checkers
{
    using System;
    using Cards;

    public class TwoPairChecker : PokerCombinationChecker
    {
        public override void Check(CheckerHelper helper, Hand hand)
        {
            if (helper.HasNOfAKind(hand, 2) && helper.HasNRankGroups(hand, 3))
            {
                Console.WriteLine("Two pairs!");
            }
            else
            {
                this.SuccessiveCombinationChecker.Check(helper, hand);
            }
        }
    }
}
