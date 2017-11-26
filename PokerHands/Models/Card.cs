using PokerHands.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Models
{
    public enum Suite {H, S, C, D};

    /// <summary>
    /// Represents cards.
    /// Possible Extension:Jokers are rank 14, suite doesn't matter
    /// </summary>
    public class Card: IComparable<Card>
    {
        public int rank;
        public Suite suite;

        public Card(int rank, Suite suite)
        {
            this.rank = rank;
            if(rank > 14)
            {
                throw new Exception("Card cannot have rank > 14");
            }
            this.suite = suite;
        }

        public static Card Random()
        {
            int rank = RandomUtility.NextInt(13) + 1;
            Suite suite = RandomUtility.EnumOf<Suite>();
            return new Card(rank, suite);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                Card c = (Card)obj;
                return (rank == c.rank) && (suite == c.suite);
            }
        }

        public int CompareTo(Card other)
        {
            return rank.CompareTo(other.rank);
        }

        public override string ToString()
        {
            return suite.ToString() + rank.ToString();
        }
    }
}
