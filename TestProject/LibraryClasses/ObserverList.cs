namespace LibraryClasses
{
    public class TypeOperationList<T> : EventArgs
    {
        public string TypeOperation { get; init; }
        public int? Index { get; init; }
        public T? Item { get; init; }
    }


    public class ObserverList<T> : List<T>
    {
        public override void Add(T obj)
        {
            base.Add(obj);
            OnNotifyEndingProcess?.Invoke(this, new TypeOperationList<T> { TypeOperation = nameof(Add), Index = null, Item = obj });
        }

        public override void Insert(int index, T obj)
        {
            base.Insert(index, obj);
            OnNotifyEndingProcess?.Invoke(this, new TypeOperationList<T> { TypeOperation = nameof(Insert), Index = index, Item = obj });
        }

        public override bool Remove(T obj)
        {
            var resultRemoved = base.Remove(obj);

            OnNotifyEndingProcess?.Invoke(this, new TypeOperationList<T> { TypeOperation = nameof(Remove), Index = null, Item = obj });

            return resultRemoved;
        }

        public override void RemoveAt(int index)
        {
            var item = this[index];
            base.RemoveAt(index);
            OnNotifyEndingProcess?.Invoke(this, new TypeOperationList<T> { TypeOperation = nameof(RemoveAt), Index = index, Item = item });
        }

        public event EventHandler<TypeOperationList<T>>? OnNotifyEndingProcess;
    }
}
