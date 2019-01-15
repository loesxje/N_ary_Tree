using System;
using System.Collections.Generic;
using System.Text;

namespace N_ary_Tree
{
    class Tree<T>
    {
        public int Count { get; set; } // aantal nodes in de tree
        public int LeafCount { get; set; } // aantal leaf nodes in de tree
        public List<TreeNode<T>> AllChildren = new List<TreeNode<T>>();
        public int maxOrder { get; set; }

        // Constructor
        public Tree()
        {
            Count = 0;
            LeafCount = 0;
            maxOrder = 0;
        }


        // adds new TreeNode with supplied value to Tree below node parentNode
        public TreeNode<T> AddChildNode(TreeNode<T> parentNode, T value)
        {
            TreeNode<T> childrenNode = new TreeNode<T>(value, parentNode, new List<TreeNode<T>>());
            AllChildren.Add(childrenNode);
            parentNode.Children.Add(childrenNode);

            LeafCount++;
            Count++;

            childrenNode.Order = 1 + childrenNode.Parent.Order;
            if (maxOrder < childrenNode.Order)
                maxOrder = childrenNode.Order;

            return childrenNode;
        }

        public TreeNode<T> GrowUp(TreeNode<T> childNode)
        {
            TreeNode<T> parentNode = childNode;
            LeafCount--;

            return parentNode;
        }

        // remove specific TreeNode from Tree
        public void removeNode(TreeNode<T> node)
        {
            this.AllChildren.Remove(node);
            var parentNode = node.Parent;
            parentNode.Children.Remove(node);

            Count--;
            if (node.Children.Count == 0)
                LeafCount--;
            else if (node.Children.Count != 0)
            {
                for (int i = node.Children.Count-1; i >= 0; i--)
                {
                    removeNode(node.Children[i]);
                }
            }
        }

        // returns all node values
        public void TraverseNodes()
        {
            Console.WriteLine("Traverse nodes of N-ary Tree in level order traversal:");
            for (int i = 1; i <= maxOrder; i++)
            {
                foreach(TreeNode<T> node in AllChildren)
                    if (node.Order == i)
                        Console.Write($"{node.Data} ");
                Console.WriteLine("\n");
            }
            Console.ReadLine();

            //  THIS CODE WAS TRYING TO VISUALISE A REAL N-ARY TREE, DOESN'T WORK THOUGH.
            //var n = 0;
            //Console.WriteLine(this.AllChildren[n].Data);
            //while (n < this.AllChildren.Count)
            //    if (this.AllChildren[n].Children != null)
            //    {
            //        foreach (var node in this.AllChildren[n].Parent.Children)
            //        {
            //            for (int i = 0; i < this.AllChildren[n].Parent.Children.Count; i++)
            //                if (node == this.AllChildren[n].Parent.Children[i])
            //                    Console.Write(new string('\t', i));
            //            if (this.AllChildren[n].Parent.Children[0] == node)
            //                Console.Write("\n");
            //        }
            //        this.AllChildren[n].Children.ForEach(i => Console.Write("{0}\t", i.Data));
            //        n++;
            //    }
        }

        // returns only all summed Node values on the path to each leaf node
        public void SumToLeafs()
        {
            List<TreeNode<T>> leafnodes = new List<TreeNode<T>>();
            foreach (TreeNode<T> child in AllChildren)
                if (child.Children.Count == 0)
                    leafnodes.Add(child);

            Console.WriteLine($"Return the sum from {leafnodes.Count} leafs to the root:");

            foreach (TreeNode<T> node in leafnodes)
            {
                dynamic sum = 0;
                var tempnode = node;
                for (int i = 0; i < maxOrder; i++)
                {
                    sum += tempnode.Data;
                    tempnode = tempnode.Parent;
                }
                Console.Write("{0}\t", sum);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
