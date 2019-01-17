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
            var root = new TreeNode<string>("Oma", null, new List<TreeNode<string>>());
            // Act
            var child1 = NAryTree.AddChildNode(root, "Mama");
            var child2 = NAryTree.AddChildNode(child1, "Ik");
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(NAryTree.AllChildren.Count == 2);
                Assert.Contains(child1, NAryTree.AllChildren);
                Assert.Contains(child2, NAryTree.AllChildren);
                Assert.AreEqual(child2.Parent, child1);
                Assert.That(NAryTree.Count == 2);
                Assert.That(NAryTree.LeafCount == 1);
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
            var child2 = NAryTree.AddChildNode(child1, 2);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(NAryTree.AllChildren.Count == 2);
                Assert.Contains(child1, NAryTree.AllChildren);
                Assert.Contains(child2, NAryTree.AllChildren);
                Assert.AreEqual(child2.Parent, child1);
                Assert.That(NAryTree.Count == 2);
                Assert.That(NAryTree.LeafCount == 1);
            });
        }

        [TestCase]
        public void Test_Tree_removeChildNode()
        {
            // Arrange
            var NAryTree = new Tree<int>();
            var root = new TreeNode<int>(3, null, new List<TreeNode<int>>());
            // Act
            var child1 = NAryTree.AddChildNode(root, 3);
            NAryTree.removeNode(child1);
            // Assert
            Assert.That(NAryTree.AllChildren.Count == 0);
        }

        [TestCase]
        public void Test_Tree_TraverseNodes()
        {
            // Arrange
            var NAryTree = new Tree<int>();
            var root = new TreeNode<int>(3, null, new List<TreeNode<int>>());
            var child1 = NAryTree.AddChildNode(root, 3);
            var child2 = NAryTree.AddChildNode(child1, 2);
            // Act
            List<int> traversed = NAryTree.TraverseNodes();
            // Assert
            int[] validation = { 2, 3 };
            Assert.That(traversed, Is.EquivalentTo(validation));
            // weet niet goed wat ik nog meer moet testen
        }

        [TestCase]
        public void Test_Tree_SumToLeafs_int()
        {
            // Arrange
            var NAryTree = new Tree<int>();
            var root = new TreeNode<int>(3, null, new List<TreeNode<int>>());
            var child1 = NAryTree.AddChildNode(root, 3);
            var child2 = NAryTree.AddChildNode(child1, 2);
            var child3 = NAryTree.AddChildNode(child1, 1);
            // Act
            var sum = NAryTree.SumToLeafs();
            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(sum.Count, NAryTree.LeafCount);
                Assert.Contains(4, sum);
                Assert.Contains(5, sum);
            });
        }

        [TestCase]
        public void Test_Tree_SumToLeafs_string()
        {
            // Arrange
            var NAryTree = new Tree<string>();
            var root = new TreeNode<string>("Oma", null, new List<TreeNode<string>>());
            var child1 = NAryTree.AddChildNode(root, "Mama");
            var child2 = NAryTree.AddChildNode(child1, "Ik");
            var child3 = NAryTree.AddChildNode(child1, "Zus");
            // Act
            var sum = NAryTree.SumToLeafs();
            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(sum.Count, NAryTree.LeafCount);
                Assert.Contains("IkMama", sum);
                Assert.Contains("ZusMama", sum);
            });
        }
    }
}
