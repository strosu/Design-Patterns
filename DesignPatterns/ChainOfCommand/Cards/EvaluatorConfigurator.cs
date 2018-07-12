using ChainOfCommand.Cards.Evaluators;

namespace ChainOfCommand.Cards
{
    public class EvaluatorConfigurator
    {
        private readonly EvaluatorWrapper _head;
        private static readonly EvaluatorConfigurator Instance = new EvaluatorConfigurator();

        private EvaluatorConfigurator()
        {
            _head = new EvaluatorWrapper(new RoyalFlushEvaluator());
            var e2 = new EvaluatorWrapper(new StraightFlushEvaluator());
            var e3 = new EvaluatorWrapper(new FourEvaluator());
            var e4 = new EvaluatorWrapper(new FullEvaluator());
            var e5 = new EvaluatorWrapper(new FlushEvaluator());
            var e6 = new EvaluatorWrapper(new StraightEvaluator());
            var e7 = new EvaluatorWrapper(new ThreeEvaluator());
            var e8 = new EvaluatorWrapper(new TwoPairsEvaluator());
            var e9 = new EvaluatorWrapper(new OnePairEvaluator());

            _head
                .AddNext(e2)
                .AddNext(e3)
                .AddNext(e4)
                .AddNext(e5)
                .AddNext(e6)
                .AddNext(e7)
                .AddNext(e8)
                .AddNext(e9);
        }


        public static IEvaluator Build()
        {
            return Instance._head;
        }
    }
}