namespace LibraryClasses.Interfaces
{
    public interface IBinaryTree<T> : ICollections<T>
    {
        T? Root { get; }

        T[] DFS();
    }
}
