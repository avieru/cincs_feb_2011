using System.Linq.Expressions;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Extensions;
 using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class ExpressionToPropertyMapperSpecs
    {
        public abstract class concern : Observes<ExpressionToPropertyNameMapper,
                                            DefaultExpressionToPropertyNameMapper>
        {
        
        }

        [Subject(typeof(DefaultExpressionToPropertyNameMapper))]
        public class when_mapping_a_property_name_with_expression : concern
        {
            Because b = () =>
                result = sut.map<TheirModel, string>(x => x.Name);

            It should_return_property_name = () =>
                result.ShouldEqual("Name");

            static string result;
                
        }
    }

    class TheirModel
    {
        public string Name { get; set; }
    }

    public class DefaultExpressionToPropertyNameMapper : ExpressionToPropertyNameMapper
    {
        public string map<TheModel, PropertyType>(Expression<PropertyAccessor<TheModel, PropertyType>> accessor)
        {
            return new ExpressionPropertyToStringConverter<TheModel,PropertyType>(accessor).ToString();// ExpressionUtility.name_of_property_on<TheModel, PropertyType>(accessor);
        }
    }

    public class ExpressionPropertyToStringConverter<TheModel, PropertyType>
    {
        string property_name_as_string;

        public ExpressionPropertyToStringConverter(Expression<PropertyAccessor<TheModel, PropertyType>> accessor)
        {
            property_name_as_string = accessor.Body.downcast_to<MemberExpression>().Member.Name;
        }

        public override string ToString()
        {
            return property_name_as_string;
        }
    }
}
