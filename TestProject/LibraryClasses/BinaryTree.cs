using LibraryClasses.Interfaces;

namespace LibraryClasses
{
    class TreeNode
    {
        public int Value { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree : IBinaryTree
    {
        private TreeNode? Root { get; set; }
        object? IBinaryTree.Root => Root;
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

        void ICollection.Add(object item)
        {
            if (item is int value)
            {
                Add(value);
            }
            else
                throw new ArgumentException("Item is not an integer.");
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

        bool ICollection.Contains(object item)
        {
            if (item is int value)
            {
                return Contains(value);
            }
            else
                throw new ArgumentException("Item is not an integer.");
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

        public bool Remove(int value)
        {
            bool removed = false;
            Root = RemoveNode(Root, value, ref removed);
            return removed;
        }

        private TreeNode? RemoveNode(TreeNode? node, int value, ref bool removed)
        {
            if (node == null)
                return null;

            if (value < node.Value)
            {
                node.Left = RemoveNode(node.Left, value, ref removed);
            }
            else if (value > node.Value)
            {
                node.Right = RemoveNode(node.Right, value, ref removed);
            }
            else
            {
                removed = true;

                if (node.Left == null)
                    return node.Right;

                if (node.Right == null)
                    return node.Left;

                node.Value = MinValue(node.Right);
                node.Right = RemoveNode(node.Right, node.Value, ref removed);
            }

            return node;
        }

        private int MinValue(TreeNode node)
        {
            int minValue = node.Value;
            while (node.Left != null)
            {
                minValue = node.Left.Value;
                node = node.Left;
            }
            return minValue;
        }

        bool ICollection.Remove(object item)
        {
            if (item is int value)
            {
                return Remove(value);
            }
            else
                throw new ArgumentException("Item is not an integer.");
        }

        public void CopyTo(object[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "The target array cannot be null.");


            if (arrayIndex < 0 || arrayIndex >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(array), "The array index is out of range.");


            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("The target array does not have enough space to copy all elements.");

            CopyTo(Root, array, ref arrayIndex);
        }

        private void CopyTo(TreeNode? node, object[] array, ref int arrayIndex)
        {
            if (node == null)
                return;

            CopyTo(node!.Left, array, ref arrayIndex);
            array[arrayIndex++] = node.Value;
            CopyTo(node.Right, array, ref arrayIndex);
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
