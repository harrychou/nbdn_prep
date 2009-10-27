using System;
using nothinbutdotnetprep.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class DefaultComparableCriteriaFactory<ItemToFilter, PropertyType> : ComparableCriteriaFactory<ItemToFilter, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;
        CriteriaFactory<ItemToFilter, PropertyType> regular_criteria_factory;

        public DefaultComparableCriteriaFactory(Func<ItemToFilter, PropertyType> accessor, CriteriaFactory<ItemToFilter, PropertyType> regular_criteria_factory)
        {
            this.accessor = accessor;
            this.regular_criteria_factory = regular_criteria_factory;
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return regular_criteria_factory.equal_to_any(values);
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return regular_criteria_factory.equal_to(value);
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
                                                                    new GreaterThan<PropertyType>(value));
        }

        public Criteria<ItemToFilter> between(PropertyType value1, PropertyType value2)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(
                accessor, new FallsInRange<PropertyType>(new InclusiveRange<PropertyType>(value1, value2)));
        }
    }
}