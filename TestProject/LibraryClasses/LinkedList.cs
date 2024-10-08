﻿using LibraryClasses.Interfaces;
using System.Collections;

namespace LibraryClasses
{
    public class LinkedList<T> : ILinkedList<T>
    {
        protected class LinkedListNode
        {
            public T Value { get; }
            public LinkedListNode? Next { get; set; }

            public LinkedListNode(T value)
            {
                Value = value;
                Next = null;
            }
        }

        protected LinkedListNode? _first;
        protected LinkedListNode? _last;

        public T? First => _first!.Value;
        public T? Last => _last!.Value;

        public int Count { get; protected set; }

        public LinkedList()
        {
            _first = null;
            _last = null;
            Count = 0;
        }

        protected virtual LinkedListNode CreateNode(T value, LinkedListNode? next = null, LinkedListNode? prev = null)
        {
            return new LinkedListNode(value) { Next = next};
        }

        protected virtual void UpdateNode(LinkedListNode node, LinkedListNode? next = null, LinkedListNode? prev = null, bool flagInsert = false)
        {
            prev!.Next = node;
        }

        public void Add(T value)
        {
            var newNode = CreateNode(value);

            if(_first == null)
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                UpdateNode(newNode, next: null, prev: _last);

                _last = newNode;
            }

            Count++;
        }

        public void AddFirst(T value)
        {
            var newNode = CreateNode(value);

            if (_first == null)
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                UpdateNode(_first, next: null, prev: newNode);
                _first = newNode;
            }

            Count++;
        }

        public virtual void Insert(int index, T value)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == 0)
            {
                AddFirst(value); 
                return;
            }
                
            var newNode = CreateNode(value);
            var currentIndex = 0;
            var current = _first;

            while (currentIndex < index - 1)
            {
                current = current!.Next;
                currentIndex++;

                if (current == null)
                    throw new IndexOutOfRangeException("Index is out of range.");
            }

            newNode.Next = current?.Next;
            UpdateNode(newNode, prev: current, flagInsert: true);
            
            Count++;
        }

        public bool Contains(T value)
        {
            if (_first == null)
                return false;
            else
            {
                if(_first.Value!.Equals(value) || _last!.Value!.Equals(value))
                    return true;
                else
                {
                    var currentNode = _first.Next;

                    while (currentNode != null)
                    {
                        if(currentNode.Value!.Equals(value))
                            return true;
                        currentNode = currentNode.Next;
                    }
                }
            }

            return false;
        }

        protected virtual bool RemoveNode(T value)
        {
            LinkedListNode? prevNode = null;
            var current = _first;

            while (current != null)
            {
                if (current.Value!.Equals(value))
                {
                    if (_first!.Value!.Equals(value))
                    {
                        _first = current.Next;

                        if (_first == null)
                            _last = null;
                    }
                    else
                    {
                        prevNode!.Next = current.Next;

                        if (current.Next == null)
                            _last = prevNode;
                    }

                    Count--;
                    return true;
                }

                prevNode = current;
                current = current.Next;
            }

            return false;
        }

        public bool Remove(T value)
        {
            if (_first == null)
                throw new InvalidOperationException("List is empty");

            return RemoveNode(value);
        }

        public T[] ToArray()
        {
            var objects = new T[0];

            if(_first == null)
                return objects;

            objects = new T[Count];
            var currentNode = _first;
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
            _first = null; 
            _last = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _first;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
