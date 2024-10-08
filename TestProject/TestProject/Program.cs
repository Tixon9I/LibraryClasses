﻿namespace TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var linq2 = new Linq2HW();

            var result = linq2.DisplayElementsWithoutArtObjects();

            var result1 = linq2.DisplayNamesOfAllActors();

            var result2 = linq2.DisplayActorsWhoHaveBirthdayInAugust();

            //Console.WriteLine(result2); // Uncomment this code when you start to run this method (DisplayActorsWhoHaveBirthdayInAugust())

            var result3 = linq2.DisplayTheOldestActors();

            var result4 = linq2.DisplayCountBooksForEachAuthor();

            var result5 = linq2.DisplayCountBooksForEachAuthorAndFilmsForEachDirector();

            var result6 = linq2.DisplayCountUniqueLetter();

            //Console.WriteLine(result6); // Uncomment this code when you start to run this method (DisplayCountUniqueLetter())

            var result7 = linq2.DisplayNamesAllBooksOrderedForNamesAuthorAndCountPages();

            var result8 = linq2.DisplayNameActorAndFilmsWithInvolves();

            //foreach (var entry in result8) // Uncomment this code when you start to run this method (DisplayNameActorAndFilmsWithInvolves())
            //{
            //    Console.WriteLine($"{entry.Key}: {string.Join(", ", entry.Value)}");
            //}

            var result9 = linq2.DisplaySumPagesAllBooksAndSumIntValueInSequences();

            var result10 = linq2.DisplayDictionaryBooks();

            //foreach (var entry in result10)  // Uncomment this code when you start to run this method (DisplayDictionaryBooks())
            //{
            //    Console.WriteLine($"{entry.Key}: {string.Join(", ", entry.Value)}");
            //}

            var result11 = linq2.GetMattDamonFilmsExcludingStringActors();

            foreach (var element in result11)
            {
                Console.WriteLine(element);
            }




            Console.WriteLine();
            Console.WriteLine();

            //------------------------------------------------------------------

            // Виведіть усі числа від 10 до 50 через кому
            Console.WriteLine(string.Join(", ", Enumerable.Range(10, 41)));

            Console.WriteLine();

            // Виведіть лише ті числа від 10 до 50, які можна поділити на 3
            Console.WriteLine(string.Join(' ', Enumerable.Range(10, 41).Where(s => s % 3 == 0)));

            Console.WriteLine();

            // Виведіть слово "Linq" 10 разів
            Console.WriteLine(string.Join(' ', Enumerable.Repeat("Linq", 10)));

            Console.WriteLine();

            // Вивести всі слова з буквою «а» в рядку «aaa;abb;ccc;dap»

            var striing = "aaa; abb; ccc; dap".Split(';');

            Console.WriteLine(string.Join(' ', striing.Where(s => s.Contains('a'))));

            Console.WriteLine();

            // Виведіть кількість літер «а» у словах з цією літерою в рядку «aaa;abb;ccc;dap» через кому

            Console.WriteLine(string.Join(',', striing.Select(s => s + s.Count(c => c == 'a'))));

            Console.WriteLine();

            // Вивести true, якщо слово "abb" існує в рядку "aaa;xabbx;abb;ccc;dap", інакше false

            var str = "aaa;xabbx;abb;ccc;dap".Split(';');

            Console.WriteLine(str.Any(a => a.Contains("abb")));

            Console.WriteLine();

            // Отримати найдовше слово в рядку "aaa;xabbx;abb;ccc;dap"

            Console.WriteLine(str.MaxBy(m => m.Length));

            Console.WriteLine();

            // Обчислити середню довжину слова в рядку "aaa;xabbx;abb;ccc;dap"

            Console.WriteLine(str.Average(a => a.Length));

            Console.WriteLine();

            // Вивести найкоротше слово в рядку "aaa;xabbx;abb;ccc;dap;zh" у зворотному порядку.

            var st = "aaa;xabbx;abb;ccc;dap;zh".Split(';');

            Console.WriteLine(st.MinBy(m => m.Length)?.Reverse().ToArray());

            Console.WriteLine();

            // Вивести true, якщо в першому слові, яке починається з "aa", усі літери "b" (За винятком "аа"), інакше false "baaa;aabb;aaa;xabbx;abb;ccc;dap;zh"

            var s = "baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(';');

            Console.WriteLine(s.FirstOrDefault(f => f.StartsWith("aa"))?.Skip(2).All(a => a == 'b') ?? false);

            Console.WriteLine();

            // Вивести останнє слово в послідовності, за винятком перших двох елементів, які закінчуються на "bb" (використовуйте послідовність із 10 завдання)

            Console.Write(string.Join(' ', s.Where(w => !w.EndsWith("bb")).Select(s => s)) + " -> ");
            Console.Write(s.Last());

            Console.WriteLine();
        }
    }
 }
