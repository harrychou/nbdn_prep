using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public static class SearchingExtensions
    {
        public static ComparerBuilder<ItemToSort> order_by<ItemToSort, PropertyType>(
            this IEnumerable<ItemToSort> items,
                                                                Func<ItemToSort,PropertyType> accessor,
            params PropertyType[] values)
        {
            IComparer<ItemToSort> comparer = new PropertyListComparer<ItemToSort, PropertyType>(accessor, values);
            return new ComparerBuilder<ItemToSort>(comparer, items);
        }


        public static ComparerBuilder<ItemToSort> order_with<ItemToSort>(this IEnumerable<ItemToSort> items,
                                                                IComparer<ItemToSort> comparer)
        {
            return new ComparerBuilder<ItemToSort>(comparer, items);
        }


        public static ComparerBuilder<ItemToSort> order_by_descending<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> items,
                                                                Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(
                new ReverseComparer<ItemToSort>(
                new PropertyComparer<ItemToSort, PropertyType>(accessor)), items);
        }


        public static ComparerBuilder<ItemToSort> order_by<ItemToSort, PropertyType>(
            this IEnumerable<ItemToSort> items, Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(new PropertyComparer<ItemToSort, PropertyType>(accessor), items);
        }
    }

    public class PropertyListComparer<ItemToSort, PropertyType>: IComparer<ItemToSort>
    {
        readonly Func<ItemToSort, PropertyType> _accessor;
        readonly List<PropertyType> _values;

        public PropertyListComparer(Func<ItemToSort,PropertyType> accessor, PropertyType[] values)
        {
            _accessor = accessor;
            _values = new List<PropertyType>(values);
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return _values.IndexOf(_accessor(x)).CompareTo(_values.IndexOf(_accessor(y)));
        }
    }

}