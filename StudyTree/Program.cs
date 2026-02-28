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

        Console.WriteLine("\nInOrderTraversal: ");
        tree.InOrderTraversal();

        Console.WriteLine("\nPreOrderTraversal: ");
        tree.PreOrderTraversal();
    }
}