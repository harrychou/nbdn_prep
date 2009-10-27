using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class LessThan<PropertyType> : Criteria<PropertyType> where PropertyType : IComparable<PropertyType>
    {
        private readonly PropertyType _value_to_be_less_than;

        public LessThan(PropertyType value_to_be_less_than)
        {
            _value_to_be_less_than = value_to_be_less_than;
        }

        public bool is_satisfied_by(PropertyType item)
        {
            return item.CompareTo(_value_to_be_less_than) < 0;
        }
    }
}