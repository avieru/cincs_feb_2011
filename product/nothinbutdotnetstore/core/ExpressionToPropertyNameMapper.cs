using System.Linq.Expressions;

namespace nothinbutdotnetstore.core
{
    public interface ExpressionToPropertyNameMapper
    {
        string map<TheModel, PropertyType>(Expression<PropertyAccessor<TheModel, PropertyType>> accessor);
    }
}