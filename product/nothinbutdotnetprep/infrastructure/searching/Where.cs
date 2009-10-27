using System;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToFilter>
    {
        static public CriteriaFactory<ItemToFilter, PropertyType> has_a<PropertyType>(Func<ItemToFilter, PropertyType> accessor)
        {
            return new DefaultCriteriaFactory<ItemToFilter, PropertyType>(accessor);
        }

        static public ComparableCriteriaFactory<ItemToFilter, PropertyType> has_an<PropertyType>(Func<ItemToFilter, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new DefaultComparableCriteriaFactory<ItemToFilter, PropertyType>(accessor,
                new DefaultCriteriaFactory<ItemToFilter, PropertyType>(accessor));
        }

        static public CriteriaFactory<ItemToFilter, PropertyType> does_not_have_a<PropertyType>(Func<ItemToFilter, PropertyType> accessor)
        {
            return new NegatingBasicCriteriaFactory<ItemToFilter, PropertyType>(
                has_a(accessor));
        }

        static public ComparableCriteriaFactory<ItemToFilter, PropertyType> does_not_have_an<PropertyType>(Func<ItemToFilter, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new NegatingComparableCriteriaFactory<ItemToFilter, PropertyType>(
                has_an(accessor));
        }

    }

    public class Order<ItemToOrder>
    {

        static public ComparerFactory<ItemToOrder, PropertyType> by<PropertyType>(Func<ItemToOrder, PropertyType> comparer) where PropertyType : IComparable<PropertyType>
        {
            return new ComparerFactory<ItemToOrder, PropertyType>(comparer);
        }


    }

    public class ComparerFactory<ItemToOrder, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        readonly Func<ItemToOrder, PropertyType> _comparer;

        public ComparerFactory(Func<ItemToOrder, PropertyType> comparer)
        {
            _comparer = comparer;
        }

        public IComparer<ItemToOrder> descend()
        {
            return new DescendingPropertyComparer<ItemToOrder, PropertyType>(_comparer);
        }

        public IComparer<ItemToOrder> ascend()
        {
            return new AscendingPropertyComparer<ItemToOrder, PropertyType>(_comparer);
        }
    }

    public class AscendingPropertyComparer<ItemToOrder, PropertyType> : IComparer<ItemToOrder> where PropertyType : IComparable<PropertyType>
    {
        readonly Func<ItemToOrder, PropertyType> _comparer;

        public AscendingPropertyComparer(Func<ItemToOrder, PropertyType> comparer)
        {
            _comparer = comparer;
        }

        public int Compare(ItemToOrder x, ItemToOrder y)
        {
            return _comparer(x).CompareTo(_comparer(y));
        }
    }

    public class DescendingPropertyComparer<ItemToOrder, PropertyType> : IComparer<ItemToOrder> where PropertyType : IComparable<PropertyType>
    {
        readonly Func<ItemToOrder, PropertyType> _comparer;

        public DescendingPropertyComparer(Func<ItemToOrder, PropertyType> comparer)
        {
            _comparer = comparer;
        }

        public int Compare(ItemToOrder x, ItemToOrder y)
        {
            return _comparer(y).CompareTo(_comparer(x));
        }
    }
}