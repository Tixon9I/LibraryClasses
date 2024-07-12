namespace LibraryClasses.Interfaces
{
    public interface ILinkedList<T> : ICollections<T>
    {
        T? First { get; }
        T? Last { get; }

        void Insert(int index, T value);

        void AddFirst(T value);
    }
}
