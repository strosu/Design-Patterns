using System.Linq;

namespace ChainOfCommand.Cards
{
    public class FourEvaluator : IEvaluator
    {
        public Rank Evaluate(Hand hand)
        {
            return hand.Cards.GroupBy(x => x.Value).Any(x => x.Count() == 4) ? Rank.Four : Rank.Nada;
        }
    }
}