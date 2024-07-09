namespace LibraryClasses.Interfaces
{
    internal interface IBinaryTree : ICollection
    {
        object? Root { get; }

        object[] DFS();
    }
}
