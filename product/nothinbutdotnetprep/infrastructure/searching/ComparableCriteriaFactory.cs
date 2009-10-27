using System;

namespace nothinbutdotnetprep.infrastructure.searching
{

    public interface ComparableCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType> where PropertyType : IComparable<PropertyType> {
        Criteria<ItemToFilter> greater_than(PropertyType value);
        Criteria<ItemToFilter> between(PropertyType value1, PropertyType value2);
    }
}