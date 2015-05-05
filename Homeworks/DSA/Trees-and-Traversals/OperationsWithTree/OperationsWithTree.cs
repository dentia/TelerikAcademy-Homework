// You are given a tree of N nodes represented as a set
// of N-1 pairs of nodes (parent node, child node), each
// in the range (0..N-1).
// Write a program to read
// the tree and find:
// a) the root node
// b) all leaf nodes
// c) all middle nodes
// d) the longest path in the tree
// e) * all paths in the tree with given sum S of their nodes
// f) * all subtrees with given sum S of their nodes

namespace OperationsWithTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class OperationsWithTree
    {
        static void Main()
        {
/*
6
2 4
3 2
5 0
3 5
5 6
5 1
 */

            List<Node<int>> nodes = ReadAndParseInput();

            Console.WriteLine("Root: " + GetRootNode(nodes));

            Console.WriteLine("Leaves: " + string.Join(", ", GetLeafNodes(nodes)));

            List<Node<int>> middleNodes = GetMiddleNodes(nodes);
            Console.WriteLine("Middle nodes: " + ((middleNodes.Count == 0) ? "(none)" : string.Join(", ", middleNodes)));

            var longestPaths = GetLongestPath(nodes);
            var pathStrings = longestPaths.Select(path => "[" + string.Join(" -> ", path.Reverse()) + "]").ToArray();
            Console.WriteLine("Longest path(s): " + string.Join(", ", pathStrings));

            int sumForPath = 9;
            var pathsWithSum = GetPathsWithSum(sumForPath, nodes);
            var pathsWithSumString = pathsWithSum.Select(path => "[" + string.Join(" -> ", path.Reverse()) + "]").ToArray();
            Console.WriteLine("Paths with sum {0}: {1}", 20, string.Join(", ", pathsWithSumString));

            int sumForSubtree = 21;
            var rootsOfSubtrees = GetRootsOfSubtreesWithSum(sumForSubtree, nodes);
            foreach (var root in rootsOfSubtrees)
            {
                Console.WriteLine("Sum: {0}", sumForSubtree);
                StringBuilder sb = new StringBuilder();
                GetTreeAsString(root, sb, 1);
                Console.WriteLine(sb);
                Console.WriteLine(new string('_', 30));
            }
        }

        private static void GetTreeAsString(Node<int> node, StringBuilder sb, int depth)
        {
            sb.AppendLine(new string(' ', (depth - 1) * 3) + "└──"  + node.Value);
            if (node.HasChildren)
            {
                foreach (var child in node.Children)
                {
                    GetTreeAsString(child, sb, depth + 1);
                }
            }
        }

        private static List<Node<int>> GetRootsOfSubtreesWithSum(int sum, List<Node<int>> nodes)
        {
            List<Node<int>> roots = new List<Node<int>>();

            var root = GetRootNode(nodes);
            GetSubtreeSum(sum, root, roots);
            return roots;
        }

        private static int GetSubtreeSum(int sum, Node<int> node, List<Node<int>> roots)
        {
            if (!node.HasChildren)
            {
                if (node.Value == sum) roots.Add(node);
                return node.Value;
            }
            else
            {
                int subtreeSum = node.Value;
                foreach (var child in node.Children)
                {
                    subtreeSum += GetSubtreeSum(sum, child, roots);
                }
                if (subtreeSum == sum) roots.Add(node);
                return subtreeSum;
            }
        }

        

        private static List<Node<int>[]> GetPathsWithSum(int sum, List<Node<int>> nodes)
        {
            List<Node<int>[]> paths = new List<Node<int>[]>();
            foreach (var node in nodes)
            {
                GetPathsFromNode(node, new Stack<Node<int>>(), paths);
            }
            return paths.Where(path => path.Sum(node => node.Value) == sum).ToList();
        }

        private static void GetPathsFromNode(Node<int> node, Stack<Node<int>> stack, List<Node<int>[]> paths)
        {
            stack.Push(node);
            paths.Add(stack.ToArray());

            foreach (var child in node.Children)
            {
                GetPathsFromNode(child, stack, paths);
            }

            stack.Pop();
        }

        private static List<Node<int>[]> GetLongestPath(List<Node<int>> nodes)
        {
            List<Node<int>[]> paths = new List<Node<int>[]>();
            GetPath(GetRootNode(nodes), new Stack<Node<int>>(), paths);
            paths = paths.OrderByDescending(path => path.Length).GroupBy(path => path.Length).First().ToList();
            return paths;
        }
        private static void GetPath(Node<int> node, Stack<Node<int>> path, List<Node<int>[]> paths)
        {
            path.Push(node);

            foreach (var child in node.Children)
            {
                GetPath(child, path, paths);
            }

            if (!node.HasChildren) paths.Add(path.ToArray());

            path.Pop();
        }

        private static List<Node<int>> GetMiddleNodes(List<Node<int>> nodes)
        {
            return nodes.Where(node => node.HasParent && node.HasChildren).ToList();
        }

        private static List<Node<int>> GetLeafNodes(List<Node<int>> nodes)
        {
            if (nodes.Count(node => node.HasChildren == false) < 1)
            {
                throw new Exception("Something's wrong! This tree has no leaves.");
            }

            return nodes.Where(node => node.HasChildren == false).ToList();
        }

        private static Node<int> GetRootNode(List<Node<int>> nodes)
        {
            if (nodes.Count(node => node.HasParent == false) != 1)
            {
                throw new Exception("The tree does not have a root or has more than one node without parent.");
            }

            return nodes.First(node => node.HasParent == false);
        }

        private static List<Node<int>> ReadAndParseInput()
        {
            List<Node<int>> nodes = new List<Node<int>>();

            int edges = int.Parse(Console.ReadLine());

            for (int relation = 0; relation < edges; relation++)
            {
                int[] values = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(value => int.Parse(value))
                    .ToArray();

                var parent = nodes.FirstOrDefault(node => values[0] == node.Value);
                if (parent == null)
                {
                    parent = new Node<int>(values[0]);
                    nodes.Add(parent);
                }

                var child = nodes.FirstOrDefault(node => values[1] == node.Value);
                if (child == null)
                {
                    child = new Node<int>(values[1]);
                    nodes.Add(child);
                }

                parent.AddChild(child);
            }

            return nodes;
        }
    }
}