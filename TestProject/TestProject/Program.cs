using LibraryClasses.LinqExtensions;
using CustomList = LibraryClasses.List<int>;
using CustomBinaryTree = LibraryClasses.BinaryTree<int>;
using CustomQueue = LibraryClasses.Queue<int>;
using CustomStack = LibraryClasses.Stack<int>;
using CustomLinkedList = LibraryClasses.LinkedList<int>;
using CustomDoublyLinkedList = LibraryClasses.DoublyLinkedList<int>;
using LibraryClasses.Interfaces;

namespace TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CustomList testing
            Console.WriteLine("Testing on CustomList:");
            var customList = new CustomList{ 1, 2, 3, 4, 5 };
            TestLinqMethods(customList);

            // CustomBinaryTree testing
            Console.WriteLine("Testing on CustomBinaryTree:");
            var customBinaryTree = new CustomBinaryTree();
            customBinaryTree.Add(1);
            customBinaryTree.Add(2);
            customBinaryTree.Add(3);
            TestLinqMethods(customBinaryTree);

            // CustomQueue testing
            Console.WriteLine("Testing on CustomQueue:");
            var customQueue = new CustomQueue();
            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            TestLinqMethods(customQueue);

            // CustomStack testing
            Console.WriteLine("Testing on CustomStack:");
            var customStack = new CustomStack();
            customStack.Push(1);
            customStack.Push(2);
            customStack.Push(3);
            TestLinqMethods(customStack);

            // CustomLinkedList testing
            Console.WriteLine("Testing on CustomLinkedList:");
            var customLinkedList = new CustomLinkedList();
            customLinkedList.Add(1);
            customLinkedList.Add(2);
            customLinkedList.Add(3);
            TestLinqMethods(customLinkedList);

            // CustomDoublyLinkedList testing
            Console.WriteLine("Testing on CustomDoublyLinkedList:");
            var customDoublyLinkedList = new CustomDoublyLinkedList();
            customDoublyLinkedList.Add(1);
            customDoublyLinkedList.Add(2);
            customDoublyLinkedList.Add(3);
            TestLinqMethods(customDoublyLinkedList);

            Console.ReadLine();
        }

        static void TestLinqMethods<T>(ICollections<T> collection)
        {
            Console.Write("Filter: ");
            foreach (var item in collection.Filter(x => (int?)(object?)x % 2 == 1)) // Filter odd numbers
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("Skip: ");
            foreach (var item in collection.Skiip(2)) // Skip the first 2 elements
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("SkipWhile: ");
            foreach (var item in collection.SkiipWhile(x => (int?)(object?)x < 3)) // Skip as long as the value is less than 3
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("Take: ");
            foreach (var item in collection.Taake(3)) // Take the first 3 elements
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("TakeWhile: ");
            foreach (var item in collection.TaakeWhile(x => (int?)(object?)x < 4)) // Take while the value is less than 4
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("First: ");
            foreach (var item in collection.Fiirst(x => (int?)(object?)x == 2)) // The first element with value 2
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("FirstOrDefault: ");
            foreach (var item in collection.FiirstOrDefault(x => (int?)(object?)x == 10)) // First element with value 10 or default value
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("Last: ");
            foreach (var item in collection.Laast(x => (int?)(object?)x == 3)) // The last element with value 3
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("LastOrDefault: ");
            foreach (var item in collection.LaastOrDefault(x => (int?)(object?)x == 10)) // Last element with value 10 or default value
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("All: ");
            foreach (var result in collection.Aall(x => (int?)(object?)x > 0)) // Check that all elements are greater than 0
            {
                Console.Write(result);
            }
            Console.WriteLine();

            Console.Write("Any: ");
            foreach (var result in collection.Aany(x => (int?)(object?)x == 2)) // Check if there is at least one element with value 2
            {
                Console.Write(result);
            }
            Console.WriteLine();

            Console.Write("Select: ");
            foreach (var item in collection.Seelect(x => (int?)(object?)x * 2)) // Double the value
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("SelectMany: ");
            foreach (var item in collection.SeelectMany(
            x => new CustomList { (dynamic?)x, (dynamic?)x * 10 }))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("ToArray: ");
            var array = collection.ToArray(x => (int?)(object?)x * 1); // Convert to array
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("ToList: ");
            var list = collection.ToList(x => (int?)(object?)x * 1); // Convert to list
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }
     }
 }
