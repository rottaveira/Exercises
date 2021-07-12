using System;

namespace Exercises
{
    public class Node
    {
        public int Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public Node(int value, Node left, Node right)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }

    /// <summary>
    /// Obs, uma arvore binária é uma arvore ordenada
    /// onde os maiores valores estão a direita e os
    /// menores a esquerda.
    /// </summary>
    public class BinarySearchTree
    {
        public static bool Contains(Node root, int value)
        {
            /*busca cega - não é a melhor opção*/
            /*
                if (root == null) return false;
                if (root.Value == value)
                    return true;
                else
                    return Contains(root.Left, value) || Contains(root.Right, value);
            */

            /*busca ordenada*/
            var current = root;
            while (true)
            {
                if (current == null) return false;
                if (current.Value == value) return true;
                else if (current.Value > value) current = current.Left;
                else current = current.Right;
            }

        }

        public static void Run()
        {
            Node n1 = new Node(1, null, null);
            Node n3 = new Node(3, null, null);
            Node n2 = new Node(2, n1, n3);

            Console.WriteLine(Contains(n2, 3));
        }
    }
}