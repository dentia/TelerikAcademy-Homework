namespace ChainOfResponsibility.Checkers
{
    using System;
    using Cards;

    public class HighCardChecker : PokerCombinationChecker
    {
        public override void Check(CheckerHelper helper, Hand hand)
        {
            Console.WriteLine("High card!");
        }
    }
}
