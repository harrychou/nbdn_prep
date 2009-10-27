using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure.extensions
{
    static public class Iteration
    {
        static public IEnumerable<T> sort_movie<T>(this IEnumerable<T> items, IComparer<T> comparer)
        {
            var result = new List<T>(items);
            result.Sort(comparer);
            return result;
        }

        static public IEnumerable<T> all_matching<T>(this IEnumerable<T> items,
                                                     Criteria<T> criteria)
        {
            foreach (var item in items)
            {
                if (criteria.is_satisfied_by(item)) yield return item;
            }
        }

        static public IEnumerable<T> all_matching<T>(this IEnumerable<T> items,
                                                     Predicate<T> criteria)
        {
            return all_matching(items, new AnonymousCriteria<T>(criteria));
        }

        static public IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items) yield return item;
        }

        static public void each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items) action(item);
        }

        static public IEnumerable<int> to(this int start, int end)
        {
            for (var i = start; i <= end; i++) yield return i;
        }
    }
}