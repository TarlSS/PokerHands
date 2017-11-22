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

        public int Compare(Hand x, Hand y)
        {
            int xScore = 0;
            int yScore = 0;

            for(int i = evals.Count-1; i >=0; i--)
            {
                HandEvaluator eval = evals[i];
                if (eval.isValid(x) && i>xScore)
                {
                    xScore = i;
                }
                if (eval.isValid(y) && i>yScore)
                {
                    yScore = i;
                }
                if(xScore>0 && yScore > 0)
                {
                    break;
                }
            }
            if (xScore == yScore)
            {
                HandEvaluator eval = evals[xScore];
                return eval.Compare(x, y);
            }

            return xScore.CompareTo(yScore);
        }
        
    }
}
