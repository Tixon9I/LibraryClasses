using LibraryClasses.Interfaces;
using System.Collections;

namespace LibraryClasses
{
    class TreeNode<T>
    {
        public T Value { get; }
        public TreeNode<T>? Left { get; set; }
        public TreeNode<T>? Right { get; set; }

        public TreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree<T> : IBinaryTree<T> where T: IComparable<T>
    {
        private TreeNode<T>? _root;
        public T? Root => _root!.Value;
        public int Count { get; private set; }

        public BinaryTree()
        {
            _root = null;
            Count = 0;
        }

        
        public void Add(T value)
        {
            if (_root == null)
                _root = new TreeNode<T>(value);
            else
                RecursiveAdd(_root, value);

            Count++;
        }

        void ICollections<T>.Add(T item)
        {
            Add(item);
        }

        private void RecursiveAdd(TreeNode<T> node, T value)
        {
            if(value.CompareTo(node.Value) < 0)
                if(node.Left == null)
                    node.Left = new TreeNode<T>(value);
                else
                    RecursiveAdd(node.Left, value);
            else
                if(node.Right == null)
                    node.Right = new TreeNode<T>(value);
                else
                    RecursiveAdd(node.Right, value);
        }

        public bool Contains(T value)
        {
            return Contains(_root!, value);
        }

        bool ICollections<T>.Contains(T item)
        {
            if (item is T value)
            {
                return Contains(value);
            }
            else
                throw new ArgumentException("Item is not an integer.");
        }

        private bool Contains(TreeNode<T> node, T value)
        {
            if(node == null)
                return false;
            
            if(node.Value.Equals(value))
                return true;
            else if(value.CompareTo(node.Value) < 0)
                return Contains(node.Left!, value);
            else
                return Contains(node.Right!, value);
        }

        public void Clear()
        {
            _root = null!;
            Count = 0;
        }

        public T[] DFS()
        {
            var result = new List<T>();

            if (_root == null)
                return result.ToArray();

            DFSRecursive(_root!, result);

            return result.ToArray();
        }

        private void DFSRecursive(TreeNode<T> node, List<T> result)
        {
            if (node == null)
                return;

            result.Add(node.Value);

            DFSRecursive(node.Left!, result);
            DFSRecursive(node.Right!, result);
        }

        public T[] ToArray()
        {
            var objects = new T[Count];
            return BFS(_root!, objects);
        }

        private T[] BFS(TreeNode<T> root, T[] array)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root), "The root node cannot be null.");

            var queue = new Queue<TreeNode<T>>();

            queue.Enqueue(root);

            var index = 0;

            while(queue.Count > 0)
            {
                var node = queue.Dequeue();
                array[index++] = node.Value;

                if(node.Left != null)
                    queue.Enqueue(node.Left);
                if(node.Right != null)
                    queue.Enqueue(node.Right);
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var queue = new Queue<TreeNode<T>>();

            queue.Enqueue(_root!);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                yield return node.Value;
                
                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
