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
    /// Tests all straights and flushes. Packed into a single class for convenience.
    /// </summary>
    [TestFixture]
    public class StraightAndFlushTests
    {
        [Test]
        public void Flush_True()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(11, Suite.C);
            cards[1] = new Card(1, Suite.C);
            cards[2] = new Card(13, Suite.C);
            cards[3] = new Card(3, Suite.C);
            cards[4] = new Card(5, Suite.C);
            Hand hand = new Hand(cards);
            FlushEvaluator eval = new FlushEvaluator();
            Assert.IsTrue(eval.isValid(hand));
        }

        [Test]
        public void Flush_False()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(11, Suite.C);
            cards[1] = new Card(1, Suite.H);
            cards[2] = new Card(13, Suite.H);
            cards[3] = new Card(3, Suite.H);
            cards[4] = new Card(5, Suite.H);
            Hand hand = new Hand(cards);
            FlushEvaluator eval = new FlushEvaluator();
            Assert.IsFalse(eval.isValid(hand));
        }

        /// <summary>
        /// Example of a flush test with jokers
        /// </summary>
        [Test]
        public void FlushJoker_True()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(14, Suite.C);
            cards[1] = new Card(1, Suite.H);
            cards[2] = new Card(13, Suite.H);
            cards[3] = new Card(3, Suite.H);
            cards[4] = new Card(5, Suite.H);
            Hand hand = new Hand(cards);
            FlushEvaluator eval = new FlushEvaluator();
            Assert.IsTrue(eval.isValidWithJokers(hand,1));
        }

        [Test]
        public void FlushJoker_False()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(14, Suite.C);
            cards[1] = new Card(1, Suite.S);
            cards[2] = new Card(13, Suite.H);
            cards[3] = new Card(3, Suite.H);
            cards[4] = new Card(5, Suite.H);
            Hand hand = new Hand(cards);
            FlushEvaluator eval = new FlushEvaluator();
            Assert.IsFalse(eval.isValidWithJokers(hand, 1));
        }

        [Test]
        public void FlushTwoJokers()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(14, Suite.C);
            cards[1] = new Card(14, Suite.S);
            cards[2] = new Card(13, Suite.H);
            cards[3] = new Card(3, Suite.H);
            cards[4] = new Card(5, Suite.H);
            Hand hand = new Hand(cards);
            FlushEvaluator eval = new FlushEvaluator();
            Assert.IsTrue(eval.isValidWithJokers(hand, 2));
        }

        [Test]
        public void Straight_True()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(1, Suite.S);
            cards[1] = new Card(2, Suite.C);
            cards[2] = new Card(3, Suite.H);
            cards[3] = new Card(4, Suite.C);
            cards[4] = new Card(5, Suite.C);
            Hand hand = new Hand(cards);
            StraightEvaluator eval = new StraightEvaluator();
            Assert.IsTrue(eval.isValid(hand));
        }

        [Test]
        public void Straight_False()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(1, Suite.S);
            cards[1] = new Card(2, Suite.C);
            cards[2] = new Card(6, Suite.H);
            cards[3] = new Card(4, Suite.C);
            cards[4] = new Card(5, Suite.C);
            Hand hand = new Hand(cards);
            StraightEvaluator eval = new StraightEvaluator();
            Assert.IsFalse(eval.isValid(hand));
        }

        [Test]
        public void StraightFlush_True()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(1, Suite.C);
            cards[1] = new Card(2, Suite.C);
            cards[2] = new Card(3, Suite.C);
            cards[3] = new Card(4, Suite.C);
            cards[4] = new Card(5, Suite.C);
            Hand hand = new Hand(cards);
            StraightFlushEvaluator eval= new StraightFlushEvaluator();
            Assert.IsTrue(eval.isValid(hand));
        }

        [Test]
        public void StraightFlush_FalseOnRank()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(1, Suite.C);
            cards[1] = new Card(2, Suite.C);
            cards[2] = new Card(2, Suite.C);
            cards[3] = new Card(4, Suite.C);
            cards[4] = new Card(5, Suite.C);
            Hand hand = new Hand(cards);
            StraightFlushEvaluator eval = new StraightFlushEvaluator();
            Assert.IsFalse(eval.isValid(hand));
        }

        [Test]
        public void StraightFlush_FalseOnSuite()
        {
            Card[] cards = new Card[5];
            cards[0] = new Card(1, Suite.C);
            cards[1] = new Card(2, Suite.C);
            cards[2] = new Card(2, Suite.C);
            cards[3] = new Card(4, Suite.C);
            cards[4] = new Card(5, Suite.C);
            Hand hand = new Hand(cards);
            StraightFlushEvaluator eval = new StraightFlushEvaluator();
            Assert.IsFalse(eval.isValid(hand));
        }


    }
}
