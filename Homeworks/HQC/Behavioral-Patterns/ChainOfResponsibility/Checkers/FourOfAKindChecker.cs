namespace ChainOfResponsibility.Checkers
{
    using System;
    using Cards;

    public class FourOfAKindChecker : PokerCombinationChecker
    {
        public override void Check(CheckerHelper helper, Hand hand)
        {
            if (helper.HasNOfAKind(hand, 4))
            {
                Console.WriteLine("Four of a kind!");
            }
            else
            {
                this.SuccessiveCombinationChecker.Check(helper, hand);
            }
        }
    }
}
