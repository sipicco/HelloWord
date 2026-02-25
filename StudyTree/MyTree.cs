namespace TreeStudy
{
    // Nice YT tutorial: https://www.youtube.com/watch?v=pN1RWeX47tg

    // --- BST -> Binary Search Tree
    // Every node onli has reference to 2 other nodes
    // left node < parent node < right node
    public class MyTree
    {
        public MyNode Root;

        public void InsertInTree(int value)
        {
            if (Root is not null) // Insert according to current tree structure
            {
                Root.InsertByNode(value);
            }
            else // No nodes yet in the tree -> create root
            {
                Root = new MyNode(value);
            }
        }
    }
}
