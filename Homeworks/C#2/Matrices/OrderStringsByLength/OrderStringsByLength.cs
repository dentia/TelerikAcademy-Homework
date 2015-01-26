//You are given an array of strings. 
//Write a method that sorts the array by the length 
//of its elements (the number of characters composing them).

namespace OrderStringsByLength
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    class OrderStringsByLength
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter words, separated by a comma: ");
            var words = Console.ReadLine()
                .Split(new char[] { ' ', '\t', ',', '.', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                .OrderByDescending(x => x.Length)
                .ToList();

/*
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas gravida pellentesque tincidunt. Vestibulum consequat erat ultrices leo finibus, ut posuere ligula tempor. Nunc tincidunt lorem eget tortor ultrices, a imperdiet.
*/

            words = words.Distinct().ToList();
            
            foreach (var word in words)
            {
                Console.WriteLine("{0,-6}{1}", word.Length, word);
            }
        }
    }
}
