using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using N_ary_Tree;

namespace N_ary_Tree_test
{
    [TestFixture]
    public class TreeTest
    {
        [TestCase]
        public void Test_Tree_AddChildNode_string()
        {
            // Arrange
            var NAryTree = new Tree<string>();
            var root = new TreeNode<string>("Grootoma", null, new List<TreeNode<string>>());
            // Act
            var child1 = NAryTree.AddChildNode(root, "Oma");
            var parent1 = NAryTree.GrowUp(child1);
            var child2 = NAryTree.AddChildNode(parent1, "Mama");
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(NAryTree.AllChildren.Count == 1);
                Assert.Contains(child1, NAryTree.AllChildren);
                Assert.Contains(child2, NAryTree.AllChildren);
                Assert.Equals(child2.Parent, parent1);
            });
           
        }

        [TestCase]
        public void Test_Tree_AddChildNode_int()
        {
            // Arrange
            var NAryTree = new Tree<int>();
            var root = new TreeNode<int>(3, null, new List<TreeNode<int>>());
            // Act
            var child1 = NAryTree.AddChildNode(root, 3);
            var parent1 = NAryTree.GrowUp(child1);
            var child2 = NAryTree.AddChildNode(parent1, 2);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(NAryTree.AllChildren.Count == 1);
                Assert.Contains(child1, NAryTree.AllChildren);
                Assert.Contains(child2, NAryTree.AllChildren);
                Assert.Equals(child2.Parent, parent1);
            });
        }
    }
}
