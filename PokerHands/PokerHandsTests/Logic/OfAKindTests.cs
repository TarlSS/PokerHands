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
    /// Tests all pairs, 3k, 4k and full houses. Packed into a single class for convenience.
    /// </summary>
    [TestFixture]
    public class OfAKindTests
    {
        FourKindEvaluator fkEval;
        ThreeKindEvaluator tkEval;
        TwoPairEvaluator tpEval;
        PairEvaluator pEval;
        FullHouseEvaluator fhEval;

        [SetUp]
        public void Setup()
        {
            fkEval = new FourKindEvaluator();
            fhEval = new FullHouseEvaluator();
            tkEval = new ThreeKindEvaluator();
            tpEval = new TwoPairEvaluator();
            pEval = new PairEvaluator();
        }

        [Test]
        public void FourKind_True()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(11, Suite.C);
            cards[1] = new Card(11, Suite.H);
            cards[2] = new Card(11, Suite.D);
            cards[3] = new Card(11, Suite.S);
            cards[4] = new Card(13, Suite.C);
            Hand hand = new Hand(cards);
            bool result=fkEval.isValid(hand);
            Assert.AreEqual(11, hand.highCard.rank);
            Assert.IsTrue(result);
        }

        [Test]
        public void FourKind_False()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(11, Suite.C);
            cards[1] = new Card(11, Suite.H);
            cards[2] = new Card(11, Suite.D);
            cards[3] = new Card(12, Suite.S);
            cards[4] = new Card(13, Suite.C);
            Hand hand = new Hand(cards);
            Assert.IsFalse(fkEval.isValid(hand));
        }

        [Test]
        public void ThreeKind_True()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(11, Suite.C);
            cards[1] = new Card(11, Suite.H);
            cards[2] = new Card(11, Suite.D);
            cards[3] = new Card(12, Suite.S);
            cards[4] = new Card(13, Suite.C);
            Hand hand = new Hand(cards);
            Assert.IsTrue(tkEval.isValid(hand));
        }

        [Test]
        public void ThreeKind_False()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(11, Suite.C);
            cards[1] = new Card(11, Suite.H);
            cards[2] = new Card(1, Suite.D);
            cards[3] = new Card(12, Suite.S);
            cards[4] = new Card(13, Suite.C);
            Hand hand = new Hand(cards);
            Assert.IsFalse(tkEval.isValid(hand));
        }

        [Test]
        public void Pair_True()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(11, Suite.C);
            cards[1] = new Card(11, Suite.H);
            cards[2] = new Card(1, Suite.D);
            cards[3] = new Card(12, Suite.S);
            cards[4] = new Card(13, Suite.C);
            Hand hand = new Hand(cards);
            Assert.IsTrue(pEval.isValid(hand));
        }

        [Test]
        public void Pair_False()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(2, Suite.C);
            cards[1] = new Card(11, Suite.H);
            cards[2] = new Card(1, Suite.D);
            cards[3] = new Card(12, Suite.S);
            cards[4] = new Card(13, Suite.C);
            Hand hand = new Hand(cards);
            Assert.IsFalse(pEval.isValid(hand));
        }

        [Test]
        public void PairSingleHigh()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(11, Suite.C);
            cards[1] = new Card(11, Suite.H);
            cards[2] = new Card(1, Suite.D);
            cards[3] = new Card(12, Suite.S);
            cards[4] = new Card(13, Suite.C);
            Hand hand = new Hand(cards);
            bool valid = pEval.isValid(hand);
            Assert.AreEqual(13, pEval.SingleHigh(hand.highCard.rank, hand).rank);
            Assert.AreEqual(11,hand.highCard.rank);
            Assert.IsTrue(valid);
        }

        [Test]
        public void FullHouse_True()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(1, Suite.C);
            cards[1] = new Card(1, Suite.H);
            cards[2] = new Card(1, Suite.D);
            cards[3] = new Card(12, Suite.S);
            cards[4] = new Card(12, Suite.C);
            Hand hand = new Hand(cards);
            bool valid = fhEval.isValid(hand);
            Assert.AreEqual(1, hand.highCard.rank);
            Assert.IsTrue(valid);
        }

        [Test]
        public void FullHouse_False()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(1, Suite.C);
            cards[1] = new Card(1, Suite.H);
            cards[2] = new Card(1, Suite.D);
            cards[3] = new Card(12, Suite.S);
            cards[4] = new Card(11, Suite.C);
            Hand hand = new Hand(cards);
            bool valid = fhEval.isValid(hand);
            Assert.AreEqual(1, hand.highCard.rank);
            Assert.IsFalse(valid);
        }

        [Test]
        public void TwoPair_True()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(1, Suite.C);
            cards[1] = new Card(1, Suite.H);
            cards[2] = new Card(2, Suite.D);
            cards[3] = new Card(2, Suite.S);
            cards[4] = new Card(11, Suite.C);
            Hand hand = new Hand(cards);
            bool valid = tpEval.isValid(hand);
            Assert.AreEqual(2, hand.highCard.rank);
            Assert.IsTrue(valid);
        }

        [Test]
        public void TwoPair_False()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(1, Suite.C);
            cards[1] = new Card(1, Suite.H);
            cards[2] = new Card(2, Suite.D);
            cards[3] = new Card(1, Suite.S);
            cards[4] = new Card(11, Suite.C);
            Hand hand = new Hand(cards);
            bool valid = tpEval.isValid(hand);
            Assert.IsFalse(valid);
        }


    }
}
