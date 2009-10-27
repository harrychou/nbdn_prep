using System;

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
}