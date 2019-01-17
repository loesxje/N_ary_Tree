using System;
using System.Collections.Generic;

namespace N_ary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrange
            var NAryTree = new Tree<string>();
            var root = new TreeNode<string>("Oma", null, new List<TreeNode<string>>());
            var child1 = NAryTree.AddChildNode(root, "Mama");
            var parent1 = NAryTree.GrowUp(child1);
            var child2 = NAryTree.AddChildNode(parent1, "Ik");
            var child3 = NAryTree.AddChildNode(parent1, "Zus");
            // Act
            var sum = NAryTree.SumToLeafs();
        }
    }
}
