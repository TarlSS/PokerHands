using NUnit.Framework;
using PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandsTests
{
    [TestFixture]
    public class CardTests
    {
        [Test]
        public void CompareGreater()
        {
            int expected = 1;
            Card c1 = new Card(13, Suite.C);
            Card c2 = new Card(12, Suite.C);
            Assert.AreEqual(expected, c1.CompareTo(c2));
        }

        [Test]
        public void CompareEquals()
        {
            int expected = 0;
            Card c1 = new Card(13, Suite.C);
            Card c2 = new Card(13, Suite.H);
            Assert.AreEqual(expected, c1.CompareTo(c2));
        }

        /// <summary>
        /// Make sure we have equality based on suite and rank
        /// </summary>
        [Test]
        public void Equals_True()
        {
            Card c1 = new Card(13, Suite.C);
            Card c2 = new Card(13, Suite.C);

            Assert.AreEqual(c1, c2);
        }

        [Test]
        public void Equals_FalseRankDifference()
        {
            Card c1 = new Card(10, Suite.C);
            Card c2 = new Card(13, Suite.C);

            Assert.AreNotEqual(c1, c2);
        }

        [Test]
        public void Equals_FalseSuiteDifference()
        {
            Card c1 = new Card(13, Suite.H);
            Card c2 = new Card(13, Suite.C);

            Assert.AreNotEqual(c1, c2);
        }

        /// <summary>
        /// Make sure we're generating random cards
        /// </summary>
        [Test]
        public void Random()
        {
            int threshold = 10; //Unlikely to not have at least 10 different cards.
            int size = 1000;
            Card[] cards = new Card[size];
            Dictionary<Card, int> cardCount = new Dictionary<Card, int>();
            for (int i = 0; i < size; i++)
            {
                Card c = Card.Random();
                if (cardCount.ContainsKey(c))
                {
                    cardCount[c]++;
                }else
                {
                    cardCount.Add(c, 1);
                }
            }

            Assert.Greater(cardCount.Count, threshold);

        }
    }
}
