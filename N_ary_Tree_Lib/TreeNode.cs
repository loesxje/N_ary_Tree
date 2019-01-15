using System;
using System.Collections.Generic;
using System.Text;

namespace N_ary_Tree
{
    public class TreeNode<T>   
    {
        public T Data { get; set; }
        public TreeNode<T> Parent { get; set; }
        public List<TreeNode<T>> Children { get; set; }
        public int Order { get; set; }

        // Constructor
        public TreeNode(T data, TreeNode<T> parent, List<TreeNode<T>> children)
        {
            this.Data = data;
            this.Children = children;
            this.Parent = parent;
            this.Order = 0;
        }
    }
}
//https://github.com/shawnjobseeker/N-Ary-Tree/blob/master/ConsoleApp2/Node.cs