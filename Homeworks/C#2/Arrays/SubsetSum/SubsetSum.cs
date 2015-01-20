//We are given an array of integers and a number S. 
//Write a program to find if there exists a subset 
//of the elements of the array that has a sum S. Example:
//arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)

//&&

//Write a program that reads three integer numbers N, K 
//and S and an array of N elements from the console. 
//Find in the array a subset of K elements that have 
//sum S or indicate about its absence.

namespace SubsetSum
{
    using System;
    using System.Text;
    using System.Linq;
    class SubsetSum
    {
        static StringBuilder result = new StringBuilder();
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers, separated by a comma: ");
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .Where(x => x != 0)
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine("Enter SUM: ");
            int sum = int.Parse(Console.ReadLine());

            Console.WriteLine(@"Enter elements count
(If you dont'want to set the count, press Enter): ");
            string inputCount = Console.ReadLine();
            int? elementCount;
            if (String.IsNullOrWhiteSpace(inputCount))
            {
                elementCount = null;
            }
            else
            {
                elementCount = int.Parse(inputCount);
            }

            SubsetGenerator generator = new SubsetGenerator(numbers, sum);
            string result = generator.GetResult(elementCount);
            if (String.IsNullOrWhiteSpace(result))
                result = String.Format("No subsets with sum {0} were found!", sum);

            Console.WriteLine(result);
        }
    }
}
