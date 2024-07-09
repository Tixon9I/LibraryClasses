namespace LibraryClasses.Interfaces
{
    internal interface ICollection
    {
        int Count { get; }

        void Add(object item);

        void Clear();

        bool Contains(object item);

        void CopyTo(object[] array, int arrayIndex);

        bool Remove(object item);
    }
}
