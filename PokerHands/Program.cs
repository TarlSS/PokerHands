using PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    /// <summary>
    /// EA Test evalation for Poker Hands. Based on standard poker, no variations. (Not hold'm, no river)
    /// Test: https://docs.google.com/document/d/1PPYM_fCUFjFQlUX4PCCwknQdfgde8GCDH10jD0kh-5c/edit
    /// Hands: https://en.wikipedia.org/wiki/List_of_poker_hands
    /// 
    /// As a design choice, this program was made for readability and modularity rather than 
    /// optimized performance. It is possible to create highly optimized card readers with 
    /// tricks like bit registers/etc, but since modern devices are so fast I have erred on
    /// the side of maintainability. Additionally, for an interview exercise I believe it is 
    /// better to show off code and design
    /// 
    /// Testing: I have only implemented some unit tests for convenience. Ideally we would want
    /// 100% code coverage but that's too much labor for an interview question. I have provided
    /// the included tests for code-style evaluation.
    /// 
    /// Testing Automation: In a production environment we would want to have the ability to quickly
    /// generate hands and do so expediantly in something like a console. We would also want an automated test
    /// where the computer might play multiple games against itself. However, that is outside the scope of this
    /// interview evaluation.
    /// 
    /// Comments: As per Clean Code by Robert C. Martin, I only add comments where necessary and let
    /// the code be the comment. I can adapt to a different style if necessary.
    /// 
    /// Jokers: As this is an interview evaluation, I have elected to use casino rules and to not include jokers.
    /// Adding jokers would add more labor and require me to write a significant amount of test cases for them.
    /// However we could extend the evaluation classes to change our verification algorithms to allow jokers.
    /// I added an example of a possible joker extension in FlushEvaluator and the Flush tests under PokerHandsTests
    /// 
    /// Cheating/Multideck: I don't account for cheating or multiple decks, as that is outside the scope of the test. 
    /// This means it's possible to hands like 4 of a kind with all cards in the same suite if you set it up that way.
    /// There are likely strange combos due to this, I'm letting it go to account for labor.
    /// 
    /// Aces: Aces are not high for this program
    /// 
    /// Author: Alex Lau
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Card[] cards = new Card[5];
            for(int i = 0; i < 5; i++)
            {
                cards[i] = Card.Random();
            }

            Hand hand = new Hand(cards);
            hand.Print();

            Console.ReadKey();
        }
    }
}
