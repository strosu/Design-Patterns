namespace ChainOfCommand.Cards.Evaluators
{
    public class StraightFlushEvaluator : IEvaluator
    {
        public Rank Evaluate(Hand hand)
        {
            if (hand.Consecutive() && hand.SameColor())
            {
                return Rank.StraightFlush;
            }

            return Rank.Nada;
        }
    }
}