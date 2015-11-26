namespace TvCompany
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class TvCompany
    {
        public static void Main()
        {
            var edgesCount = int.Parse(Console.ReadLine());

            // [edge from] [edge to] [cost]
            var input = Enumerable.Range(0, edgesCount)
                .Select(x => Console.ReadLine())
                .ToArray();

            var answer = GetMinimalConnectionCost(input);

            Console.WriteLine(answer);
        }

        public static long GetMinimalConnectionCost(string[] input)
        {
            var graph = new Dictionary<int, List<Edge>>();

            foreach (var edge in input)
            {
                var parts = edge.Split();
                var from = int.Parse(parts[0]);
                var to = int.Parse(parts[1]);
                var cost = int.Parse(parts[2]);

                InitializeIfNeeded(graph, from);
                InitializeIfNeeded(graph, to);

                graph[from].Add(new Edge(from, to, cost));
                graph[to].Add(new Edge(to, from, cost));
            }

            var startNode = graph.First().Key;

            var priorityQueue = new OrderedBag<Edge>();

            foreach (var neighbour in graph[startNode])
            {
                priorityQueue.Add(neighbour);
            }

            var cables = new List<Edge>();

            var visitedNodes = new HashSet<int> { startNode };

            while (priorityQueue.Count > 0)
            {
                var min = priorityQueue.RemoveFirst();

                if (visitedNodes.Contains(min.To))
                {
                    continue;
                }

                cables.Add(min);

                visitedNodes.Add(min.To);

                foreach (var neighbour in graph[min.To])
                {
                    priorityQueue.Add(neighbour);
                }
            }

            return cables.Sum(c => c.Cost);
        }

        private static void InitializeIfNeeded(IDictionary<int, List<Edge>> graph, int key)
        {
            if (!graph.ContainsKey(key))
            {
                graph.Add(key, new List<Edge>());
            }   
        }
    }
}
