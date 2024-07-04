namespace LibraryClasses
{
    internal class DoublyLinkedListNode : LinkedListNode
    {
        public DoublyLinkedListNode Prev { get; set; }

        public DoublyLinkedListNode(object value) : base(value)
        {
            Prev = null!;
        }
    }

    public class DoublyLinkedList: LinkedList
    {
        internal new LinkedListNode First => base.First;
        internal new LinkedListNode Last => base.Last;
        public new int Count => base.Count;

        public override void Add(object value)
        {
            var newNode = new DoublyLinkedListNode(value);

            if(First == null)
            {
                base.First = newNode;
                base.Last = newNode;
            }
            else
            {
                newNode.Prev = (DoublyLinkedListNode)base.Last;
                base.Last.Next = newNode;
                base.Last = newNode;
            }

            base.Count++;
        }

        public override void AddFirst(object value)
        {
            var newNode = new DoublyLinkedListNode(value);

            if (First == null)
            {
                base.First = newNode;
                base.Last = newNode;
            }
            else
            {
                newNode.Next = (DoublyLinkedListNode)base.First;
                ((DoublyLinkedListNode)base.First).Prev = newNode;
                base.First = newNode;
            }

            base.Count++;
        }

        public override void Insert(int index, object value)
        {
            if (index < 0 || index > base.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == 0)
            {
                AddFirst(value);
                return;
            }

            var newNode = new DoublyLinkedListNode(value);
            var current = (DoublyLinkedListNode)base.First;
            var currentIndex = 0;

            while (currentIndex < index - 1)
            {
                current = (DoublyLinkedListNode)current.Next;
                currentIndex++;

                if (current == null)
                    throw new IndexOutOfRangeException("Index is out of range.");
            }

            newNode.Next = current.Next;
            newNode.Prev = current;

            if (current.Next != null)
                ((DoublyLinkedListNode)current.Next).Prev = newNode;

            current.Next = newNode;

            if (newNode.Next == null)
                base.Last = newNode;

            base.Count++;
        }

        public void Remove(object value)
        {
            if (First == null)
                throw new InvalidOperationException("List is empty");

            DoublyLinkedListNode previous = null!;
            var current = First;

            while (current != null)
            {
                if(current.Value.Equals(value))
                {
                    if(previous == null)
                    {
                        base.First = (DoublyLinkedListNode)current.Next;

                        if (First != null)
                            ((DoublyLinkedListNode)First).Prev = null!;
                        else
                            base.Last = null!;
                    }
                    else
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            base.Last = previous;
                        else
                            ((DoublyLinkedListNode)current.Next).Prev = previous;
                    }

                    base.Count--;
                    return;
                }

                previous = (DoublyLinkedListNode)current;
                current = (DoublyLinkedListNode)current.Next;
                
            }
        }

        public void RemoveFirst()
        {
            if (First == null)
                throw new InvalidOperationException("List is empty");

            base.First = (DoublyLinkedListNode)First.Next;
            if (First != null)
                ((DoublyLinkedListNode)First).Prev = null!;
            else
                base.Last = null;

            base.Count--;
        }

        public void RemoveLast()
        {
            if (Last == null)
                throw new InvalidOperationException("List is empty");

            base.Last = ((DoublyLinkedListNode)Last).Prev;
            if (Last != null)
                Last.Next = null;
            else
                base.First = null;

            base.Count--;
        }
    }
}
