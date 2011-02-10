using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.core;
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
}
