using LibraryClasses.Interfaces;

namespace LibraryClasses
{
    public class Queue : IQueue
    {
        private class QueueNode
        {
            public object Value { get; }
            public QueueNode? Next { get; set; }

            public QueueNode(object value)
            {
                Value = value;
                Next = null;
            }
        }

        private QueueNode? _head;
        private QueueNode? _tail;
        public int Count { get; private set; }

        public Queue()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        void ICollection.Add(object item)
        {
            Enqueue(item);
        }

        bool ICollection.Remove(object item)
        {
            return (Dequeue() is QueueNode) ? true : false;
        }

        public void CopyTo(object[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "The target array cannot be null.");


            if (arrayIndex < 0 || arrayIndex >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "The array index is out of range.");


            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("The target array does not have enough space to copy all elements.");
            
            var current = _head;

            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex + i] = current!.Value;
                current = current?.Next;
            }
        }

        public void Enqueue(object value)
        {
            var newNode = new QueueNode(value);

            if(_tail == null)
            {
                _head = newNode;
                _tail = newNode;
            } 
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }
                
            Count++;
        }

        public object Dequeue()
        {
            if (_head == null)
                throw new InvalidOperationException("Queue is empty");
            

            var deQueueElement = _head.Value;
            _head = _head.Next;
            Count--;

            if (_head == null)
                _tail = null;

            return deQueueElement;
        }

        public bool Contains(object value)
        {
            return Count > 0 && Contains(_head!, value);
        }

        private bool Contains(QueueNode current, object value)
        {
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return true;

                current = current.Next!;
            }

            return false;
        }

        public object Peek()
        {
            if (_head == null)
                throw new InvalidOperationException("Queue is empty");

            return _head.Value;
        }

        public object[] ToArray()
        {
            if (_head == null)
                return new object[0];

            var objects = new object[Count];
            var current = _head;
            var index = 0;

            while (current != null)
            {
                objects[index++] = current.Value;
                current = current.Next;
            }

            return objects;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }
    }
}
