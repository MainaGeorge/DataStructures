namespace CommonAlgorithms
{
    public class TreeNode
    {
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
        public int Value { get; set; }

        public TreeNode(int value=0,TreeNode leftChild=null, TreeNode rightChild=null)
        {
            LeftChild = leftChild;
            RightChild = rightChild;
            Value = value;
        }
    }
}
