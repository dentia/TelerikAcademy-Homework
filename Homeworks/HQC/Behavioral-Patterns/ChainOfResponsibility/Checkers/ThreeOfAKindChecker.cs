namespace ChainOfResponsibility.Checkers
{
    using System;
    using Cards;

    public class ThreeOfAKindChecker : PokerCombinationChecker
    {
        public override void Check(CheckerHelper helper, Hand hand)
        {
            if (helper.HasNOfAKind(hand, 3))
            {
                Console.WriteLine("Three of a kind!");
            }
            else
            {
                this.SuccessiveCombinationChecker.Check(helper, hand);
            }
        }
    }
}
