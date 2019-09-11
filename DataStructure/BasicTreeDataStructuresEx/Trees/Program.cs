using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        TreeExtensions.ReadTree();

        Console.WriteLine(/*Method name goes here*/);
    }

    #region Problem 1.	Root Node
    private static string PrintRootNodeValue()
    {
        string result = GetRootNode().Value.ToString();

        return result;
    }
    #endregion

    #region Problem 2.	Print Tree
    private static string PrintTree()
    {
        var sb = new StringBuilder();
        var root = GetRootNode();

        PrintNode(sb, root);

        return sb.ToString().TrimEnd();
    }
    #endregion

    #region Problem 3.	Leaf Nodes
    private static string PrintLeafNodes()
    {
        var leafnodes = TreeExtensions.Tree.Values
            .Where(x => x.Children.Count == 0)
            .Select(x => x.Value)
            .OrderBy(x => x)
            .ToList();

        return $"Leaf nodes: {string.Join(" ", leafnodes)}";
    }
    #endregion

    #region Problem 4.	Middle Nodes
    private static string PrintMiddleNodes()
    {
        var middleNodes = TreeExtensions.Tree.Values
            .Where(x => x.Parent != null && x.Children.Count != 0)
            .Select(x => x.Value)
            .OrderBy(x => x)
            .ToList();

        return $"Middle nodes: {string.Join(" ", middleNodes)}";
    }
    #endregion

    #region Problem 5.     Deepest Node
    private static string PrintDeepestNode()
    {
        int result = DeepestNode().Value;

        return $"Deepest node: {result}";
    }
    #endregion

    #region Problem 6.	Longest Path
    private static string PrintLongestPath()
    {
        var result = LongestPath().Select(x => x.Value).ToArray();

        return $"Longest path: {string.Join(" ", result)}";
    }
    #endregion

    #region Problem 7.	All Paths With a Given Sum
    private static string PrintAllPathsWithGivenSum()
    {
        int targetSum = int.Parse(Console.ReadLine());
        var sb = new StringBuilder();

        sb.AppendLine($"Paths of sum {targetSum}:");

        var root = GetRootNode();
        Stack<int> trees = new Stack<int>();

        AllPathsWithGivenSum(sb, trees, root, targetSum);

        return sb.ToString().TrimEnd();
    }
    #endregion

    #region Problem 8.	All Subtrees With a Given Sum
    private static string PrintAllSubtreesWithGivenSum()
    {
        int targetSum = int.Parse(Console.ReadLine());
        var sb = new StringBuilder();

        sb.AppendLine($"Subtrees of sum {targetSum}:");

        var root = GetRootNode();

        AllSubtreesWithGivenSum(sb, targetSum, root);

        return sb.ToString().TrimEnd();
    }

    #endregion

    #region HelperMethods
    private static Tree<int> GetRootNode()
    {
        return TreeExtensions.Tree.Values.FirstOrDefault(x => x.Parent == null);
    }

    private static string PrintNode(StringBuilder sb, Tree<int> root, int indent = 0)
    {
        sb.AppendLine($"{new string(' ', indent * 2)}{root.Value.ToString()}");

        foreach (var child in root.Children)
        {
            PrintNode(sb, child, indent + 1);
        }

        return sb.ToString();
    }

    private static Tree<int> DeepestNode()
    {
        Tree<int> deepestNode = null;
        int deepestCount = 0;
        int count = 1;

        var root = GetRootNode();

        FindDeepestNode(ref deepestNode, ref deepestCount, count, root);

        return deepestNode;
    }

    private static void FindDeepestNode(ref Tree<int> deepestNode, ref int deepestCount, int count, Tree<int> node)
    {
        if (count > deepestCount)
        {
            deepestCount = count;
            deepestNode = node;
        }

        foreach (var child in node.Children)
        {
            FindDeepestNode(ref deepestNode, ref deepestCount, count + 1, child);
        }
    }

    private static IEnumerable<Tree<int>> LongestPath()
    {
        var path = new Stack<Tree<int>>();
        var node = DeepestNode();

        while (node != null)
        {
            path.Push(node);
            node = node.Parent;
        }

        return path.ToArray();
    }

    private static void AllPathsWithGivenSum(StringBuilder sb, Stack<int> trees, Tree<int> node, int targetSum)
    {
        trees.Push(node.Value);

        int sum = trees.Sum();

        if (sum == targetSum)
        {
            sb.AppendLine(string.Join(" ", trees.Reverse()));
        }

        if (sum < targetSum)
        {
            foreach (var child in node.Children)
            {
                AllPathsWithGivenSum(sb, trees, child, targetSum);
            }
        }

        trees.Pop();
    }

    private static int AllSubtreesWithGivenSum(StringBuilder sb, int targetSum, Tree<int> node)
    {
        int sum = node.Value;

        foreach (Tree<int> child in node.Children)
        {
            sum += AllSubtreesWithGivenSum(sb, targetSum, child);
        }

        if (sum == targetSum)
        {
            var values = new List<int>();

            DFSTree(node, values);

            sb.AppendLine(string.Join(" ", values));
        }

        return sum;
    }

    private static void DFSTree(Tree<int> node, List<int> values)
    {
        values.Add(node.Value);

        foreach (Tree<int> child in node.Children)
        {
            DFSTree(child, values);
        }
    }
    #endregion
}
