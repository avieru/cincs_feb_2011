using System.Linq.Expressions;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.specs.spikes
{
    public class ExpressionUtility
    {
        public static string name_of_property_on<ElementToInterrogate,PropertyType>(Expression<PropertyAccessor<ElementToInterrogate, PropertyType>> accessor)
        {
            return new DefaultExpressionToPropertyNameMapper().map(accessor);
        }
    }
}