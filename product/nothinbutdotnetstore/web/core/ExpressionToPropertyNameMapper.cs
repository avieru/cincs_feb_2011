using System.Linq.Expressions;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core
{
    public interface ExpressionToPropertyNameMapper
    {
        string map<TheModel,PropertyType>(Expression<PropertyAccessor<TheModel,PropertyType>> accessor);
    }
}