namespace LibraryClasses.Interfaces
{
    public interface IStack<T> : ICollections<T>
    {
        void Push(T value);

        T Pop();

        T Peek();
    }
}
