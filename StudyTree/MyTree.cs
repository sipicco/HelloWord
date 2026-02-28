
namespace TreeStudy
{
    // Nice YT tutorial: https://www.youtube.com/watch?v=pN1RWeX47tg

    // --- BST -> Binary Search Tree
    // Every node onli has reference to 2 other nodes
    // left node < parent node < right node
    public class MyTree
    {
        public MyNode _root;

        public void InsertInTree(int value)
        {
            if (_root is not null) // Insert according to current tree structure
            {
                _root.InsertByNode(value);
            }
            else // No nodes yet in the tree -> create root
            {
                _root = new MyNode(value);
            }
        }

        // traverse tree from left to right
        // root > recursively in left child of every node > bottom left leaf >
        // print it > up to calling parent > print > right child > start over
        // returns number in ascending order
        public void InOrderTraversal()
        {
            if (_root != null)
            {
                _root.InOrderTraversalByNode();
            }
        }

        internal void PreOrderTraversal()
        {
            if (_root != null)
            {
                _root.PreOrderTraversal();
            }
        }
    }
}
