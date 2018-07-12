namespace ChainOfCommand.Cards
{
    public class EvaluatorWrapper : IEvaluator
    {
        private readonly IEvaluator _evaluator;
        private IEvaluator _next;

        public EvaluatorWrapper(IEvaluator evaluator)
        {
            _evaluator = evaluator;
            _next = NadaEvaluator.Instance;
        }

        public EvaluatorWrapper AddNext(EvaluatorWrapper next)
        {
            _next = next;
            return next;
        }

        public Rank Evaluate(Hand hand)
        {
            var result = _evaluator.Evaluate(hand);
            return result == Rank.Nada ? _next.Evaluate(hand) : result;
        }
    }
}