using NUnit.Framework;
using PokerHands.Logic;
using PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandsTests
{

    /// <summary>
    /// Tests the HandComparer
    /// 
    /// For expediency of labor, not all combinations have been tested.
    /// In a production environment, it would be best to test all hands and
    /// all combinations.
    /// 
    /// </summary>
    [TestFixture]
    public class HandComparerTests
    {
        HandComparer hc;
        Card[] straightFlushRoyal;
        Card[] straightFlushJackHigh;
        Card[] fullHouseKings;
        Card[] fullHouseFives;
        Card[] twoPairJQ;
        Card[] twoPair7K;
        Card[] high10;

        [SetUp]
        public void Setup()
        {
            hc = new HandComparer();
            straightFlushRoyal = new Card[5];
            straightFlushRoyal[0] = new Card(13, Suite.S);
            straightFlushRoyal[1] = new Card(12, Suite.S);
            straightFlushRoyal[2] = new Card(11, Suite.S);
            straightFlushRoyal[3] = new Card(10, Suite.S);
            straightFlushRoyal[4] = new Card(9, Suite.S);

            straightFlushJackHigh = new Card[5];
            straightFlushJackHigh[0] = new Card(10, Suite.S);
            straightFlushJackHigh[1] = new Card(9, Suite.S);
            straightFlushJackHigh[2] = new Card(8, Suite.S);
            straightFlushJackHigh[3] = new Card(7, Suite.S);
            straightFlushJackHigh[4] = new Card(6, Suite.S);

            fullHouseKings = new Card[5];
            fullHouseKings[0] = new Card(13, Suite.S);
            fullHouseKings[1] = new Card(13, Suite.C);
            fullHouseKings[2] = new Card(13, Suite.D);
            fullHouseKings[3] = new Card(7, Suite.S);
            fullHouseKings[4] = new Card(7, Suite.S);

            fullHouseFives = new Card[5];
            fullHouseFives[0] = new Card(5, Suite.H);
            fullHouseFives[1] = new Card(5, Suite.C);
            fullHouseFives[2] = new Card(5, Suite.D);
            fullHouseFives[3] = new Card(7, Suite.S);
            fullHouseFives[4] = new Card(7, Suite.S);

            twoPairJQ = new Card[5];
            twoPairJQ[0] = new Card(11, Suite.D);
            twoPairJQ[1] = new Card(11, Suite.S);
            twoPairJQ[2] = new Card(12, Suite.C);
            twoPairJQ[3] = new Card(12, Suite.H);
            twoPairJQ[4] = new Card(5, Suite.S);

            twoPair7K = new Card[5];
            twoPair7K[0] = new Card(7, Suite.D);
            twoPair7K[1] = new Card(13, Suite.S);
            twoPair7K[2] = new Card(7, Suite.C);
            twoPair7K[3] = new Card(13, Suite.H);
            twoPair7K[4] = new Card(5, Suite.S);

            high10 = new Card[5];
            high10[0] = new Card(3, Suite.D);
            high10[1] = new Card(1, Suite.S);
            high10[2] = new Card(6, Suite.C);
            high10[3] = new Card(10, Suite.H);
            high10[4] = new Card(5, Suite.S);
        }

        [Test]
        public void StraightFlushCompare()
        {
           
            Hand x = new Hand(straightFlushRoyal);
            Hand y = new Hand(straightFlushJackHigh);
            Assert.AreEqual(1, hc.Compare(x, y));
        }

        [Test]
        public void FullHouseCompare()
        {
            Hand x = new Hand(fullHouseKings);
            Hand y = new Hand(fullHouseFives);
            Assert.AreEqual(1, hc.Compare(x, y));
        }

        [Test]
        public void StraightFlushVsFullHouse()
        {
            Hand x = new Hand(fullHouseKings);
            Hand y = new Hand(straightFlushJackHigh);
            Assert.AreEqual(-1, hc.Compare(x, y));
        }

        [Test]
        public void FullHouseVHigh10()
        {
            Hand x = new Hand(fullHouseKings);
            Hand y = new Hand(high10);
            Assert.AreEqual(1, hc.Compare(x, y));
        }

        [Test]
        public void FullHouseVTwoPair()
        {
            Hand x = new Hand(fullHouseFives);
            Hand y = new Hand(twoPairJQ);
            Assert.AreEqual(1, hc.Compare(x, y));
        }

        [Test]
        public void TwoPairCompare()
        {
            Hand x = new Hand(twoPair7K);
            Hand y = new Hand(twoPairJQ);
            Assert.AreEqual(1, hc.Compare(x, y));
        }

        [Test]
        public void PairSingleHigh()
        {
            Card[] cards1 = new Card[5];
            cards1[0] = new Card(11, Suite.C);
            cards1[1] = new Card(11, Suite.C);
            cards1[2] = new Card(13, Suite.C);
            cards1[3] = new Card(3, Suite.C);
            cards1[4] = new Card(5, Suite.C);

            Card[] cards2 = new Card[5];
            cards2[0] = new Card(11, Suite.C);
            cards2[1] = new Card(11, Suite.C);
            cards2[2] = new Card(10, Suite.C);
            cards2[3] = new Card(3, Suite.C);
            cards2[4] = new Card(5, Suite.C);

            Hand x = new Hand(cards1);
            Hand y = new Hand(cards2);
            Assert.AreEqual(1, hc.Compare(x, y));
        }
    }
}
