using System.Collections;
using System.Collections.Generic;

namespace ChainOfCommand.Cards
{
    public class Hand
    {
        public IList<Card> Cards;

        public Hand(IList<Card> cards)
        {
            Cards = cards;
        }
    }
}