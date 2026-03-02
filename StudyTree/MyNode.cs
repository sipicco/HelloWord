namespace TreeStudy
{
    public class MyNode
    {
        public int _data;

        public MyNode _rightNode;

        public MyNode _leftNode;

        public MyNode(int nodeValue)
        {
            _data = nodeValue;
        }

        internal void InsertByNode(int value)
        {
            // if new value is >= current node value
            // -> insert it to the right of current node
            if (value >= _data)
            {
                // Current node already has right child?
                if (_rightNode is null) // No -> create it and assign value
                {
                    _rightNode = new MyNode(value);
                }
                else // Yes -> recursively call insertByNode on it
                {
                    // This will check again if inserting left or right again
                    // in the next level of the tree
                    _rightNode.InsertByNode(value);
                }

            }
            else // if new value is smaller than current -> insert it left
            {
                if (_leftNode is null)
                {
                    _leftNode = new MyNode(value);
                }
                else
                {
                    _leftNode.InsertByNode(value);
                }
            }
        }

        internal void InOrderTraversal()
        {
            if (_leftNode != null)
            {
                _leftNode.InOrderTraversal();
            }

            Console.Write(_data + ", ");

            if (_rightNode != null)
            {
                _rightNode.InOrderTraversal();
            }
        }

        internal void ReverseOrderTraversal()
        {
            if (_rightNode != null)
            {
                _rightNode.ReverseOrderTraversal();
            }

            Console.Write(_data + ", ");

            if (_leftNode != null)
            {
                _leftNode.ReverseOrderTraversal();
            }
        }

        internal void PreOrderTraversal()
        {
            Console.Write(_data + ", ");

            if (_leftNode != null)
            {
                _leftNode.PreOrderTraversal();
            }

            if (_rightNode != null)
            {
                _rightNode.PreOrderTraversal();
            }
        }

        internal void PostOrderTraversal()
        {
            if (_leftNode != null)
            {
                _leftNode.PostOrderTraversal();
            }

            if (_rightNode != null)
            {
                _rightNode.PostOrderTraversal();
            }

            Console.Write(_data + ", ");
        }

        internal MyNode? Find(int target)
        {
            MyNode currentNode = this;

            while (currentNode != null)
            {
                if (target == currentNode._data)
                {
                    Console.WriteLine("Found: " + currentNode._data);
                    return currentNode;
                }
                else if (target < currentNode._data)
                {
                    currentNode = currentNode._leftNode;
                }
                else
                {
                    currentNode = currentNode._rightNode;
                }
            }
            // target not found
            Console.WriteLine(target + " not found!");
            return null;
        }

        internal void FindRecursive(int target)
        {
            if (target == _data)
            {
                Console.WriteLine("Found: " + _data);
                return;
            }
            else if (target < _data && _leftNode != null)
            {
                _leftNode.FindRecursive(target);
            }
            else if (target > _data && _rightNode != null)
            {
                _rightNode.FindRecursive(target);
            }
            else
            {
                Console.WriteLine(target + " not found!");
                return;
            }
        }

        internal void PrintLevelOrder()
        {
            Queue<MyNode> queue = new Queue<MyNode>();
            queue.Enqueue(this); // root

            while (queue.Count > 0)
            {
                int levelSize = queue.Count();
                MyNode current = queue.Dequeue();
                Console.Write(current._data + ", ");

                if (current._leftNode != null)
                    queue.Enqueue(current._leftNode);

                if (current._rightNode != null)
                    queue.Enqueue(current._rightNode);
            }
        }
    }
}
