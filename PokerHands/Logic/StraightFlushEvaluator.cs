using PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Logic
{
    /// <summary>
    /// StraightFlush Evaluator
    /// 
    /// Combines straight and flush evaluators
    /// </summary>
    public class StraightFlushEvaluator:HandEvaluator
    {

        private StraightEvaluator straightEval;
        private FlushEvaluator flushEval;

        /// <summary>
        /// Stand alone constructor for testing or isolated evaluation
        /// </summary>
        public StraightFlushEvaluator()
        {
            this.straightEval = new StraightEvaluator();
            this.flushEval = new FlushEvaluator();
        }

        /// <summary>
        /// Constructor for use with dependency injection. Add in existing evaluators
        /// for object efficiency.
        /// </summary>
        /// <param name="straightEval"></param>
        /// <param name="flushEval"></param>
        public StraightFlushEvaluator(StraightEvaluator straightEval, FlushEvaluator flushEval)
        {
            this.straightEval = straightEval;
            this.flushEval = flushEval;
        }

        public bool isValid(Hand hand)
        {
            return flushEval.isValid(hand) && straightEval.isValid(hand);
        }

        public virtual int Compare(Hand x, Hand y)
        {
            return x.highCard.rank.CompareTo(y.highCard.rank);
        }

        public override string ToString()
        {
            return "Straight flush";
        }
    }
}
