using System;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Order<ItemToOrder>
    {
        static public ComparerBuilder<ItemToOrder> by<PropertyType>(Func<ItemToOrder, PropertyType> comparer) where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToOrder>(new PropertyComparer<ItemToOrder, PropertyType>(comparer));
        }
    }
}