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

        // Constructor
        public Tree()
        {
            Count = 0;
            LeafCount = 0;
        }


        // adds new TreeNode with supplied value to Tree below node parentNode
        public TreeNode<T> AddChildNode(TreeNode<T> parentNode, T value)
        {
            TreeNode<T> childrenNode = new TreeNode<T>(value, parentNode, new List<TreeNode<T>>());
            AllChildren.Add(childrenNode);

            LeafCount++;
            Count++;

            parentNode.Children.Add(childrenNode);

            return childrenNode;
        }

        public TreeNode<T> GrowUp(TreeNode<T> childNode)
        {
            TreeNode<T> parentNode = childNode;
            LeafCount--;

            return parentNode;
        }

        // remove specific TreeNode from Tree
        private void removeNode(TreeNode<T> node)
        {

        }

        // returns all node values
        private void TraverseNodes()
        {

        }

        // returns only all summed Node values on the path to each leaf node
        private void SumToLeafs()
        {

        }
       
    }
}
