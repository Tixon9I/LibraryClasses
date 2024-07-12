namespace LibraryClasses.Interfaces
{
    public interface IQueue<T> : ICollections<T>
    {
        void Enqueue(T value);

        T Dequeue();

        T Peek();
    }
}
