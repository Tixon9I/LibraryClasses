using LibraryClasses.Interfaces;

namespace LibraryClasses
{
    public class LinkedList : ILinkedList
    {
        protected class LinkedListNode
        {
            public object Value { get; }
            public LinkedListNode? Next { get; set; }

            public LinkedListNode(object value)
            {
                Value = value;
                Next = null;
            }
        }

        protected LinkedListNode? First { get; set; }

        protected LinkedListNode? Last { get; set; }

        object? ILinkedList.First => First;
        object? ILinkedList.Last => Last;


        public int Count { get; protected set; }

        public LinkedList()
        {
            First = null;
            Last = null;
            Count = 0;
        }

        protected virtual LinkedListNode CreateNode(object value, LinkedListNode? next = null, LinkedListNode? prev = null)
        {
            return new LinkedListNode(value) { Next = next};
        }

        protected virtual void UpdateNode(LinkedListNode node, LinkedListNode? next = null, LinkedListNode? prev = null)
        {
            prev!.Next = node;
        }

        public void Add(object value)
        {
            var newNode = CreateNode(value);

            if(First == null)
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                UpdateNode(newNode, next: null, prev: Last);

                Last = newNode;
            }

            Count++;
        }

        public void AddFirst(object value)
        {
            var newNode = CreateNode(value);

            if (First == null)
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                UpdateNode(First, next: null, newNode);
                First = newNode;
            }

            Count++;
        }

        protected virtual void InsertionNode(LinkedListNode newNode, int index, int currentIndex = 0)
        {
            var current = First;

            while (currentIndex < index - 1)
            {
                current = current!.Next;
                currentIndex++;

                if (current == null)
                    throw new IndexOutOfRangeException("Index is out of range.");
            }

            newNode.Next = current?.Next;
            current!.Next = newNode;
        }

        public virtual void Insert(int index, object value)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == 0)
            {
                AddFirst(value); 
                return;
            }
                
            var newNode = CreateNode(value);

            InsertionNode(newNode, index);

            Count++;
        }

        public bool Contains(object value)
        {
            if (First == null)
                return false;
            else
            {
                if(First.Value.Equals(value) || Last!.Value.Equals(value))
                    return true;
                else
                {
                    var currentNode = First.Next;

                    while (currentNode != null)
                    {
                        if(currentNode.Value.Equals(value))
                            return true;
                        currentNode = currentNode.Next;
                    }
                }
            }

            return false;
        }

        protected virtual bool RemoveNode(object value)
        {
            LinkedListNode? prevNode = null;
            var current = First;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (First!.Value.Equals(value))
                    {
                        First = current.Next;

                        if (First == null)
                            Last = null;
                    }
                    else
                    {
                        prevNode!.Next = current.Next;

                        if (current.Next == null)
                            Last = prevNode;
                    }

                    Count--;
                    return true;
                }

                prevNode = current;
                current = current.Next;
            }

            return false;
        }

        public bool Remove(object value)
        {
            if (First == null)
                throw new InvalidOperationException("List is empty");

            return RemoveNode(value);
        }

        public void CopyTo(object[] newArray, int arrayIndex)
        {
            if (newArray == null)
                throw new ArgumentNullException(nameof(newArray), "The target array cannot be null.");


            if (arrayIndex < 0 || arrayIndex >= newArray.Length)
                throw new ArgumentOutOfRangeException(nameof(newArray), "The array index is out of range.");


            if (newArray.Length - arrayIndex < Count)
                throw new ArgumentException("The target array does not have enough space to copy all elements.");

            var current = First;

            while(current != null)
            {
                newArray[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public object[] ToArray()
        {
            var objects = new object[0];

            if(First == null)
                return objects;

            objects = new object[Count];
            var currentNode = First;
            var index = 0; 
            while (currentNode != null)
            {
                objects[index++] = currentNode.Value;
                currentNode = currentNode.Next;
            }

            return objects;
        }

        public void Clear()
        {
            First = null; 
            Last = null;
            Count = 0;
        }
    }
}
