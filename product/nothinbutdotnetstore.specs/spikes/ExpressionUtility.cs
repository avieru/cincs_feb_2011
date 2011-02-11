using System;
using System.Linq.Expressions;
using System.Reflection;
using Machine.Specifications.DevelopWithPassion.Extensions;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.specs.spikes
{
    public class ExpressionUtility
    {
        public static string name_of_property_on<ElementToInterrogate, PropertyType>(
            Expression<PropertyAccessor<ElementToInterrogate, PropertyType>> accessor)
        {
            return new DefaultExpressionToPropertyNameMapper().map(accessor);
        }

        public static ConstructorInfo constructor_pointed_at_by(Expression<Func<object>> constructor)
        {
            return constructor.Body.downcast_to<NewExpression>().Constructor;
        }
    }
}