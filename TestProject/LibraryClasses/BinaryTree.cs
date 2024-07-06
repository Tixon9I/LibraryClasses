namespace LibraryClasses
{
    class TreeNode
    {
        public int Value {  get; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree
    {
        private TreeNode? Root { get; set; }
        public int Count { get; private set; }

        public BinaryTree()
        {
            Root = null;
            Count = 0;
        }

        public void Add(int value)
        {
            if (Root == null)
                Root = new TreeNode(value);
            else
                RecursiveAdd(Root, value);

            Count++;
        }

        private void RecursiveAdd(TreeNode node, int value)
        {
            if(value < node.Value)
                if(node.Left == null)
                    node.Left = new TreeNode(value);
                else
                    RecursiveAdd(node.Left, value);
            else
                if(node.Right == null)
                    node.Right = new TreeNode(value);
                else
                    RecursiveAdd(node.Right, value);
        }

        public bool Contains(int value)
        {
            return Contains(Root!, value);
        }

        private bool Contains(TreeNode node, int value)
        {
            if(node == null)
                return false;
            
            if(node.Value.Equals(value))
                return true;
            else if(value < node.Value)
                return Contains(node.Left!, value);
            else
                return Contains(node.Right!, value);
        }

        public void Clear()
        {
            Root = null!;
            Count = 0;
        }

        public object[] DFS()
        {
            var result = new List();

            if (Root == null)
                return result.ToArray();

            DFSRecursive(Root, result);

            return result.ToArray();
        }

        private void DFSRecursive(TreeNode node, List result)
        {
            if (node == null)
                return;

            result.Add(node.Value);

            DFSRecursive(node.Left!, result);
            DFSRecursive(node.Right!, result);
        }

        public int[] ToArray()
        {
            var objects = new int[Count];
            return BFS(Root!, objects);
        }

        private int[] BFS(TreeNode root, int[] array)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root), "The root node cannot be null.");

            var queue = new Queue();

            queue.Enqueue(root);

            var index = 0;

            while(queue.Count > 0)
            {
                var node = (TreeNode)queue.Dequeue();
                array[index++] = node.Value;

                if(node.Left != null)
                    queue.Enqueue(node.Left);
                if(node.Right != null)
                    queue.Enqueue(node.Right);
            }

            return array;
        }
    }
}
