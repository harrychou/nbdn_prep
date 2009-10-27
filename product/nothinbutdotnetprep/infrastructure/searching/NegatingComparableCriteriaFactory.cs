using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NegatingComparableCriteriaFactory<ItemToFilter, PropertyType> : ComparableCriteriaFactory<ItemToFilter, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        ComparableCriteriaFactory<ItemToFilter, PropertyType> comparable_criteria_factory;
        CriteriaFactory<ItemToFilter, PropertyType> basic_negating_factory;

        public NegatingComparableCriteriaFactory(ComparableCriteriaFactory<ItemToFilter, PropertyType> comparable_criteria_factory):this(comparable_criteria_factory, 
            new NegatingBasicCriteriaFactory<ItemToFilter, PropertyType>(comparable_criteria_factory))
        {
        }

        public NegatingComparableCriteriaFactory(ComparableCriteriaFactory<ItemToFilter, PropertyType> comparable_criteria_factory, CriteriaFactory<ItemToFilter, PropertyType> basic_negating_factory)
        {
            this.comparable_criteria_factory = comparable_criteria_factory;
            this.basic_negating_factory = basic_negating_factory;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return basic_negating_factory.equal_to(value);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return basic_negating_factory.equal_to_any(values);
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return new NegatingCriteria<ItemToFilter>(comparable_criteria_factory.greater_than(value));
        }

        public Criteria<ItemToFilter> between(PropertyType value1, PropertyType value2)
        {
            return new NegatingCriteria<ItemToFilter>(comparable_criteria_factory.between(value1, value2));
        }
    }
}