using LibraryClasses.Interfaces;

namespace LibraryClasses
{
    public class DoublyLinkedList : LinkedList, ILinkedList
    {
        class DoublyLinkedListNode : LinkedListNode
        {
            public DoublyLinkedListNode? Prev { get; set; }

            public DoublyLinkedListNode(object value) : base(value)
            {
                Prev = null;
            }
        }

        protected override LinkedListNode CreateNode(object value, LinkedListNode? next = null, LinkedListNode? prev = null)
        {
            return new DoublyLinkedListNode(value) 
            { 
                Next = next, 
                Prev = ((DoublyLinkedListNode?)prev)?.Prev 
            };
        }

        protected override void UpdateNode(LinkedListNode node, LinkedListNode? next = null, LinkedListNode? prev = null)
        {
            base.UpdateNode(node, next, prev);
            ((DoublyLinkedListNode)node).Prev = (DoublyLinkedListNode?)prev;
        }

        protected override void InsertionNode(LinkedListNode newNode, int index, int currentIndex = 0)
        {
            var current = (DoublyLinkedListNode?)First;

            while (currentIndex < index - 1)
            {
                current = (DoublyLinkedListNode?)current?.Next;
                currentIndex++;

                if (current == null)
                    throw new IndexOutOfRangeException("Index is out of range.");
            }

            newNode.Next = current?.Next;
            ((DoublyLinkedListNode)newNode).Prev = current;

            if (current?.Next != null)
                ((DoublyLinkedListNode)current.Next).Prev = (DoublyLinkedListNode)newNode;

            current!.Next = newNode;

            if (newNode.Next == null)
                Last = newNode;
        }

        protected override bool RemoveNode(object value)
        {
            DoublyLinkedListNode? previous = null;
            var current = First;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previous == null)
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
                    return true;
                }

                previous = (DoublyLinkedListNode)current;
                current = (DoublyLinkedListNode?)current.Next;
            }

            return false;
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
