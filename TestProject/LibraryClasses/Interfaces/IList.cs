namespace LibraryClasses.Interfaces
{
    internal interface IList : ICollection
    {
        object this[int index] { get; set; }

        int IndexOf(object item);

        void Insert(int index, object item);

        void RemoveAt(int index);
    }
}
