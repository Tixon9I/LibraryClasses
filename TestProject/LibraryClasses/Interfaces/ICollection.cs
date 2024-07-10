namespace LibraryClasses.Interfaces
{
    internal interface ICollection
    {
        int Count { get; }

        void Add(object item);

        void Clear();

        bool Contains(object item);

        object[] ToArray();

        //bool Remove(object item);
    }
}
