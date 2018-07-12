using System.Linq;

namespace ChainOfCommand.Cards
{
    public class TwoPairsEvaluator : IEvaluator
    {
        public Rank Evaluate(Hand hand)
        {
            var groups = hand.Cards.GroupBy(x => x.Value);
            return groups.Count(x => x.Count() == 2) == 2 ? Rank.TwoPairs : Rank.Nada;
        }
    }
}