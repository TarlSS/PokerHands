using PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Logic
{
    /// <summary>
    /// Abstract class for "Rank Match" type hands such as
    /// Pair, 3 of a kind, 4 of a kind, Full house
    /// Sets the high card on a valid match
    /// </summary>
    public abstract class OfAKindEvaluator:HandEvaluator
    {
        public int numToCheck;

        public virtual bool isValid(Hand hand)
        {
            Dictionary<int, int> cardCount = new Dictionary<int, int>();
            Card[] cards = hand.cards;
            CountCards(cardCount, cards);
            foreach(int key in cardCount.Keys)
            {
                if (cardCount[key] == numToCheck)
                {
                    hand.highCard = hand.PickCardOfRank(key);
                    return true;
                }
            }
            return false;
        }


        public virtual int Compare(Hand x, Hand y)
        {
            return x.highCard.rank.CompareTo(y.highCard.rank);
        }

        protected static void CountCards(Dictionary<int, int> cardCount, Card[] cards)
        {
            for (int i = 0; i < cards.Count(); i++)
            {
                if (cardCount.ContainsKey(cards[i].rank))
                {
                    cardCount[cards[i].rank]++;
                }
                else
                {
                    cardCount[cards[i].rank] = 1;
                }
            }
        }

    }
}
