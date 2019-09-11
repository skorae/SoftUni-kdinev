using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class TreeExtensions
{
    private static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

    public static IReadOnlyDictionary<int, Tree<int>> Tree
        => nodeByValue;

    public static void ReadTree()
    {
        int nodeCount = int.Parse(Console.ReadLine());

        for (int i = 1; i < nodeCount; i++)
        {
            var edge = Console.ReadLine().Split(' ');
            AddEdge(int.Parse(edge[0]), int.Parse(edge[1]));
        }
    }

    public static Tree<int> GetTreeNodeByValue(int value)
    {
        if (!nodeByValue.ContainsKey(value))
        {
            nodeByValue[value] = new Tree<int>(value);
        }

        return nodeByValue[value];
    }

    private static void AddEdge(int parent, int child)
    {
        var parentNode = GetTreeNodeByValue(parent);
        var childNode = GetTreeNodeByValue(child);

        parentNode.Children.Add(childNode);
        childNode.Parent = parentNode;
    }

}
