using LibraryClasses;

namespace TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List list = new List(9);

            //list.Add(10);
            //list.Add("10");
            //list.Add('c');
            //list.Add(10.2);
            //list.Add("end");

            //for (int i = 0; i < list.Count; i++)
            //{
            //    var item = list[i];
            //    Console.Write(item + " ");
            //}

            //Console.WriteLine();


            //var num = list.Contains(10);

            //Console.WriteLine(num);


            //list.Insert(0, "111");

            //for (int i = 0; i < list.Count; i++)
            //{
            //    var item = list[i];
            //    Console.Write(item + " ");
            //}

            //Console.WriteLine();


            //list.Reverse();

            //for (int i = 0; i < list.Count; i++)
            //{
            //    var item = list[i];
            //    Console.Write(item + " ");
            //}


            //list.Remove(10);

            //for (int i = 0; i < list.Count; i++)
            //{
            //    var item = list[i];
            //    Console.Write(item + " ");
            //}


            //list.RemoveAt(3);

            //for (int i = 0; i < list.Count; i++)
            //{
            //    var item = list[i];
            //    Console.Write(item + " ");
            //}


            //var index =  list.IndexOf("end");
            //Console.WriteLine(index);


            //list.ToArray();

            //for (int i = 0; i < list.Count; i++)
            //{
            //    var item = list[i];
            //    Console.Write(item + " ");
            //}


            //list.Clear();

            //if(list.Count == 0)
            //{
            //    Console.WriteLine("This list is empty!");
            //}
            //else
            //{
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        var item = list[i];
            //        Console.Write(item + " ");
            //    }
            //}

            //----------------------------------------------
            // BinaryTree

            //BinaryTree tree = new BinaryTree();

            //tree.Add(10);
            //tree.Add(5);
            //tree.Add(15);
            //tree.Add(3);
            //tree.Add(7);
            //tree.Add(12);
            //tree.Add(17);

            //Console.WriteLine(tree.Contains(10)); // True
            //Console.WriteLine(tree.Contains(7));  // True
            //Console.WriteLine(tree.Contains(20)); // False

            //// (DFS)
            //Console.WriteLine("DFS Traversal:");
            //foreach (var value in tree.DFS())
            //{
            //    Console.Write(value + " ");
            //}

            //Console.WriteLine();

            //// (BFS)
            //Console.WriteLine("BFS Traversal:");
            //foreach (var value in tree.ToArray())
            //{
            //    Console.Write(value + " ");
            //}

            //Console.WriteLine();

            //tree.Clear();
            //Console.WriteLine("Tree cleared");
            //Console.WriteLine(tree.Count); // 0

            //----------------------------------------------
            // Queue

            //Queue queue = new Queue();

            //queue.Enqueue(1);
            //queue.Enqueue(2);
            //queue.Enqueue(3);

            //Console.WriteLine("Count: " + queue.Count); // Output: Count: 3

            //Console.WriteLine("Contains 2: " + queue.Contains(2)); // Output: Contains 2: True
            //Console.WriteLine("Contains 4: " + queue.Contains(4)); // Output: Contains 4: False

            //Console.WriteLine("Peek: " + queue.Peek()); // Output: Peek: 1

            //Console.WriteLine("Dequeue: " + queue.Dequeue()); // Output: Dequeue: 1

            //Console.WriteLine("Count: " + queue.Count); // Output: Count: 2

            //var array = queue.ToArray();
            //Console.WriteLine("Queue to Array: " + string.Join(", ", array)); // Output: Queue to Array: 2, 3

            //queue.Clear();
            //Console.WriteLine("Count after Clear: " + queue.Count); // Output: Count after Clear: 0

            //----------------------------------------------
            // Stack

            //Stack stack = new Stack();

            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);

            //Console.WriteLine("Count: " + stack.Count); // Output: Count: 3
            //Console.WriteLine("Contains 2: " + stack.Contains(2)); // Output: Contains 2: True
            //Console.WriteLine("Contains 4: " + stack.Contains(4)); // Output: Contains 4: False

            //Console.WriteLine("Peek: " + stack.Peek()); // Output: Peek: 3
            //Console.WriteLine("Pop: " + stack.Pop()); // Output: Pop: 3

            //Console.WriteLine("Count: " + stack.Count); // Output: Count: 2

            //var array = stack.ToArray();
            //Console.WriteLine("Stack to Array: " + string.Join(", ", array)); // Output: Stack to Array: 2, 1

            //stack.Clear();
            //Console.WriteLine("Count after Clear: " + stack.Count); // Output: Count after Clear: 0

            //----------------------------------------------
            // LinkedList

            //    var linkedList = new LinkedList();

            //    linkedList.Add(10);
            //    linkedList.Add(20);
            //    linkedList.Add(30);

            //    Console.WriteLine("Elements in the list:");
            //    PrintArray(linkedList.ToArray());

            //    linkedList.AddFirst(5);

            //    Console.WriteLine("\nElements in the list after adding first:");
            //    PrintArray(linkedList.ToArray());

            //    linkedList.Insert(2, 15);

            //    Console.WriteLine("\nElements in the list after insertion:");
            //    PrintArray(linkedList.ToArray());

            //    int searchValue = 15;
            //    Console.WriteLine($"\nList contains {searchValue}: {linkedList.Contains(searchValue)}");

            //    linkedList.Clear();
            //    Console.WriteLine("\nList cleared.");

            //    Console.WriteLine("\nElements in the list after clearing:");
            //    PrintArray(linkedList.ToArray());
            //}

            //static void PrintArray(object[] array)
            //{
            //    foreach (var item in array)
            //    {
            //        Console.Write($"{item} ");
            //    }
            //    Console.WriteLine();
            //}

            //----------------------------------------------
            // DoubleLinkedList

            //var list = new DoublyLinkedList();

            //list.Add(1);
            //list.Add(2);
            //list.Add(3);
            //list.Add(4);
            //list.Add(5);

            
            //Console.WriteLine("List elements:");
            //var array = list.ToArray();
            //foreach (var element in array)
            //{
            //    Console.Write(element + " ");
            //}
            //Console.WriteLine();

            
            //Console.WriteLine("Removing element 3 from the list...");
            //list.Remove(3);
            //array = list.ToArray();
            //foreach (var element in array)
            //{
            //    Console.Write(element + " ");
            //}
            //Console.WriteLine();

            
            //Console.WriteLine("Removing the first element from the list...");
            //list.RemoveFirst();
            //array = list.ToArray();
            //foreach (var element in array)
            //{
            //    Console.Write(element + " ");
            //}
            //Console.WriteLine();

            
            //Console.WriteLine("Removing the last element from the list...");
            //list.RemoveLast();
            //array = list.ToArray();
            //foreach (var element in array)
            //{
            //    Console.Write(element + " ");
            //}
            //Console.WriteLine();

       
            //Console.WriteLine("Inserting element 10 at index 1...");
            //list.Insert(1, 10);
            //array = list.ToArray();
            //foreach (var element in array)
            //{
            //    Console.Write(element + " ");
            //}
            //Console.WriteLine();


            //Console.WriteLine("Checking if 3 is in the list: " + list.Contains(3));
            //Console.WriteLine("Checking if 10 is in the list: " + list.Contains(10));
            //Console.WriteLine();

            //Console.WriteLine("Clearing the list...");
            //list.Clear();
            //Console.WriteLine("List cleared. Count: " + list.Count);
            //Console.WriteLine();
        }
    }
}
