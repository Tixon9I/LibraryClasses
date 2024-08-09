using LibraryClasses.Interfaces;

namespace LibraryClasses.LinqExtensions;

public static class LinqExtensions
{
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Predicate<T> predicate)
    {
        foreach(var item in collection)
        {
            if(predicate(item))
                yield return item;
        }
    }

    public static IEnumerable<T> Skiip<T>(this IEnumerable<T> collection, int missCount)
    {
        foreach (var item in collection)
        {
            missCount--;
            if(missCount < 0)
                yield return item;
        }
    }

    public static IEnumerable<T> SkiipWhile<T>(this IEnumerable<T> collection, Predicate<T> predicate)
    {
        foreach (var item in collection)
        {
            if(!predicate(item))
                yield return item;
        }
    }

    public static IEnumerable<T> Taake<T>(this IEnumerable<T> collection, int takeCount)
    {
        foreach (var item in collection)
        {
            takeCount--;

            if(takeCount >= 0)
                yield return item;
            else
                yield break;
        }
    }

    public static IEnumerable<T> TaakeWhile<T>(this IEnumerable<T> collection, Predicate<T> predicate)
    {
        foreach (var item in collection)
        {
            if(predicate(item))
                yield return item;
        }
    }

    public static T Fiirst<T>(this IEnumerable<T> collection, Predicate<T> predicate)
    {
        if(collection == null)
            throw new NullReferenceException();

        foreach (var item in collection)
        {
            if (predicate(item))
            {
                return item;
            }
        }

        throw new InvalidOperationException();
    }

    public static IEnumerable<T> FiirstOrDefault<T>(this IEnumerable<T> collection, Predicate<T> predicate)
    {
        var flagIn = false;

        foreach (var item in collection)
        {
            if (predicate(item))
            {
                flagIn = true;
                yield return item;
                yield break;
            }
        }

        if(!flagIn)
            yield return default!;
    }

    public static T Laast<T>(this IEnumerable<T> collection, Predicate<T> predicate)
    {
        if (collection == null)
            throw new NullReferenceException();

        var flagIn = false;
        T lastItem = default!;

        foreach (var item in collection)
        {
            if (predicate(item))
            {
                flagIn = true;
                lastItem = item;
            }
        }

        if (!flagIn)
            throw new InvalidOperationException();
        else
            return lastItem;
    }

    public static IEnumerable<T> LaastOrDefault<T>(this IEnumerable<T> collection, Predicate<T> predicate)
    {
        var flagIn = false;
        T lastItem = default!;

        foreach (var item in collection)
        {
            if (predicate(item))
            {
                flagIn = true;
                lastItem = item;
            }
        }

        if (!flagIn)
            yield return default!;
        else
            yield return lastItem;
    }

    public static bool Aall<T>(this IEnumerable<T> collection, Predicate<T> predicate)
    {
        var flagResult = true;

        foreach (var item in collection)
        {
            if (!predicate(item))
            {
                flagResult = false;
                return flagResult;
            }
        }

        return flagResult;
    }

    public static bool Aany<T>(this IEnumerable<T> collection, Predicate<T> predicate)
    {
        var flagResult = false;

        foreach (var item in collection)
        {
            if (predicate(item))
            {
                flagResult = true;
                return flagResult;
            }
        }

        return false;
    }

    public static IEnumerable<TResult> Seelect<TSource, TResult>(this IEnumerable<TSource> collection, Func<TSource, TResult> selector)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));
        if (selector == null)
            throw new ArgumentNullException(nameof(selector));

        foreach (var item in collection)
        {
            yield return selector(item);
        }
    }

    public static IEnumerable<TResult> SeelectMany<TSource, TResult>(this IEnumerable<TSource> collection, Func<TSource, IEnumerable<TResult>> selector)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));
        if (selector == null)
            throw new ArgumentNullException(nameof(selector));

        foreach (var element in collection)
        {
            foreach (var subElement in selector(element))
            {
                yield return subElement;
            }
        }
    }

    // I used this method to get the second item from the subcollection
    //public static IEnumerable<TResult> SeelectMany<TSource, TResult>(this IEnumerable<TSource> collection, Func<TSource, IEnumerable<TResult>> selector)
    //{
    //    foreach (var element in collection)
    //    {
    //        var subCollection = selector(element);
    //        var enumerator = subCollection.GetEnumerator();
    //        if (enumerator.MoveNext())
    //        {
    //            if (enumerator.MoveNext())
    //            {
    //                yield return enumerator.Current;
    //            }
    //        }
    //    }
    //}

    public static TResult[] ToArray<TSource, TResult>(this IEnumerable<TSource> collection, Func<TSource, TResult>? selector = null)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        if (collection is ICollections<TSource> customCollection)
        {
            // If there is a selector, use it to get a filtered collection
            if (selector != null)
            {
                var filteredCollection = customCollection.Seelect(selector);
                return filteredCollection.ToArray();
            }
            else
            {
                // If there is no selector, use the ToArray method from the interface directly
                if (typeof(TSource) == typeof(TResult))
                {
                    return (TResult[])(object)customCollection.ToArray();
                }

                var resultArray = new TResult[customCollection.Count];
                int index = 0;
                foreach (var item in customCollection)
                {
                    resultArray[index++] = (TResult)(object)item!;
                }
                return resultArray;
            }
        }

        // Standard approach for collections that do not implement ICollections<T>
        IEnumerable<TResult> resultCollection = selector != null
            ? collection.Seelect(selector)
            : collection.Cast<TResult>();

        var resultList = new List<TResult>();

        foreach (var item in resultCollection)
        {
            resultList.Add(item);
        }

        return resultList.ToArray();
    }


    public static List<TResult> ToList<TSource, TResult>(this IEnumerable<TSource> collection, Func<TSource, TResult> selector = null!)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        IEnumerable<TResult> resultCollection;

        if (selector != null)
        {
            resultCollection = collection.Seelect(selector);
        }
        else
        {
            resultCollection = collection.Cast<TResult>();
        }

        var list = new List<TResult>();

        foreach (var item in resultCollection)
        {
            list.Add(item);
        }

        return list;
    }

}
