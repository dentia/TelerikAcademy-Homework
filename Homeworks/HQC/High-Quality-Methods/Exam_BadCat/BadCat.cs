namespace Exam_BadCat
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface INumberRecover
    {
        string Recover();
    }

    internal class BadCat
    {
        private static void Main()
        {
            var numbers = new List<string>();
            int numbersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbersCount; i++)
            {
                string[] command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string add = string.Empty;
                if (command[0] != command[3])
                {
                    if (command[2].ToLower() == "before")
                    {
                        add = command[0] + command[3];
                    }
                    else
                    {
                        add = command[3] + command[0];
                    }

                    numbers.Add(add);
                }
            }

            INumberRecover numberRecover = new NumberRecoverByBuildingGraph(numbers);
            string originalNumber = numberRecover.Recover();

            Console.WriteLine(originalNumber);
        }
    }

    internal class NumberRecoverByBuildingGraph : INumberRecover
    {
        private const int MaxNodes = 10; // 0-9

        private readonly bool[,] graph;
        private readonly bool[] isNode;
        private readonly IEnumerable<string> numbers;

        public NumberRecoverByBuildingGraph(IEnumerable<string> numbers)
        {
            this.numbers = numbers;

            this.graph = new bool[MaxNodes, MaxNodes];
            this.isNode = new bool[MaxNodes];

            this.BuildGraph();
        }

        public string Recover()
        {
            var originalNumber = new StringBuilder();
            var used = new bool[MaxNodes];

            while (true)
            {
                bool removed = false;

                for (int i = 0; i < MaxNodes; i++)
                {
                    if (this.isNode[i] && !used[i])
                    {
                        bool hasPrecedence = false;
                        for (int j = 0; j < MaxNodes; j++)
                        {
                            if (this.graph[i, j])
                            {
                                hasPrecedence = true;
                                break;
                            }
                        }

                        if (!hasPrecedence)
                        {
                            originalNumber.Append(this.GetCharByCharId(i));
                            for (int j = 0; j < MaxNodes; j++)
                            {
                                this.graph[i, j] = false;
                                this.graph[j, i] = false;
                            }

                            used[i] = true;
                            removed = true;
                            break;
                        }
                    }
                }

                if (!removed)
                {
                    break;
                }
            }

            return originalNumber.ToString();
        }

        private void BuildGraph()
        {
            foreach (var number in this.numbers)
            {
                this.isNode[this.GetCharId(number[0])] = true;

                for (int i = 1; i < number.Length; i++)
                {
                    this.isNode[this.GetCharId(number[i])] = true;
                    this.graph[this.GetCharId(number[i]), this.GetCharId(number[i - 1])] = true;
                }
            }
        }

        private int GetCharId(char ch)
        {
            return (int)(ch - '0');
        }

        private char GetCharByCharId(int id)
        {
            return (char)(id + '0');
        }
    }
}