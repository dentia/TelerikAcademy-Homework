//Write a program that generates and prints all possible cards from a standard 
//deck of 52 cards (without the jokers). The cards should be printed using the 
//classical notation (like 5 of spades, A of hearts, 9 of clubs; and K of diamonds).
//The card faces should start from 2 to A.
//Print each card face in its four possible suits: clubs, diamonds, hearts and spades. 
//Use 2 nested for-loops and a switch-case statement.

namespace DeckOfCards
{
    using System;
    class DeckOfCards
    {
        static void Main(string[] args)
        {
            for (int card = 0; card < 13; card++)
            {
                for (int suit = 0; suit < 4; suit++)
                {
                    Console.Write(((Cards)card)
                                    .ToString()
                                    .TrimStart('_')
                                    .PadLeft(2) 
                                    + " of " + (Suits)suit);
                    if (suit != 3) Console.Write(", ");
                }
                Console.WriteLine();
            }
        }
    }
}
