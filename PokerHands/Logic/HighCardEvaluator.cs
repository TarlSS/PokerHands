using PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Logic
{
    public class HighCardEvaluator:OfAKindEvaluator
    {
        public override bool isValid(Hand hand)
        {
            return true;
        }

        public override string ToString()
        {
            return "High Card";
        }

    }
}
