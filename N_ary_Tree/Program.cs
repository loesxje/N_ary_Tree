using System;
using System.Collections.Generic;

namespace N_ary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            // how to make the tree a root? Now it is not really included, does that matter?
            var NAryTree = new Tree<int>();
            var root = new TreeNode<int>(5, null, new List<TreeNode<int>>());

            var child1 = NAryTree.AddChildNode(root, 5);

            var parent1 = NAryTree.GrowUp(child1);
            var child2 = NAryTree.AddChildNode(parent1, 4);
            var child3 = NAryTree.AddChildNode(parent1, 7);

            var parent2 = NAryTree.GrowUp(child3);
            var child4 = NAryTree.AddChildNode(parent2, 13);
            var child5 = NAryTree.AddChildNode(parent2, 2);
            var child6 = NAryTree.AddChildNode(parent2, 9);

            var parent3 = NAryTree.GrowUp(child2);
            var child7 = NAryTree.AddChildNode(parent3, 1);
            var child8 = NAryTree.AddChildNode(parent3, 2);

            printData(NAryTree);

            NAryTree.SumToLeafs();

            NAryTree.TraverseNodes();


            NAryTree.removeNode(child5);
            NAryTree.removeNode(parent2);
            printData(NAryTree);

            NAryTree.SumToLeafs();
        }
        static void printData(Tree<int> tree)
        {
            foreach (TreeNode<int> temptree in tree.AllChildren)
            {
                Console.WriteLine($"Value: {temptree.Data}, Order: {temptree.Order}");
            }
            Console.WriteLine($"Node Count: {tree.Count}");
            Console.WriteLine($"Leaf Node Count: {tree.LeafCount}");
            Console.ReadLine();
        }
    }
}

// https://www.geeksforgeeks.org/serialize-deserialize-n-ary-tree/