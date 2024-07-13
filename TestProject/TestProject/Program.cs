using CustomList = LibraryClasses.List<object>;
using CustomBinaryTree = LibraryClasses.BinaryTree<int>;
using CustomQueue = LibraryClasses.Queue<int>;
using CustomStack = LibraryClasses.Stack<int>;
using CustomLinkedList = LibraryClasses.LinkedList<int>;
using CustomDoublyLinkedList = LibraryClasses.DoublyLinkedList<int>;

namespace TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestList();

            //TestBinaryTree();

            //TestQueue();

            //TestStack();

            //TestLinkedList();

            TestDoublyLinkedList();
        }

        static void TestList()
        {
            CustomList list = new CustomList(9);
            
            AddElementsToList(list);

            TestListContains(list);

            TestListInsert(list);

            TestListReverse(list);

            TestListRemove(list);

            TestListRemoveAt(list);

            TestListIndexOf(list);

            TestListToArray(list);

            TestListClear(list);
        }

        static void AddElementsToList(CustomList list)
        {
            list.Add(10);
            list.Add("10");
            list.Add('c');
            list.Add(10.2);
            list.Add("end");

            Console.Write("List: ");
            PrintList(list);
            Console.WriteLine();
        }

        static void TestListContains(CustomList list)
        {
            var num = list.Contains(10);
            Console.WriteLine($"List contains 10: {num}");
            Console.WriteLine();
        }

        static void TestListInsert(CustomList list)
        {
            list.Insert(0, "111");
            Console.WriteLine("List after inserting '111' at index 0:");
            PrintList(list);
            Console.WriteLine();
        }

        static void TestListReverse(CustomList list)
        {
            list.Reverse();
            Console.WriteLine("List after reversing:");
            PrintList(list);
            Console.WriteLine();
        }

        static void TestListRemove(CustomList list)
        {
            list.Remove(10);
            Console.WriteLine("List after removing '10':");
            PrintList(list);
            Console.WriteLine();
        }

        static void TestListRemoveAt(CustomList list)
        {
            list.RemoveAt(3);
            Console.WriteLine("List after removing element at index 3:");
            PrintList(list);
            Console.WriteLine();
        }

        static void TestListIndexOf(CustomList list)
        {
            var index = list.IndexOf("end");
            Console.WriteLine($"Index of 'end' in the list: {index}");
            Console.WriteLine();
        }

        static void TestListToArray(CustomList list)
        {
            var array = list.ToArray();
            Console.WriteLine("List converted to array:");
            PrintArrayMethodList(array);
            Console.WriteLine();
        }

        static void TestListClear(CustomList list)
        {
            list.Clear();
            Console.WriteLine("List cleared.");
            if (list.Count == 0)
            {
                Console.WriteLine("This list is empty!");
            }
            else
            {
                Console.WriteLine("List elements after clearing:");
                PrintList(list);
            }
            Console.WriteLine();
        }

        static void PrintList(CustomList list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void PrintArrayMethodList(object[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }


        static void TestBinaryTree()
        {
            CustomBinaryTree tree = new CustomBinaryTree();

            tree.Add(10);
            tree.Add(5);
            tree.Add(15);
            tree.Add(3);
            tree.Add(7);
            tree.Add(12);
            tree.Add(17);

            Console.Write("Binary tree: ");

            var array = tree.ToArray();

            foreach (var item in array)
            { Console.Write(item + " "); }

            Console.WriteLine("\n");

            TestBinaryTreeContains(tree);

            TestBinaryTreeDFS(tree);

            TestBinaryTreeBFS(tree);

            TestBinaryTreeClear(tree);
        }

        static void TestBinaryTreeContains(CustomBinaryTree tree)
        {
            Console.WriteLine($"Contains 10: {tree.Contains(10)}"); // True
            Console.WriteLine($"Contains 7: {tree.Contains(7)}");   // True
            Console.WriteLine($"Contains 20: {tree.Contains(20)}"); // False
            Console.WriteLine();
        }

        static void TestBinaryTreeDFS(CustomBinaryTree tree)
        {
            Console.WriteLine("DFS Traversal:");
            foreach (var value in tree.DFS())
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void TestBinaryTreeBFS(CustomBinaryTree tree)
        {
            Console.WriteLine("BFS Traversal:");
            foreach (var value in tree.ToArray())
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void TestBinaryTreeClear(CustomBinaryTree tree)
        {
            tree.Clear();
            Console.WriteLine("Tree cleared");
            Console.WriteLine($"Tree count: {tree.Count}");
            Console.WriteLine();
        }


        static void TestQueue()
        {
            CustomQueue queue = new CustomQueue();
            
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            TestQueueToArray(queue);

            TestQueueCount(queue);

            TestQueueContains(queue);

            TestQueuePeek(queue);

            TestQueueDequeue(queue);

            TestQueueToArray(queue);

            TestQueueClear(queue);
        }

        static void TestQueueCount(CustomQueue queue)
        {
            Console.WriteLine("Count: " + queue.Count); // Output: Count: 3
            Console.WriteLine();
        }

        static void TestQueueContains(CustomQueue queue)
        {
            Console.WriteLine("Contains 2: " + queue.Contains(2)); // Output: Contains 2: True
            Console.WriteLine("Contains 4: " + queue.Contains(4)); // Output: Contains 4: False
            Console.WriteLine();
        }

        static void TestQueuePeek(CustomQueue queue)
        {
            Console.WriteLine("Peek: " + queue.Peek()); // Output: Peek: 1
            Console.WriteLine();
        }

        static void TestQueueDequeue(CustomQueue queue)
        {
            Console.WriteLine("Dequeue: " + queue.Dequeue()); // Output: Dequeue: 1
            Console.WriteLine();
        }

        static void TestQueueToArray(CustomQueue queue)
        {
            var array = queue.ToArray();
            Console.WriteLine("Queue to Array: " + string.Join(", ", array)); // Output: Queue to Array: 2, 3
            Console.WriteLine();
        }

        static void TestQueueClear(CustomQueue queue)
        {
            queue.Clear();
            Console.WriteLine("Count after Clear: " + queue.Count); // Output: Count after Clear: 0
            Console.WriteLine();
        }


        static void TestStack()
        {
            CustomStack stack = new CustomStack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            TestStackToArray(stack);

            TestStackCount(stack);

            TestStackContains(stack);

            TestStackPeek(stack);

            TestStackPop(stack);

            TestStackToArray(stack);

            TestStackClear(stack);
        }

        static void TestStackCount(CustomStack stack)
        {
            Console.WriteLine("Count: " + stack.Count); // Output: Count: 3
            Console.WriteLine();
        }

        static void TestStackContains(CustomStack stack)
        {
            Console.WriteLine("Contains 2: " + stack.Contains(2)); // Output: Contains 2: True
            Console.WriteLine("Contains 4: " + stack.Contains(4)); // Output: Contains 4: False
            Console.WriteLine();
        }

        static void TestStackPeek(CustomStack stack)
        {
            Console.WriteLine("Peek: " + stack.Peek()); // Output: Peek: 3
            Console.WriteLine();
        }

        static void TestStackPop(CustomStack stack)
        {
            Console.WriteLine("Pop: " + stack.Pop()); // Output: Pop: 3
            Console.WriteLine();
        }

        static void TestStackToArray(CustomStack stack)
        {
            var array = stack.ToArray();
            Console.WriteLine("Stack to Array: " + string.Join(", ", array)); // Output: Stack to Array: 2, 1
            Console.WriteLine();
        }

        static void TestStackClear(CustomStack stack)
        {
            stack.Clear();
            Console.WriteLine("Count after Clear: " + stack.Count); // Output: Count after Clear: 0
            Console.WriteLine();
        }


        static void TestLinkedList()
        {
            var linkedList = new CustomLinkedList();

            linkedList.Add(10);
            linkedList.Add(20);
            linkedList.Add(30);

            TestPrintLinkedList(linkedList);

            linkedList.AddFirst(5);

            TestPrintLinkedList(linkedList);

            linkedList.Insert(2, 15);

            TestPrintLinkedList(linkedList);

            // Contains
            int searchValue = 15;
            Console.WriteLine($"\nList contains {searchValue}: {linkedList.Contains(searchValue)}");
            Console.WriteLine();

            // Clear
            linkedList.Clear();
            Console.WriteLine("List cleared.");

            TestPrintLinkedList(linkedList);
        }

        static void TestPrintLinkedList(CustomLinkedList linkedList)
        {
            Console.WriteLine("Elements in the list:");
            PrintArrayMethodLinkedList(linkedList.ToArray());
            Console.WriteLine();
        }

        static void PrintArrayMethodLinkedList(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }


        static void TestDoublyLinkedList()
        {
            var doublyLinkedList = new CustomDoublyLinkedList();

            TestDoublyLinkedListAdd(doublyLinkedList);
            TestDoublyLinkedListRemove(doublyLinkedList);
            TestDoublyLinkedListInsert(doublyLinkedList);
            TestDoublyLinkedListContains(doublyLinkedList);
            TestDoublyLinkedListClear(doublyLinkedList);
        }

        static void TestDoublyLinkedListAdd(CustomDoublyLinkedList list)
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            PrintListMethodDoublyLinkedList(list);
        }

        static void TestDoublyLinkedListRemove(CustomDoublyLinkedList list)
        {
            Console.WriteLine("Removing element 3 from the list...");
            list.Remove(3);
            PrintListMethodDoublyLinkedList(list);

            Console.WriteLine("Removing the first element from the list...");
            list.RemoveFirst();
            PrintListMethodDoublyLinkedList(list);

            Console.WriteLine("Removing the last element from the list...");
            list.RemoveLast();
            PrintListMethodDoublyLinkedList(list);
        }

        static void TestDoublyLinkedListInsert(CustomDoublyLinkedList list)
        {
            Console.WriteLine("Inserting element 10 at index 1...");
            list.Insert(1, 10);
            PrintListMethodDoublyLinkedList(list);
        }

        static void TestDoublyLinkedListContains(CustomDoublyLinkedList list)
        {
            Console.WriteLine("Checking if 3 is in the list: " + list.Contains(3));
            Console.WriteLine("Checking if 10 is in the list: " + list.Contains(10));
            Console.WriteLine();
        }

        static void TestDoublyLinkedListClear(CustomDoublyLinkedList list)
        {
            Console.WriteLine("Clearing the list...");
            list.Clear();
            Console.WriteLine("List cleared. Count: " + list.Count);
            Console.WriteLine();
        }

        static void PrintListMethodDoublyLinkedList(CustomDoublyLinkedList list)
        {
            Console.Write("List elements: ");
            var array = list.ToArray();
            foreach (var element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine("\n");
        }
    }
}
