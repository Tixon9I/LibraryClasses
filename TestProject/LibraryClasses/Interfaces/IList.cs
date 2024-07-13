namespace LibraryClasses.Interfaces
{
    public interface ILiist<T> : ICollections<T>
    {
        T this[int index] { get; set; }

        int IndexOf(T item);

        void Insert(int index, T item);

        void RemoveAt(int index);
    }
}
