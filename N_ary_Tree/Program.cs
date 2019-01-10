using System;
using System.Collections.Generic;

namespace N_ary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> NAryTree = new Tree<int>();
            TreeNode<int> root = new TreeNode<int>(5, null, new List<TreeNode<int>>());

            var child1 = NAryTree.AddChildNode(root, 5);

            var parent1 = NAryTree.GrowUp(child1);
            var child2 = NAryTree.AddChildNode(parent1, 4);
            var child3 = NAryTree.AddChildNode(parent1, 7);

            var parent2 = NAryTree.GrowUp(child3);
            var child4 = NAryTree.AddChildNode(parent2, 13);
            var child5 = NAryTree.AddChildNode(parent2, 2);
            var child6 = NAryTree.AddChildNode(parent2, 9);


            Console.WriteLine($"N-ary Tree!: {root.Data}");
            Console.WriteLine($"Node Count: {NAryTree.Count}");
            Console.WriteLine($"Leaf Node Count: {NAryTree.LeafCount}");
            Console.ReadLine();
        }
    }
}

// https://www.geeksforgeeks.org/serialize-deserialize-n-ary-tree/