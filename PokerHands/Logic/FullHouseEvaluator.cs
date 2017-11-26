using PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Logic
{
    public class FullHouseEvaluator:OfAKindEvaluator
    {
        public override bool isValid(Hand hand)
        {
            Dictionary<int, int> cardCount = new Dictionary<int, int>();
            Card[] cards = hand.cards;
            CountCards(cardCount, cards);

            bool hasThree = false;
            bool hasTwo = false;


            foreach (int key in cardCount.Keys)
            {
                if (cardCount[key] == 3)
                {
                    hand.highCard = hand.PickCardOfRank(key);
                    hasThree = true;
                }
                if (cardCount[key] == 2)
                {
                    hasTwo = true;
                }
            }

            if(hasThree && hasTwo)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return "Full house";
        }

    }
}
