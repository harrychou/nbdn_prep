
namespace nothinbutdotnetprep.infrastructure.searching
{
    public class EqualTo<PropertyType> : Criteria<PropertyType>
    {
        PropertyType value_to_be_equal_to;

        public EqualTo(PropertyType value_to_be_equal_to)
        {
            this.value_to_be_equal_to = value_to_be_equal_to;
        }

        public bool is_satisfied_by(PropertyType item)
        {
            return item.Equals(value_to_be_equal_to);
        }
    }
}