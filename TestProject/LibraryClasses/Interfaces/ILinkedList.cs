namespace LibraryClasses.Interfaces
{
    internal interface ILinkedList : ICollection
    {
        object? First { get; }
        object? Last { get; }

        void Insert(int index, object value);

        void AddFirst(object value);
    }
}
