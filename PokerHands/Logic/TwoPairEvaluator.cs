using PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Logic
{
    public class TwoPairEvaluator:OfAKindEvaluator
    {
        public override bool isValid(Hand hand)
        {
            Dictionary<int, int> cardCount = new Dictionary<int, int>();
            Card[] cards = hand.cards;
            CountCards(cardCount, cards);

            int numPairs = 0;
            int highPair = 0;


            foreach (int key in cardCount.Keys)
            {
                if (cardCount[key] == 2)
                {
                    if (key > highPair)
                    {
                        highPair = key;
                    }
                    numPairs++;
                }
            }
            if (numPairs == 2)
            {
                hand.highCard = hand.PickCardOfRank(highPair);
                return true;
            }
            return false;
        }

    }
}
