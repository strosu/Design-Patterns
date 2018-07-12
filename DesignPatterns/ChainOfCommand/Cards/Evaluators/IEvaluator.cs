namespace ChainOfCommand.Cards
{
    public interface IEvaluator
    {
        Rank Evaluate(Hand hand);
    }
}