namespace TreeStudy
{
    public class MyNode
    {
        public int Data;

        public MyNode _rightNode;

        public MyNode _leftNode;

        public MyNode(int nodeValue)
        {
            Data = nodeValue;
        }


        internal void InsertByNode(int value)
        {
            // if new value is >= current node value
            // -> insert it to the right of current node
            if (value >= Data)
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
    }
}
