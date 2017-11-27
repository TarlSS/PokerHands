using PokerHands.Logic;
using PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    /// <summary>
    /// Main program that generates two random poker hands and compares them.
    /// Does not utilize a deck so illegal hands are possible.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            char input;
            
            do
            {
                Console.WriteLine("Hit q to quit or any key to generate hands");
                HandComparer handcomp = new HandComparer();
                Hand x = Hand.CreateHand();
                Hand y = Hand.CreateHand();

                Console.WriteLine("Hand X:" + handcomp.GetHandType(x) +" "+ x.highCard.ToString());
                x.Print();
                Console.WriteLine("Hand y:" + handcomp.GetHandType(y) +" "+ y.highCard.ToString());
                y.Print();
                int result = handcomp.Compare(x, y);
                string winner;
                if (result == 1)
                {
                    winner = "X";
                }else if (result == -1)
                {
                    winner = "Y";
                }else
                {
                    winner = "Tie";
                }
                Console.WriteLine("Winner:"+winner);

                input = Console.ReadKey().KeyChar;
            } while (input != 'q');
        }

    }
}
