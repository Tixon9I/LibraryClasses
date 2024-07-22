namespace LibraryClasses
{
    public class ObserverList<T> : List<T>
    {
        public override void Add(T obj)
        {
            base.Add(obj);
            OnNotifyEndingProcess?.Invoke(this, nameof(Add));
        }

        public override void Insert(int index, T obj)
        {
            base.Insert(index, obj);
            OnNotifyEndingProcess?.Invoke(this, nameof(Insert));
        }

        public override bool Remove(T obj)
        {
            var resultRemoved = base.Remove(obj);

            OnNotifyEndingProcess?.Invoke(this, nameof(Remove));

            return resultRemoved;
        }

        public override void RemoveAt(int index)
        {
            base.RemoveAt(index);
            OnNotifyEndingProcess?.Invoke(this, nameof(RemoveAt));
        }

        public event EventHandler<string>? OnNotifyEndingProcess;
    }
}
