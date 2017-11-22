using PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Logic
{
    public class FlushEvaluator:HandEvaluator
    {

        public bool isValid(Hand hand)
        {
            Card[] cards = hand.cards;
            Suite first = cards[0].suite;
            for(int i = 0; i < cards.Count(); i++)
            {
                if (cards[i].suite != first)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// EXAMPLE extension. If we want to add jokers, we can evaluate
        /// based on whether there are jokers in the hand, and how many.
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="jokerCount"></param>
        /// <returns></returns>
        public bool isValidWithJokers(Hand hand, int jokerCount)
        {
            Card[] cards = hand.cards;
            Suite first = cards[0].suite;
            //Since our hand is sorted, we evaluate up to the jokers
            for (int i = 0; i < cards.Count()-jokerCount; i++)
            {
                if (cards[i].suite != first)
                {
                    return false;
                }
            }
            return true;
        }

        public virtual int Compare(Hand x, Hand y)
        {
            return x.highCard.rank.CompareTo(y.highCard.rank);
        }
    }
}
