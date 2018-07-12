namespace ChainOfCommand.Cards.Evaluators
{
    public class StraightEvaluator : IEvaluator
    {
        public Rank Evaluate(Hand hand)
        {
            return hand.Consecutive() ? Rank.Straight : Rank.Nada;
        }
    }
}