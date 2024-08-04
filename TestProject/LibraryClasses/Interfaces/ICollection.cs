namespace LibraryClasses.Interfaces
{
    public interface ICollections<T> : IEnumerable<T>
    {
        int Count { get; }

        void Add(T item);

        void Clear();

        bool Contains(T item);

        T[] ToArray();
    }
}
