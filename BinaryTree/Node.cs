namespace BinaryTree
{
    public class Node
    {
        public Node LeftChild { get; set; }  
        public Node RightChild { get; set; }

        public int Value { get; set; }    
        public Node(int value, Node left=null, Node right=null)
        {
            Value = value;
            LeftChild = left;
            RightChild = right;
        }
    }
}
