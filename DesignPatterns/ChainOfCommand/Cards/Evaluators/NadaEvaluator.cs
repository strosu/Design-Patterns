namespace ChainOfCommand.Cards
{
    public class NadaEvaluator : IEvaluator
    {
        public static NadaEvaluator Instance = new NadaEvaluator();
        private NadaEvaluator()
        {
        }

        public Rank Evaluate(Hand hand)
        {
            return Rank.Nada;
        }
    }
}