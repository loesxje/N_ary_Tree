using System;
using System.Collections.Generic;
using System.Text;

namespace N_ary_Tree
{
    public class Tree<T>
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
        public List<T> TraverseNodes()
        {
            List<T> traversednodes = new List<T>();
            for (int i = 1; i <= maxOrder; i++)
            {
                foreach (TreeNode<T> node in AllChildren)
                    if (node.Order == i)
                        traversednodes.Add(node.Data);
            }
            return traversednodes;
        }

        // returns only all summed Node values on the path to each leaf node
        public List<T> SumToLeafs()
        {
            List<TreeNode<T>> leafnodes = new List<TreeNode<T>>();
            foreach (TreeNode<T> child in AllChildren)
                if (child.Children.Count == 0)
                    leafnodes.Add(child);

            List<T> sumtoleafs_list = new List<T>();
            foreach (TreeNode<T> node in leafnodes)
            {
                dynamic sum = null;
                var tempnode = node;
                for (int i = 0; i < maxOrder; i++)
                {
                    sum += tempnode.Data;
                    tempnode = tempnode.Parent;
                }
                sumtoleafs_list.Add(sum);
            }
            return sumtoleafs_list;
        }
    }
}
