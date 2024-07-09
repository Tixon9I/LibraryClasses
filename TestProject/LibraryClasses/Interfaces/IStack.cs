namespace LibraryClasses.Interfaces
{
    internal interface IStack : ICollection
    {
        void Push(object value);

        object Pop();

        object Peek();
    }
}
