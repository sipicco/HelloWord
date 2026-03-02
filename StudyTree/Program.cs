using TreeStudy;

internal class Program
{
    private static void Main(string[] args)
    {
        var tree = new MyTree();

        tree.InsertInTree(75);
        tree.InsertInTree(57);
        tree.InsertInTree(90);
        tree.InsertInTree(32);
        tree.InsertInTree(7);
        tree.InsertInTree(44);
        tree.InsertInTree(60);
        tree.InsertInTree(86);
        tree.InsertInTree(93);
        tree.InsertInTree(99);



        Console.WriteLine("\n\nInOrderTraversal: ");
        tree.InOrderTraversal();

        Console.WriteLine("\n\nReverseOrderTraversal: ");
        tree.ReverseOrderTraversal();

        Console.WriteLine("\n\nPreOrderTraversal: ");
        tree.PreOrderTraversal();

        Console.WriteLine("\n\nPostOrderTraversal: ");
        tree.PostOrderTraversal();

        Console.WriteLine("\n\nFind: ");
        tree.Find(99);

        Console.WriteLine("\n\nFindRecursively: ");
        tree.FindRecursive(59);

        Console.WriteLine("\n\nDelete a node with 1 child (93)");
        tree.Remove(93);

        Console.WriteLine("\n\nDelete a node with 2 children (75)");
        tree.Remove(75);

        Console.WriteLine("\n\nPrintLevelOrder");
        tree.PrintLevelOrder();
    }
}