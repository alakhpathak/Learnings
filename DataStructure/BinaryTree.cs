using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Recursion
{
    public class TreeNode<T> where T : IComparable
    {
        public TreeNode(T data)
        {
            this.Data = data;
        }
        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
    }
    public class BinarySearchTree<T> where T : IComparable
    {

        public static TreeNode<T> Root;
        public void InsertInTree(T data)
        {
            if (Root == null)
            {
                Root = new TreeNode<T>(data);
                return;
            }
            else
            {
                TreeNode<T> p = Root;
                TreeNode<T> q = p;
                while (p != null)
                {
                    q = p;
                    if (p.Data.CompareTo(data) > 0)
                    {
                        p = p.Left;
                    }
                    else
                    {
                        p = p.Right;
                    }
                }

                if (q.Data.CompareTo(data) > 0)
                {
                    q.Left = new TreeNode<T>(data);
                }
                else
                {
                    q.Right = new TreeNode<T>(data);
                }

            }
        }

        public void InOrder()
        {
            InOrderUtil(Root);
        }

        private void InOrderUtil(TreeNode<T> root)
        {
            if (root == null)
            {
                return;
            }
            InOrderUtil(root.Left);
            Console.WriteLine(root.Data);
            InOrderUtil(root.Right);
        }
    }

    public class BSTDriver
    {
        public void IntTreeDemo()
        {
            var intTree = new BinarySearchTree<int>();

            intTree.InsertInTree(10);
            intTree.InsertInTree(7);
            intTree.InsertInTree(3);
            intTree.InsertInTree(15);
            intTree.InsertInTree(12);
            intTree.InsertInTree(1);

            intTree.InOrder();
        }

        public void StringTreeDemo()
        {
            var intTree = new BinarySearchTree<string>();

            intTree.InsertInTree("10");
            intTree.InsertInTree("7");
            intTree.InsertInTree("3");
            intTree.InsertInTree("15");
            intTree.InsertInTree("12");
            intTree.InsertInTree("1");

            intTree.InOrder();
        }
    }
}
