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
    public class PokerHandTests
    {
        [Test]
        public void HighCard()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(11, Suite.C);
            cards[1] = new Card(1, Suite.C);
            cards[2] = new Card(13, Suite.H);
            cards[3] = new Card(3, Suite.C);
            cards[4] = new Card(5, Suite.C);
            Card expected = cards[2];
            Hand hand = new Hand(cards);
            Assert.AreEqual(expected, hand.highCard);
        }

        [Test]
        public void HighCard_Pair()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(11, Suite.C);
            cards[1] = new Card(13, Suite.C);
            cards[2] = new Card(13, Suite.H);
            cards[3] = new Card(3, Suite.C);
            cards[4] = new Card(5, Suite.C);
            Card expected = cards[1];
            Hand hand = new Hand(cards);
            Assert.AreEqual(expected.rank, hand.highCard.rank);
        }

    }
}
