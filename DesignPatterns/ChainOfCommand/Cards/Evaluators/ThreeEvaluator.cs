using System.Linq;

namespace ChainOfCommand.Cards
{
    public class ThreeEvaluator : IEvaluator
    {
        public Rank Evaluate(Hand hand)
        {
            return hand.Cards.GroupBy(x => x.Value).Any(x => x.Count() == 3) ? Rank.Three : Rank.Nada;
        }
    }
}