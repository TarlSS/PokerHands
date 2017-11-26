using PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Logic
{
    public class PairEvaluator : OfAKindEvaluator
    {
        public PairEvaluator()
        {
            numToCheck = 2;
        }

        public override int Compare(Hand x, Hand y)
        {
            int result = x.highCard.rank.CompareTo(y.highCard.rank);
            if (result != 0)
            {
                return result;
            }
            else
            {
                int pairRank = x.highCard.rank;
                Card xHigh = SingleHigh(pairRank, x);
                Card yHigh = SingleHigh(pairRank, y);
                return xHigh.rank.CompareTo(yHigh.rank);
            }
        }


        /// <summary>
        /// If we have two matching pairs, then the highest single card is
        /// used to compare the hands.
        /// </summary>
        /// <param name="rankOfPair"></param>
        /// <param name="hand"></param>
        /// <returns></returns>
        public Card SingleHigh(int rankOfPair, Hand hand)
        {
            Card highCard = null;
            int highestRank = 0;
            Card[] cards = hand.cards;
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].rank != rankOfPair && cards[i].rank > highestRank)
                {
                    highCard = cards[i];
                }
            }
            return highCard;
        }

        public override string ToString()
        {
            return "Pair";
        }

    }
}
