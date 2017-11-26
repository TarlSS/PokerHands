using PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Logic
{
    /// <summary>
    /// Compares hands using customized evaluators for judging hands
    /// We can change the order of importance (Making pair > full house if we want)
    /// by changing the order of the HandEvaluators.
    /// </summary>
    public class HandComparer:IComparer<Hand>
    {
        /// <summary>
        /// Evaluators should be ordered from least to highest
        /// </summary>
        public List<HandEvaluator> evals;

        /// <summary>
        /// Create a handcomparer using default poker rules
        /// </summary>
        public HandComparer()
        {
            evals = new List<HandEvaluator>();
            evals.Add(new HighCardEvaluator());
            evals.Add(new PairEvaluator());
            evals.Add(new TwoPairEvaluator());
            evals.Add(new ThreeKindEvaluator());
            evals.Add(new StraightEvaluator());
            evals.Add(new FlushEvaluator());
            evals.Add(new FullHouseEvaluator());
            evals.Add(new FourKindEvaluator());
            evals.Add(new StraightFlushEvaluator());

        }

        /// <summary>
        /// Create a handcomparer that allows for custom evaluator ordering
        /// </summary>
        /// <param name="evals"></param>
        public HandComparer(List<HandEvaluator> evals)
        {
            this.evals = evals;
        }

        /// <summary>
        /// Evaluate whether the given hand is a valid poker hand
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public static bool isValid(Hand hand)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the score of this hand.
        /// Based on the order of evaluators, ordered from top to bottom
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int GetScore(Hand hand)
        {
            for (int i = evals.Count - 1; i >= 0; i--)
            {
                HandEvaluator eval = evals[i];
                if (eval.isValid(hand))
                {
                    return i;
                }
            }
            return -1;
        }

        public string GetHandType(Hand hand)
        {
            int score = GetScore(hand);
            return evals[score].ToString();
        }

        /// <summary>
        /// Compares one hand to another
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(Hand x, Hand y)
        {
            int xScore = GetScore(x);
            int yScore = GetScore(y);

            //If both hands are of the same type (eg 2 full houses) then 
            //we need to compare them hand-to-hand (eg high card in a full house)
            if (xScore == yScore)
            {
                HandEvaluator eval = evals[xScore];
                return eval.Compare(x, y);
            }
            //Else one hand is > then the other (full house vs two pair)
            return xScore.CompareTo(yScore);
        }
        
    }
}
