# PokerHands


EA Test evalation for Poker Hands. Based on standard poker, no variations. (Not hold'm, no river)

Test: https://docs.google.com/document/d/1PPYM_fCUFjFQlUX4PCCwknQdfgde8GCDH10jD0kh-5c/edit

Hands: https://en.wikipedia.org/wiki/List_of_poker_hands

Etymology note: A "Hand" refers to both a hand of cards (eg the 5 cards physically in a player's hand) as well as
sets of cards such as a Full house and A Flush. It can be confusing to reference but since most pokwer literature
uses 'hand' interchangably then this program will as well.

As a design choice, this program was made for readability and modularity rather than 
optimized performance. It is possible to create highly optimized card readers with 
tricks like bit registers/etc, but since modern devices are so fast I have erred on
the side of maintainability. Additionally, for an interview exercise I believe it is 
better to show off code and design.

Project Layout: The code for the poker hands is in the "PokerHands" project, and the test code
is in "PokerHandsTests" which references PokerHands.
Pokerhands is divided up into 3 folders, Logic, Models and Utility. The Models class holds the classes for Card and Hand.
The Logic class holds the HandEvaluator interface, HandEvaluators and the HandComparer. The HandComparer uses these
evaluators to determine the highest poker hand for each Hand and can compare two Hands and declare a winner. 

Usage: You can run the driver program to randomly generate 2 hands and test them. You can also use NUnit to run
the included tests. This project is a Visual Studio C# Solution and contains a Console Project and a Unit Test Project
Clone the repository and run the solution.

Testing: I have only implemented some unit tests for convenience. Ideally we would want
100% code coverage but that's too much labor for an interview question. I have provided
the included tests for code-style evaluation.

Testing Automation: In a production environment we would want to have the ability to quickly
generate hands and do so expediantly in something like a console. We would also want an automated test
where the computer might play multiple games against itself. However, that is outside the scope of this
interview evaluation.

Comments: As per Clean Code by Robert C. Martin, I only add comments where necessary and let
the code be the comment. I can adapt to a different style if necessary.

NOTES ON GAME RULES

No Legal Deck Construction: This library is independant of card decks and deck construction. No methods or ability to create a standard
52 card deck have been included. This was a deliberate choice as decks are outside the bounds of the assignment, and also to 
allow for extension for games that don't utilize standard decks. (Four deck Poker, games like Malifaux and Deadlands)

No Jokers: As this is an interview evaluation, I have elected to use casino rules and to not include jokers.
Adding jokers would add more labor and require me to write a significant amount of edge and test cases for them.
However we could extend the evaluation classes to change our verification algorithms to allow jokers.
I added an example of a possible joker extension in FlushEvaluator and the Flush tests under PokerHandsTests.

No 5 of a Kind: Because I elected not to use jokers, 5 a kind is not implemented here.

Cheating/Multideck: I don't account for cheating or multiple decks, as that is outside the scope of the test. 
This means it's possible to hands like 4 of a kind with all cards in the same suite if you set it up that way.
There are likely strange combos due to this, I'm letting it go to account for labor.

Aces Low: Aces are not high for this program. They evaluate as 1. Straights with aces high have not been included in the Straight evaluator.

Driver Program: The driver program generates two hands, lists what the hands are and then tells us 
the winning hand. The program does not use a legal deck, it just generates 5 cards randomly for each hand.
Press q to quit or any key to generate hands.

Author: Alex Lau
