using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class BasicCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;

        public BasicCriteriaFactory(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(
                   accessor,
                   new EqualityCriteria<PropertyType>(value));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(
                   accessor,
                   new ExistsCriteria<PropertyType>(values));
        }
    }

    public class ExistsCriteria<PropertyType> : Criteria<PropertyType>
    {
        PropertyType[] values;
        public ExistsCriteria(PropertyType[] value)
        {
            values = value;
        }

        public bool is_satisfied_by(PropertyType item)
        {
            return Array.Exists(values, (value) => item.Equals(value));
        }
    }

    public class EqualityCriteria<PropertyType> : Criteria<PropertyType>
    {
            PropertyType value;
            public EqualityCriteria(PropertyType value)
            {
                this.value = value;
            }

            public bool is_satisfied_by(PropertyType item)
            {
                return item.Equals(value);
            }
    }
}