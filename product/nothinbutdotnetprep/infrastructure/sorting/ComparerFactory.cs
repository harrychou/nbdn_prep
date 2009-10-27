using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ComparerFactory<ItemToOrder, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToOrder, PropertyType> accesor;

        public ComparerFactory(Func<ItemToOrder, PropertyType> accesor)
        {
            this.accesor = accesor;
        }

        public IComparer<ItemToOrder> descending()
        {
            return new ReverseComparer<ItemToOrder>(ascending());
        }

        public IComparer<ItemToOrder> ascending()
        {
            return new PropertyComparer<ItemToOrder, PropertyType>(accesor);
        }
    }
}