using PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Logic
{
    public class StraightEvaluator:HandEvaluator
    {

        public bool isValid(Hand hand)
        {
            Card[] cards = hand.cards;
           
            for(int i = 0; i < cards.Count()-1; i++)
            {
                if (cards[i].rank+1 != cards[i + 1].rank)
                {
                    return false;
                }
            }
            return true;
        }

        public int Compare(Hand x, Hand y)
        {
            return x.highCard.rank.CompareTo(y.highCard.rank);
        }
    }
}
