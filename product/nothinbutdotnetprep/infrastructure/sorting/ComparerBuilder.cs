using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ComparerBuilder<ItemToOrder> : IComparer<ItemToOrder>
    {
        IComparer<ItemToOrder> comparer;

        public ComparerBuilder(IComparer<ItemToOrder> comparer)
        {
            this.comparer = comparer;
        }


        public ComparerBuilder<ItemToOrder> then_by_descending<PropertyType>(Func<ItemToOrder, PropertyType> accessor) where PropertyType : IComparable<PropertyType> {

            return then_using(new ReverseComparer<ItemToOrder>(new PropertyComparer<ItemToOrder, PropertyType>(accessor)));
        }

        public ComparerBuilder<ItemToOrder> then_by<PropertyType>(Func<ItemToOrder, PropertyType> accessor,params PropertyType[] values)
        {
            throw new NotImplementedException();
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
    }
}