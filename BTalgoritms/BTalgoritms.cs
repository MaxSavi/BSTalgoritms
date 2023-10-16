using System;

class Program
{
    static void Main(string[] args)
    {
        BST b = new BST();
        int[] anArrayNodes = {
                17, 6, 5, 20, 19, 18, 11, 14, 12, 13, 2, 4, 10
        };

        foreach (int nodeValue in anArrayNodes)
        {
            b.Insert(nodeValue);
        }
        b.Visualize();
        Console.Write("In-order: ");
        b.InOrderTraversal();
        Console.Write("Pre-order: ");
        b.PreOrderTraversal();
    }
}

class Node
{
    public int Key;
    public Node Left;
    public Node Right;

    public Node(int key)
    {
        Key = key;
        Left = null;
        Right = null;
    }
}

class BST
{
    public Node root;

    public void Insert(int key)
    {
        root = InsertHelper(root, key);
    }

    public Node InsertHelper(Node currentNode, int key)
    {
        if (currentNode == null)
        {
            return new Node(key);
        }

        if (key < currentNode.Key)
        {
            currentNode.Left = InsertHelper(currentNode.Left, key);
        }
        else if (key > currentNode.Key)
        {
            currentNode.Right = InsertHelper(currentNode.Right, key);
        }

        return currentNode;
    }

    public void Visualize()
    {
        VisualizeHelper(root, " ", true);
    }

    public void VisualizeHelper(Node node, string prefix, bool isLeft)
    {
        if (node == null)
        {
            return;
        }

        string nodeStr = node.Key.ToString();
        string line = prefix + (isLeft ? "├── " : "└── ");
        Console.WriteLine(line + nodeStr);

        string childPrefix = prefix + (isLeft ? "│   " : "    ");
        VisualizeHelper(node.Left, childPrefix, true);
        VisualizeHelper(node.Right, childPrefix, false);
    }

    public void InOrderTraversal()
    {
        InOrderTraversalHelper(root);
        Console.WriteLine();
    }

    public void InOrderTraversalHelper(Node node)
    {
        if (node != null)
        {
            InOrderTraversalHelper(node.Left);
            Console.Write(node.Key + " ");
            InOrderTraversalHelper(node.Right);
        }
    }

    public void PreOrderTraversal()
    {
        PreOrderTraversalHelper(root);
        Console.WriteLine();
    }

    public void PreOrderTraversalHelper(Node node)
    {
        if (node != null)
        {
            Console.Write(node.Key + " ");
            PreOrderTraversalHelper(node.Left);
            PreOrderTraversalHelper(node.Right);
        }
    }
}
