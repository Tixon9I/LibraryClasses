namespace LibraryClasses
{
    public class LinkedList
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
        public int Count { get; protected set; }

        public LinkedList()
        {
            First = null;
            Last = null;
            Count = 0;
        }

        public virtual void Add(object value)
        {
            var newNode = new LinkedListNode(value);

            if(First == null)
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                Last!.Next = newNode;
                Last = newNode;
            }

            Count++;
        }

        public virtual void AddFirst(object value)
        {
            var newNode = new LinkedListNode(value);

            if (First == null)
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                newNode.Next = First;
                First = newNode;
            }

            Count++;
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
                
            var newNode = new LinkedListNode(value);
            var current = First;
            var currentIndex = 0;

            while (currentIndex < index - 1)
            {
                current = current!.Next;
                currentIndex++;

                if (current == null)
                    throw new IndexOutOfRangeException("Index is out of range.");
            }

            newNode.Next = current?.Next;
            current!.Next = newNode;

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
