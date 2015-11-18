namespace Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Bunnies
    {
        public static void Main()
        {
            var inputLinesCount = uint.Parse(Console.ReadLine());
            var bunniesAnswers = new List<uint>();

            for (int bunnyAnswer = 0; bunnyAnswer < inputLinesCount; bunnyAnswer++)
            {
                bunniesAnswers.Add(uint.Parse(Console.ReadLine()) + 1);
            }

            var answersByGroups = bunniesAnswers.GroupBy(answer => answer);

            ulong minimalBunniesCount = 0;

            foreach (var answerGroup in answersByGroups)
            {
                var key = answerGroup.Key;
                var count = answerGroup.Count();

                var separateGroupsOfBunnies = (uint)(count / key);

                if (count % key != 0)
                {
                    separateGroupsOfBunnies++;
                }

                minimalBunniesCount += separateGroupsOfBunnies * key;
            }

            Console.WriteLine(minimalBunniesCount);
        }
    }
}
