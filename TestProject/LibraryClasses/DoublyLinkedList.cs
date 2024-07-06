namespace LibraryClasses
{
    public class DoublyLinkedList : LinkedList
    {
        class DoublyLinkedListNode : LinkedListNode
        {
            public DoublyLinkedListNode? Prev { get; set; }

            public DoublyLinkedListNode(object value) : base(value)
            {
                Prev = null;
            }
        }

        public override void Add(object value)
        {
            var newNode = new DoublyLinkedListNode(value);

            if(First == null)
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                newNode.Prev = (DoublyLinkedListNode?)Last;
                Last!.Next = newNode;
                Last = newNode;
            }

            Count++;
        }

        public override void AddFirst(object value)
        {
            var newNode = new DoublyLinkedListNode(value);

            if (First == null)
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                newNode.Next = First;
                ((DoublyLinkedListNode)First).Prev = newNode;
                First = newNode;
            }

            Count++;
        }

        public override void Insert(int index, object value)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == 0)
            {
                AddFirst(value);
                return;
            }

            var newNode = new DoublyLinkedListNode(value);
            var current = (DoublyLinkedListNode?)First;
            var currentIndex = 0;

            while (currentIndex < index - 1)
            {
                current = (DoublyLinkedListNode?)current?.Next;
                currentIndex++;

                if (current == null)
                    throw new IndexOutOfRangeException("Index is out of range.");
            }

            newNode.Next = current?.Next;
            newNode.Prev = current;

            if (current?.Next != null)
                ((DoublyLinkedListNode)current.Next).Prev = newNode;

            current!.Next = newNode;

            if (newNode.Next == null)
                Last = newNode;

            Count++;
        }

        public void Remove(object value)
        {
            if (First == null)
                throw new InvalidOperationException("List is empty");

            DoublyLinkedListNode ?previous = null;
            var current = First;

            while (current != null)
            {
                if(current.Value.Equals(value))
                {
                    if(previous == null)
                    {
                        First = (DoublyLinkedListNode?)current.Next;

                        if (First != null)
                            ((DoublyLinkedListNode)First).Prev = null;
                        else
                            Last = null!;
                    }
                    else
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            Last = previous;
                        else
                            ((DoublyLinkedListNode)current.Next).Prev = previous;
                    }

                    Count--;
                    return;
                }

                previous = (DoublyLinkedListNode)current;
                current = (DoublyLinkedListNode?)current.Next;
                
            }
        }

        public void RemoveFirst()
        {
            if (First == null)
                throw new InvalidOperationException("List is empty");

            First = (DoublyLinkedListNode?)First.Next;
            if (First != null)
                ((DoublyLinkedListNode)First).Prev = null;
            else
                Last = null;

            Count--;
        }

        public void RemoveLast()
        {
            if (Last == null)
                throw new InvalidOperationException("List is empty");

            Last = ((DoublyLinkedListNode)Last).Prev;
            if (Last != null)
                Last.Next = null;
            else
                First = null;

            Count--;
        }
    }
}
