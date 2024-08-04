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

    public static IEnumerable<T> Fiirst<T>(this IEnumerable<T> collection, Predicate<T> predicate)
    {
        if(collection == null)
            throw new NullReferenceException();

        var flagIn = false;

        foreach (var item in collection)
        {
            if(predicate(item))
            {
                flagIn = true;
                yield return item;
                yield break;
            }
        }

        if(!flagIn)
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

    public static IEnumerable<T> Laast<T>(this IEnumerable<T> collection, Predicate<T> predicate)
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
            yield return lastItem;
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

    public static IEnumerable<bool> Aall<T>(this IEnumerable<T> collection, Predicate<T> predicate)
    {
        var flagResult = true;

        foreach (var item in collection)
        {
            if (!predicate(item))
            {
                flagResult = false;
                yield return flagResult;
                yield break;
            }
        }

        if(flagResult)
            yield return true;

    }

    public static IEnumerable<bool> Aany<T>(this IEnumerable<T> collection, Predicate<T> predicate)
    {
        var flagResult = false;

        foreach (var item in collection)
        {
            if (predicate(item))
            {
                flagResult = true;
                yield return flagResult;
                yield break;
            }
        }

        if(!flagResult)
            yield return false;
    }

    public static IEnumerable<TResult> Seelect<TSource, TResult>(this IEnumerable<TSource> collection, Func<TSource, TResult> selector)
    {
        foreach (var item in collection)
        {
            yield return selector(item);
        }
    }

    public static IEnumerable<TResult> SeelectMany<TSource, TResult>(this IEnumerable<TSource> collection, Func<TSource, IEnumerable<TResult>> selector)
    {
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

    public static TResult[] ToArray<TSource,TResult>(this IEnumerable<TSource> collection, Func<TSource, TResult> selector)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));
        if (selector == null)
            throw new ArgumentNullException(nameof(selector));

        var resultList = new List<TResult>();

        foreach (var item in collection)
        {
            resultList.Add(selector(item));
        }

        return resultList.ToArray();
    }

    public static List<TResult> ToList<TSource, TResult>(this IEnumerable<TSource> collection, Func<TSource, TResult> selector)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));
        if (selector == null)
            throw new ArgumentNullException(nameof(selector));

        var list = new List<TResult>();

        foreach (var item in collection)
        {
            list.Add(selector(item));
        }

        return list;
    }
}
