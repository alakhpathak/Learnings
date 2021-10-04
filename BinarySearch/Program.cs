using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class Node
    {
        public char Info { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    public class BinaryTree
    {
        public Node Root { get; set; }
        public void Insert(char ch)
        {
            Node temp = Root;
            if (temp == null)
            {
                var firstNode = new Node() { Info = ch };
                Root = firstNode;
                return;
            }
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(temp);

            // Do level order traversal until we find
            // an empty place.
            while (q.Count != 0)
            {
                temp = q.Peek();
                q.Dequeue();

                if (temp.Left == null)
                {
                    temp.Left = new Node() { Info = ch };
                    break;
                }
                else
                    q.Enqueue(temp.Left);

                if (temp.Right == null)
                {
                    temp.Right = new Node() { Info = ch };
                    break;
                }
                else
                    q.Enqueue(temp.Right);
            }
        }

        public void PreOrder(Node root)
        {
            if(root==null)
            {
                return;
            }
            Console.WriteLine(root.Info);
            PreOrder(root.Left);

            PreOrder(root.Right);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert('a');
            bt.Insert('b');
            bt.Insert('c');
            bt.Insert('d');
            bt.Insert('e');
            bt.Insert('f');
            bt.Insert('g');
            bt.Insert('h');
            bt.Insert('i');
            bt.Insert('j');
            bt.Insert('k');
            bt.Insert('l');
            bt.Insert('m');
            bt.Insert('n');
            bt.Insert('o');

            bt.PreOrder(bt.Root);

        }
    }
}
