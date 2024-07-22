using ObserverList = LibraryClasses.ObserverList<object>;

namespace TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new ObserverList();

            list.OnNotifyEndingProcess += PrintResultList;

            TestAdd(list);
            TestInsert(list);
            TestRemove(list);
            TestRemoveAt(list);
        }

        static void PrintResultList(object? sender, string name)
        {
            Console.WriteLine($"Method: {name} was called.");
        }

        static void TestAdd(ObserverList list)
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            var isSuccess = (int)list[0] == 1
                && (int)list[1] == 2
                && (int)list[2] == 3;

            Console.WriteLine($"Add Test Success: {isSuccess}\n");
        }

        static void TestInsert(ObserverList list)
        {
            list.Insert(1, 99);
            var isSuccess = (int)list[1] == 99;

            Console.WriteLine($"Insert Test Success: {isSuccess}\n");
        }

        static void TestRemove(ObserverList list)
        {
            list.Remove(2);
            var isSuccess = !list.Contains(2);

            Console.WriteLine($"Remove Test Success: {isSuccess}\n");
        }

        static void TestRemoveAt(ObserverList list)
        {
            list.RemoveAt(1);
            var isSuccess = (int)list[1] != 99;

            Console.WriteLine($"RemoveAt Test Success: {isSuccess}\n");
        }
    }
}
