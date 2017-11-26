using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Models
{
    /// <summary>
    /// Represents 5 Cards in hand (Standard poker)
    /// </summary>
    public class Hand
    {
        //What do we call this card? FullHouse, Straight, etc
        public string label;
        public Card[] cards;
        //What's our high card? Hand evaluators can change this for fullHouse, 3 Kind and 4 Kind
        public Card highCard;

        public Hand (Card[] cards)
        {
            this.cards = cards;
            if (cards.Length != 5)
            {
                throw new Exception("Invalid Hand Size");
            }
            SortCards();
            //Since we sort, the high card is initially the last (largest) one.
            highCard = cards[4];
        }

        public static Hand CreateHand()
        {
            Card[] cards = new Card[5];
            for (int i = 0; i < 5; i++)
            {
                cards[i] = Card.Random();
            }

            Hand hand = new Hand(cards);
            return hand;
        }

        /// <summary>
        /// Pick any card that matches the given rank
        /// Returns null if no card is available.
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        public Card PickCardOfRank(int rank)
        {
            for(int i = 0; i < cards.Length; i++)
            {
                if (cards[i].rank == rank)
                {
                    return cards[i];
                }
            }
            return null;
        }


        void SortCards()
        {
            Array.Sort<Card>(cards);
        }

        public void Print()
        {
            foreach(Card card in cards)
            {
                Console.Write(card+" ");
            }
            Console.WriteLine();
        }
    }
}
