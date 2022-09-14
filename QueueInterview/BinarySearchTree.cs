using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpInterviewQuestion
{
    class BinarySearchTree : IBinarySearchTree
    {
        public Node Root { get; set; }

        public BinarySearchTree() { }

        public BinarySearchTree(int rootKey)
        {
            Root = new Node() { Key = rootKey };
        }
        public void InOrderTreeWalk(Node node)
        {
            if (node != null)
            {
                InOrderTreeWalk(node.Left);
                Console.WriteLine(node.Key);
                InOrderTreeWalk(node.Right);
            }
        }

        public void Insert(Node node)
        {
            Node temp = null;
            Node root = Root;
            while (root != null)
            {
                temp = root;
                if (node.Key < root.Key)
                    root = root.Left;
                else
                    root = root.Right;
            }

            node.Parent = temp;

            if (temp == null) Root = node;
            else if (node.Key < temp.Key)
                temp.Left = node;
            else temp.Right = node;

        }

        public Node MaximumTree(Node node)
        {
            if (node.Right != null)
                return MaximumTree(node.Right);
            return node;
        }

        public Node MinimumTree(Node node)
        {
            if (node.Left != null)
                return MinimumTree(node.Left);
            return node;
        }
        public Node TreeSearch(Node node, int key)
        {
            if (node == null || node.Key == key)
                return node;
            else if (node.Key < key)
                return TreeSearch(node.Right, key);
            else
                return TreeSearch(node.Left, key);

        }

        private void Transplant(Node u, Node v)
        {
            if (u.Parent == null)
                Root = v;
            else if (u == u.Parent.Left)
                u.Parent.Left = v;
            else
                u.Parent.Right = v;

            if (v != null)
                v.Parent = u.Parent;
        }
        public void TreeDelete(int key)
        {
            Node nodeToDelete = TreeSearch(Root, key);          //Searching which node to be deleted
            if (nodeToDelete.Left == null)                      //If Left child is null
                Transplant(nodeToDelete, nodeToDelete.Right);   //Then transplant its right child on it's position
            else if (nodeToDelete.Right == null)
                Transplant(nodeToDelete, nodeToDelete.Left);
            else                                                //If both children are available
            {
                Node min = MinimumTree(nodeToDelete.Right);     //Find minimum node in right subtree(successor)

                if (min.Parent != nodeToDelete)                 //if minimum is not a child of node we want to delete
                {
                    Transplant(min, min.Right);                 //Making min's right at min's place
                    min.Right = nodeToDelete.Right;
                    min.Right.Parent = min;
                }

                Transplant(nodeToDelete, min);          // If minimum is a child of node we want to delete then it will directly transplant
                min.Left = nodeToDelete.Left;           //Making min's left is node's left which we want to delete
                min.Left.Parent = min;
            }

        }
    }

}
