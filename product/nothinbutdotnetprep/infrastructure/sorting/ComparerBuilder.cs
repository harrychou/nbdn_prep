using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ComparerBuilder<ItemToOrder> : IComparer<ItemToOrder>, IEnumerable<ItemToOrder>
    {
        IComparer<ItemToOrder> comparer;
        readonly IEnumerable<ItemToOrder> enumerable;

        public ComparerBuilder(IComparer<ItemToOrder> comparer, IEnumerable<ItemToOrder> enumerable)
        {
            this.comparer = comparer;
            this.enumerable = enumerable;
        }


        public ComparerBuilder<ItemToOrder> then_by_descending<PropertyType>(Func<ItemToOrder, PropertyType> accessor) where PropertyType : IComparable<PropertyType> {

            return then_using(new ReverseComparer<ItemToOrder>(new PropertyComparer<ItemToOrder, PropertyType>(accessor)));
        }

        public ComparerBuilder<ItemToOrder> then_by<PropertyType>(
            Func<ItemToOrder, PropertyType> accessor,params PropertyType[] values)
        {
            return then_using(new PropertyListComparer<ItemToOrder, PropertyType>(accessor, values));
        }

        public ComparerBuilder<ItemToOrder> then_by<PropertyType>(Func<ItemToOrder, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return then_using(new PropertyComparer<ItemToOrder, PropertyType>(accessor));
        }


        public ComparerBuilder<ItemToOrder> then_using(IComparer<ItemToOrder> next)
        {
            comparer = new ChainedComparer<ItemToOrder>(comparer, next);
            return this;
        }

        public int Compare(ItemToOrder x, ItemToOrder y)
        {
            return comparer.Compare(x, y);
        }

        public IEnumerator<ItemToOrder> GetEnumerator()
        {
            List<ItemToOrder> result = new List<ItemToOrder>(enumerable);
            result.Sort(this);
            return result.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}