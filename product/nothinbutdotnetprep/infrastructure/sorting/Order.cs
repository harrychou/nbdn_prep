using System;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Order<ItemToOrder>
    {
        static public ComparerFactory<ItemToOrder, PropertyType> by<PropertyType>(Func<ItemToOrder, PropertyType> comparer) where PropertyType : IComparable<PropertyType>
        {
            return new ComparerFactory<ItemToOrder, PropertyType>(comparer);
        }


    }
}