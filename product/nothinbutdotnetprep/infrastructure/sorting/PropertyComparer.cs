using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class PropertyComparer<ItemToOrder, PropertyType> : IComparer<ItemToOrder> where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToOrder, PropertyType> accessor;

        public PropertyComparer(Func<ItemToOrder, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public int Compare(ItemToOrder x, ItemToOrder y)
        {
            return accessor(x).CompareTo(accessor(y));
        }
    }
}