using LibraryClasses.Interfaces;
using System.Threading;

namespace LibraryClasses
{
    public class Stack : IStack
    {
        private class StackNode
        {
            public object Value { get; }
            public StackNode? Next { get; set; }

            public StackNode(object value)
            {
                Value = value;
                Next = null;
            }
        }

        private StackNode? _top;
        public int Count { get; private set; }

        public Stack()
        {
            _top = null;
            Count = 0;
        }

        void ICollection.Add(object item)
        {
            Push(item);
        }

        bool ICollection.Remove(object item)
        {
            return (Pop() is StackNode) ? true : false;
        }

        public void CopyTo(object[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "The target array cannot be null.");


            if (arrayIndex < 0 || arrayIndex >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "The array index is out of range.");


            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("The target array does not have enough space to copy all elements.");

            var current = _top;

            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex + i] = current!.Value;
                current = current?.Next;
            }
        }


        public void Push(object value)
        {
            var node = new StackNode(value);

            if(_top== null)
                _top = node;
            else
            {
                node.Next = _top;
                _top = node;
            }

            Count++;
        }

        public object Pop()
        {
            if(_top == null)
                throw new InvalidOperationException("Stack is empty");

            var poppedElement = _top.Value;
            _top = _top.Next;
            Count--;
            
            return poppedElement;
        }

        public object Peek()
        {
            if (_top == null)
                throw new InvalidOperationException("Stack is empty");
            
            return _top.Value;
        }

        public bool Contains(object value)
        {
            if (_top == null)
                return false;
            else
            {
                var current = _top;

                while (current != null)
                {
                    if(current.Value.Equals(value))
                        return true;
                    current = current.Next;
                }
            }

            return false;
        }

        public object[] ToArray()
        {
            if(_top == null)
                return new object[0];

            var objects = new object[Count];
            var current = _top;
            var index = 0;

            while(current != null)
            {
                objects[index++] = current.Value;
                current = current.Next;
            }

            return objects;
        }

        public void Clear()
        {
            _top = null;
            Count = 0;
        }
    }
}
