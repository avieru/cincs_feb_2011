using System.Linq.Expressions;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.core
{
    public class DefaultExpressionToPropertyNameMapper : ExpressionToPropertyNameMapper
    {
        public string map<TheModel, PropertyType>(Expression<PropertyAccessor<TheModel, PropertyType>> accessor)
        {
            return ((MemberExpression)accessor.Body).Member.Name;
        }
    }
}