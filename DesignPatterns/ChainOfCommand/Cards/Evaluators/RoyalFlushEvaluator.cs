namespace ChainOfCommand.Cards
{
    public class RoyalFlushEvaluator : IEvaluator
    {
        public Rank Evaluate(Hand hand)
        {
            if (hand.Consecutive() && hand.SameColor() && hand.Royal())
            {
                return Rank.RoyalFlush;
            }

            return Rank.Nada;
        }
    }
}