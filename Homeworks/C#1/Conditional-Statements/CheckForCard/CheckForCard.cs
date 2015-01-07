//Classical play cards use the following signs to designate the card face:
// `2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. Write a program that enters a string and 
//prints “yes” if it is a valid card sign or “no” otherwise.

namespace CheckForCard
{
    using System;
    class CheckForCard
    {
        static void Main(string[] args)
        {
            Console.Write("Enter card to check: ");
            string card = Console.ReadLine().Trim();


            Console.WriteLine(IsPlayCard(card) ? "yes" : "no");
        }

        private static bool IsPlayCard(string card)
        {
            string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            return (Array.IndexOf(cards, card) != -1);
        }
    }
}
