namespace ChainOfResponsibility.Checkers
{
    using System;
    using Cards;

    public class FlushChecker : PokerCombinationChecker
    {
        public override void Check(CheckerHelper helper, Hand hand)
        {
            if (helper.IsFlush(hand))
            {
                Console.WriteLine("Flush!");
            }
            else
            {
                this.SuccessiveCombinationChecker.Check(helper, hand);
            }
        }
    }
}
