using System; 

namespace Exercises
{ 
    public class Node
    {
        public class TreeNode
        {
            public int data { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }

        }

        public static TreeNode newNode(int data)
        {
            TreeNode node = new TreeNode();
            node.data = data;
            node.left = node.right = null;
            return (node);
        }

        public static int TreeSum(TreeNode root)
        {
            if (root == null) return 0;
            if (root.data == 0) return 0;
            return (root.data + TreeSum(root.left) + TreeSum(root.right));
        }


        public static void Run()
        {
            /* Objetivo é garantir que todos os nós sejam somados
             *  Exemplo Árvore = 36
             *         1
             *       /   \
             *      2     3
             *     / \   / \
             *    4   5 6   7
             *           \
             *            8
             */

            TreeNode root = newNode(1);
            root.left = newNode(2);
            root.right = newNode(3);
            root.left.left = newNode(4);
            root.left.right = newNode(5);
            root.right.left = newNode(6);
            root.right.right = newNode(7);
            root.right.left.right = newNode(8); 

            int sum = TreeSum(root);
            Console.WriteLine("Sum of all the elements is: " + sum); //should be 36
        }
    }
}

