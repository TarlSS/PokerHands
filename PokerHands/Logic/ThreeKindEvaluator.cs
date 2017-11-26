using PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Logic
{
    public class ThreeKindEvaluator:OfAKindEvaluator
    {
        public ThreeKindEvaluator()
        {
            numToCheck = 3;
        }
        public override string ToString()
        {
            return "Three of a kind";
        }
    }
}
