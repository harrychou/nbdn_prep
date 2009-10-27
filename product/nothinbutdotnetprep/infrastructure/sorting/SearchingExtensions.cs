using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public static class SearchingExtensions
    {
        public static object order_by<ItemToSort,PropertyType>(this IEnumerable<ItemToSort> items,
                                                                Func<ItemToSort,PropertyType> accessor,
            params PropertyType[] values){

        }
        public static object order_with<ItemToSort>(this IEnumerable<ItemToSort> items,
                                                                IComparer<ItemToSort> comparer){

        }
        public static object order_by_descending<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> items,
                                                                Func<ItemToSort, PropertyType> accessor){

        }
        public static object order_by<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> items,
                                                                Func<ItemToSort, PropertyType> accessor){

        }
    }
}