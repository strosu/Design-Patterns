namespace ChainOfCommand.Cards
{
    public class FlushEvaluator : IEvaluator
    {
        public Rank Evaluate(Hand hand)
        {
            return hand.SameColor() ? Rank.Flush : Rank.Nada;
        }
    }
}