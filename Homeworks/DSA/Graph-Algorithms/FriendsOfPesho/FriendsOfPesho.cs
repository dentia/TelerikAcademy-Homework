namespace FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FriendsOfPesho
    {
        private static List<KeyValuePair<int, int>>[] graph;
        private static HashSet<int> hospitalIds;
        private static int minimalDistance;

        internal static void Main()
        {
            minimalDistance = int.MaxValue;

            var parameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            hospitalIds = new HashSet<int>(Console.ReadLine().Split(' ').Select(x => int.Parse(x) - 1));

            graph = Enumerable.Range(0, parameters[0])
                              .Select(i => new List<KeyValuePair<int, int>>())
                              .ToArray();

            for (var i = 0; i < parameters[1]; i++)
            {
                var nodesInfo = Console.ReadLine()
                    .Split(' ')
                    .Select(x => int.Parse(x) - 1)
                    .ToArray();
                graph[nodesInfo[0]].Add(new KeyValuePair<int, int>(nodesInfo[1], nodesInfo[2] + 1));
                graph[nodesInfo[1]].Add(new KeyValuePair<int, int>(nodesInfo[0], nodesInfo[2] + 1));
            }

            FindMinimalDistance();
            Console.WriteLine(minimalDistance);
        }

        private static void FindMinimalDistance()
        {
            foreach (
                var distance in
                    hospitalIds.Select(FindMinimalDistanceDijkstra)
                        .Select(dijkstraDistances => dijkstraDistances.Where((a, b) => !hospitalIds.Contains(b)).Sum()))
            {
                minimalDistance = Math.Min(minimalDistance, distance);
            }
        }

        private static int[] FindMinimalDistanceDijkstra(int startNode)
        {
            var queue = new Queue<KeyValuePair<int, int>>();
            queue.Enqueue(new KeyValuePair<int, int>(startNode, 0));

            var distances = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();
            distances[startNode] = 0;

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                foreach (var neighbour in graph[currentNode.Key])
                {
                    var currentDistance = distances[currentNode.Key] + neighbour.Value;
                    if (currentDistance >= distances[neighbour.Key])
                    {
                        continue;
                    }

                    distances[neighbour.Key] = currentDistance;
                    queue.Enqueue(new KeyValuePair<int, int>(neighbour.Key, currentDistance));
                }
            }

            return distances;
        }
    }
}
