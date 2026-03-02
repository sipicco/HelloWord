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
                _root.InOrderTraversal();
            }
        }


        internal void PreOrderTraversal()
        {
            if (_root != null)
            {
                _root.PreOrderTraversal();
            }
        }

        // root > left > right
        internal void ReverseOrderTraversal()
        {
            if (_root != null)
            {
                _root.ReverseOrderTraversal();
            }
        }

        // left > right > parent
        internal void PostOrderTraversal()
        {
            if (_root != null)
            {
                _root.PostOrderTraversal();
            }
        }

        // binary search - iterates with while loop, updating the current node var 
        internal void Find(int target)
        {
            if (_root != null)
            {
                _root.Find(target);
            }
        }

        // binary search - recursively calls itself on the next node
        internal void FindRecursive(int target)
        {
            if (_root != null)
            {
                _root.FindRecursive(target);
            }
        }

        internal void Remove(int target)
        {
            // --- SET PARAMETERS
            MyNode current = _root;
            MyNode parent = _root;
            bool isLeftChild = false;

            if (current == null)
            {
                return; // Empty tree -> nothing to remove;
            }

            // --- FIND THE NODE
            while (current != null && current._data != target)
            {
                parent = current;

                if (target < current._data)
                {
                    current = current._leftNode;
                    isLeftChild = true;
                }
                else
                {
                    current = current._rightNode;
                    isLeftChild = false;
                }
            }

            // --- NODE NOT FOUND -> RETURN
            if (current == null)
            {
                return;
            }

            // --- DELETE LEAF NODE
            // Found a leaf node -> bottom level, no children
            if (current._rightNode == null && current._leftNode == null)
            {
                if (current == _root)
                {
                    // root -> no parents -> just set it to null
                    _root = null;
                }
                else
                {
                    // Remove reference to right or left child of the parent
                    // depending on wether the found node is right of left child
                    if (isLeftChild)
                    {
                        parent._leftNode = null;
                    }
                    else
                    {
                        parent._rightNode = null;
                    }
                }
            }
            else // --- DELETE NON-LEAF NODE -> found node has ONE CHILD
            {
                // Connect parent of found node to child of found node             
                if (current._leftNode != null) // Found node has the left child
                {
                    // found node is root && only has left child
                    // -> left child is new root
                    if (current == _root)
                    {
                        _root = current._leftNode;
                    }

                    if (isLeftChild)
                    {
                        parent._leftNode = current._leftNode;
                    }
                    else
                    {
                        parent._rightNode = current._leftNode;
                    }
                }
                else // Found node has the right child
                {
                    // found node is root && only has right child
                    // -> left child is new root
                    if (current == _root)
                    {
                        _root = current._rightNode;
                    }

                    if (isLeftChild)
                    {
                        parent._leftNode = current._rightNode!;
                    }
                    else
                    {
                        parent._rightNode = current._rightNode!;
                    }
                }
            }
        }

        internal void PrintLevelOrder()
        {
            if (_root != null)
            {
                _root.PrintLevelOrder();
            }
        }
    }
}
