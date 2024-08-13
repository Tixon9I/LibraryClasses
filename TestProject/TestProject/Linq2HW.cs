namespace TestProject
{
    public class Linq2HW
    {
        class Actor
        {
            public string Name { get; set; }
            public DateTime Birthdate { get; set; }
        }

        abstract class ArtObject
        {
            public string Author { get; set; }
            public string Name { get; set; }
            public int Year { get; set; }
        }

        class Film : ArtObject
        {
            public int Length { get; set; }
            public IEnumerable<Actor> Actors { get; set; }
        }

        class Book : ArtObject
        {
            public int Pages { get; set; }
        }

        List<object> data = new List<object>() 
        { 
              "Hello",
              new Book() 
              { 
                  Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 
              },
              new List<int>() 
              {
                  4, 6, 8, 2
              },
              new string[] 
              {
                  "Hello inside array"
              },
              new Film() { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>()
              {
                new Actor() { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                new Actor() { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
              }},
              new Film() { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>()
              {
                new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                new Actor() { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
              }},
              new Book() 
              { 
                  Author = "Stephen King", Name="Finders Keepers", Pages = 200
              },
              "Leonardo DiCaprio"
         };

        //1. Виведіть усі елементи, крім ArtObjects
        public List<object> DisplayElementsWithoutArtObjects()
        {
            var result = data
                .Where(w => !(w is ArtObject))
                .ToList();
                
            return result;
        }

        //2. Виведіть імена всіх акторів
        public IEnumerable<string> DisplayNamesOfAllActors()
        {
            var result = data.OfType<Film>()
                .SelectMany(s => s.Actors)
                .Select(s => s.Name);

            return result;
        }

        //3. Виведіть кількість акторів, які народилися в серпні
        public int DisplayActorsWhoHaveBirthdayInAugust()
        {
            var result = data.OfType<Film>()
                .SelectMany(s => s.Actors)
                .Count(c => c.Birthdate.Month == 8);

            return result;
        }

        //4. Виведіть два найстаріших імена акторів
        public IEnumerable<string> DisplayTheOldestActors()
        {
            var result = data.OfType<Film>()
                .SelectMany(s => s.Actors)
                .OrderBy(o => o.Birthdate)
                .Take(2)
                .Select(s => s.Name);

            return result;
        }

        //5. Вивести кількість книг на авторів
        public Dictionary<string, int> DisplayCountBooksForEachAuthor()
        {
            var result = data.OfType<Book>()
                .GroupBy(g => g.Author)
                .ToDictionary(d => d.Key, d => d.Count());

            return result;
        }

        //6. Виведіть кількість книг на одного автора та фільмів на одного режисера
        public Dictionary<string, (int Books, int Films)> DisplayCountBooksForEachAuthorAndFilmsForEachDirector()
        {
            var result = data.OfType<Book>()
                        .GroupBy(g => g.Author)
                        .Select(group => new
                        {
                            AuthorOrDirector = group.Key,
                            Books = group.Count(),
                            Films = 0
                        })
                        .Union(data.OfType<Film>()
                        .GroupBy(g => g.Author)
                        .Select(group => new
                        {
                            AuthorOrDirector = group.Key,
                            Books = 0,
                            Films = group.Count()
                        }))
                        .GroupBy(item => item.AuthorOrDirector)
                        .ToDictionary(
                            group => group.Key,
                            group =>
                            (
                                Books: group.Sum(item => item.Books),
                                Films: group.Sum(item => item.Films)
                            )
                         );
                        
            return result;
        }

        //7. Виведіть, скільки різних букв використано в іменах усіх акторів
        public int DisplayCountUniqueLetter()
        {
            var result = data.OfType<Film>()
                .SelectMany(s => s.Actors)
                .SelectMany(s => s.Name)
                .Where(w => char.IsLetter(w))
                .Select(s => char.ToLower(s))
                .Distinct()
                .Count();

            return result;
        }

        //8. Виведіть назви всіх книг, упорядковані за іменами авторів і кількістю сторінок
        public IEnumerable<string> DisplayNamesAllBooksOrderedForNamesAuthorAndCountPages()
        {
            var result = data.OfType<Book>()
                .OrderBy(o => o.Author)
                .ThenBy(o => o.Pages)
                .Select(s => s.Name);

            return result;
        }

        //9. Виведіть ім'я актора та всі фільми за участю цього актора
        public Dictionary<string, string[]> DisplayNameActorAndFilmsWithInvolves()
        {
            var result = data.OfType<Film>()
                        .SelectMany(film => film.Actors, (film, actor) => new { NameActor = actor, FilmName = film })
                        .GroupBy(g => g.NameActor.Name)
                        .ToDictionary(
                            group => group.Key,
                            group => group.Select(x => x.FilmName.Name).ToArray()
                         );

            return result;
        }

        //10. Виведіть суму загальної кількості сторінок у всіх книгах і всі значення int у всіх послідовностях у даних
        public int[] DisplaySumPagesAllBooksAndSumIntValueInSequences()
        {
            var sumInts = data.OfType<IEnumerable<int>>()
                .SelectMany(i => i)
                .Sum();

            var sumPages = data.OfType<Book>()
                .Sum(book => book.Pages);

            return new int[] { sumPages, sumInts };
        }

        //11. Отримати словник з ключем - автор книги, значенням - список авторських книг
        public Dictionary<string, string[]> DisplayDictionaryBooks()
        {
            var result = data.OfType<Book>()
                .GroupBy(g => g.Author)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(s => s.Name).ToArray()
                );

            return result;
        }

        //12. Вивести всі фільми "Метт Деймон", за винятком фільмів з акторами, імена яких представлені в даних у вигляді рядків
        public IEnumerable<string> GetMattDamonFilmsExcludingStringActors()
        {
            var stringActorNames = data.OfType<string>().ToHashSet();

            var result = data.OfType<Film>()
                .Where(w => w.Actors.Any(a => a.Name == "Matt Damon") && !w.Actors.Any(a => stringActorNames.Contains(a.Name)))
                .Select(s => s.Name);

            return result;
        }
    }
}
