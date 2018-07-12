using System.Linq;

namespace ChainOfCommand.Cards
{
    public static class CardHelper
    {
        public static bool SameColor(this Hand hand)
        {
            return hand.Cards.GroupBy(x => x.Color).Count() == 1;
        }

        public static bool Consecutive(this Hand hand)
        {
            var cards = hand.Cards.OrderBy(x => x.Value).ToList();
            var  prev = cards.First().Value;

            for (var i = 1; i < cards.Count(); i++)
            {
                if (cards[i].Value != prev + 1)
                {
                    return false;
                }

                prev++;
            }

            return true;
        }

        public static bool Royal(this Hand hand)
        {
            return Consecutive(hand) && hand.Cards.Min(x => x.Value) == 10;
        }
    }
}