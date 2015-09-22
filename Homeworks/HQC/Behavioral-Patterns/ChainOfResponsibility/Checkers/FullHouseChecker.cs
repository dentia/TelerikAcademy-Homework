namespace ChainOfResponsibility.Checkers
{
    using System;
    using Cards;

    public class FullHouseChecker : PokerCombinationChecker
    {
        public override void Check(CheckerHelper helper, Hand hand)
        {
            if (helper.HasNOfAKind(hand, 3) && helper.HasNOfAKind(hand, 2))
            {
                Console.WriteLine("Full house!");
            }
            else
            {
                this.SuccessiveCombinationChecker.Check(helper, hand);
            }
        }
    }
}
