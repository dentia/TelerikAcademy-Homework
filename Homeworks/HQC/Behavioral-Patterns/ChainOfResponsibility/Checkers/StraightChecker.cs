namespace ChainOfResponsibility.Checkers
{
    using System;
    using Cards;

    public class StraightChecker : PokerCombinationChecker
    {
        public override void Check(CheckerHelper helper, Hand hand)
        {
            if (helper.IsStraight(hand))
            {
                Console.WriteLine("Straight!");
            }
            else
            {
                this.SuccessiveCombinationChecker.Check(helper, hand);
            }
        }
    }
}
