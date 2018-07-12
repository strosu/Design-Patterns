using System.Linq;

namespace ChainOfCommand.Cards
{
    public class FullEvaluator : IEvaluator
    {
        public Rank Evaluate(Hand hand)
        {
            return hand.Cards.GroupBy(x => x.Value).Count() == 2 ? Rank.Full : Rank.Nada;
        }
    }
}