namespace LibraryClasses
{
    public class List
    {
        private const int DefaultCapacity = 4;
        private object[]? _objects;
        private int _count;

        public int Count { get => _count; }

        public int Capacity { get => _objects!.Length; }

        public object this[int index]
        {
            get
            {
                if (index < 0 || index > _count)
                    throw new IndexOutOfRangeException();
                return _objects![index];
            }

            set
            {
                if (index < 0 || index > _count)
                    throw new IndexOutOfRangeException();
                _objects![index] = value;
            }
        }

        public List()
        {
            _objects = new object[DefaultCapacity];
            _count = 0;
        }

        public List(int capacity)
        {
            _objects = new object[capacity];
            _count = 0;
        }

        private void Resize(int capacity)
        {
            if (capacity > _objects!.Length)
            {
                var newCapacity = _objects.Length * 2;
                var newObjects = new object[newCapacity];

                for (int i = 0; i < Count; i++)
                    newObjects[i] = _objects![i];
                _objects = newObjects;
            }
        }

        public void Add(object obj)
        {
            Resize(_count + 1);
            _objects![_count++] = obj;
        }

        public void Insert(int index, object obj)
        {
            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException();

            Resize(_count + 1);

            if (!Contains(obj))
            {
                for (var i = Count; i > index; i--)
                    _objects![i] = _objects[i - 1];

                _objects![index] = obj;
                _count++;
            }
        }

        public void Remove(object obj)
        {
            var index = IndexOf(obj);

            if (index >= 0)
                RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            for (var i = index; i < _count - 1; i++)
            {
                _objects![i] = _objects[i + 1];
            }
            _count--;
            _objects![_count] = null!;
        }

        public void Clear()
        {
            _objects = new object[DefaultCapacity];
            _count = 0;
        }

        public bool Contains(object obj)
        {
            if (_objects == null)
                return false;

            foreach (var objct in _objects)
            {
                if (objct != null && objct.Equals(obj))
                    return true;
            }
            return false;
        }

        public int IndexOf(object obj)
        {
            if (Contains(obj))
                for (var i = 0; i < Count; i++)
                    if (_objects![i].Equals(obj))
                        return i;
            return -1;
        }

        public object[] ToArray()
        {
            var array = new object[Count];

            for (var i = 0; i < Count; i++)
                array[i] = _objects![i];

            return array;
        }

        public void Reverse()
        {
            for (var i = 0; i < Count / 2; i++)
            {
                var temp = _objects![i];
                _objects[i] = _objects[_count - i - 1];
                _objects[_count - i - 1] = temp;
            }
        }
    }
}
