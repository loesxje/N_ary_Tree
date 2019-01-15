using System;
using System.Collections.Generic;

namespace N_ary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            // how to make the tree a root? Now it is not really included, does that matter?
            var NAryTree = new Tree<string>();
            var root = new TreeNode<string>("Grootoma", null, new List<TreeNode<string>>());

            var child1 = NAryTree.AddChildNode(root, "Oma");

            var parent1 = NAryTree.GrowUp(child1);
            var child2 = NAryTree.AddChildNode(parent1, "Papa");
            var child3 = NAryTree.AddChildNode(parent1, "Mama");

            var parent2 = NAryTree.GrowUp(child3);
            var child4 = NAryTree.AddChildNode(parent2, "Broer");
            var child5 = NAryTree.AddChildNode(parent2, "Zus");
            var child6 = NAryTree.AddChildNode(parent2, "Ik");

            var parent3 = NAryTree.GrowUp(child2);
            var child7 = NAryTree.AddChildNode(parent3, "Stiefbroer");
            var child8 = NAryTree.AddChildNode(parent3, "Stiefzus");

            var sumtoleafs1 = NAryTree.SumToLeafs();
            foreach(var sum in sumtoleafs1)
                Console.WriteLine(sum);
            Console.ReadLine();

            var traversed = NAryTree.TraverseNodes();
            foreach (var val in traversed)
                Console.Write(val);
            Console.ReadLine();

            NAryTree.removeNode(child5);
            NAryTree.removeNode(parent2);

            var sumtoleafs2 = NAryTree.SumToLeafs();
            foreach (var sum in sumtoleafs2)
                Console.WriteLine(sum);

            Console.ReadLine();
        }
    }
}

    //https://www.geeksforgeeks.org/serialize-deserialize-n-ary-tree/