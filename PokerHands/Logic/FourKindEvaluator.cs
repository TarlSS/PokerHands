using PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Logic
{
    public class FourKindEvaluator:OfAKindEvaluator
    {
        public FourKindEvaluator()
        {
            numToCheck = 4;
        }

        public override string ToString()
        {
            return "Four of a kind";
        }

    }
}
