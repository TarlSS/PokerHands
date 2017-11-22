using PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Logic
{
    public interface HandEvaluator:IComparer<Hand>
    {
        //Is this a valid version of the hand?
        bool isValid(Hand hand);
        /// <summary>
        /// Return 1, 0 or -1 depending on comparable
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
    }
}
