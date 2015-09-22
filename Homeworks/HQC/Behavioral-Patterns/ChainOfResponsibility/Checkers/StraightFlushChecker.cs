namespace ChainOfResponsibility.Checkers
{
    using System;
    using Cards;

    public class StraightFlushChecker : PokerCombinationChecker
    {
        public override void Check(CheckerHelper helper, Hand hand)
        {
            if (!helper.IsValidHand(hand))
            {
                Console.WriteLine("Invalid hand.");
                return;
            }

            if (helper.IsFlush(hand) && helper.IsStraight(hand))
            {
                Console.WriteLine("Straight flush!");
            }
            else
            {
                this.SuccessiveCombinationChecker.Check(helper, hand);
            }
        }
    }
}
