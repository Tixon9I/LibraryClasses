namespace LibraryClasses.Interfaces
{
    internal interface IQueue : ICollection
    {
        void Enqueue(object value);

        object Dequeue();

        object Peek();
    }
}
