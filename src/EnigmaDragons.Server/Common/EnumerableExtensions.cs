using System;
using System.Collections.Generic;
using System.Linq;

namespace EnigmaDragons
{
    public static class EnumerableExtensions
    {
        public static List<T> AsList<T>(this T item) => new List<T>(1) { item };
                
        public static TItem Added<TCollectionItem, TItem>(this List<TCollectionItem> list, TItem item)
            where TItem : TCollectionItem
        {
            list.Add(item);
            return item;
        }

        public static IReadOnlyCollection<T> Append<T>(this IReadOnlyCollection<T> items, T item)
        {
            return items.Concat(item.AsList()).ToList();
        }
        
        public static void ForEach<T>(this IEnumerable<T> c, Action<T> action) => c.ToList().ForEach(action);

        public static void ForEachIndex<T>(this IEnumerable<T> c, Action<T, int> indexAction)
        {
            var coll = c.ToList();
            for (var i = 0; i < coll.Count; i++)
                indexAction(coll[i], i);
        }
        
        public static IEnumerable<T> Preferred<T>(this IEnumerable<T> c, Func<T, bool> isPreferred) => Preferred(c.ToList(), isPreferred);
        public static IEnumerable<T> Preferred<T>(this ICollection<T> c, Func<T, bool> isPreferred)
        {
            return c.Any(isPreferred) 
                ? c.Where(isPreferred) 
                : c;
        }
    }
}
