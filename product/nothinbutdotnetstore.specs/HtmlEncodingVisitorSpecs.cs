 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.core;
 using nothinbutdotnetstore.web.core;
 using nothinbutdotnetstore.web.core.urls;

namespace nothinbutdotnetstore.specs
{   
    public class HtmlEncodingVisitorSpecs
    {
        public abstract class concern : Observes<Visitor<KeyValuePair<string, object>>>,
                                            HtmlEncodingVisitor>
        {
        
        }

        [Subject(typeof(HtmlEncodingVisitor))]
        public class when_getting_a_result : concern
        {
            Establish c = () =>
            {
                the_child = new ParametersKeyValuePairVisitor(new List<KeyValuePair<string, object>>());
                provide_a_basic_sut_constructor_argument(the_child);
            };

            Because b = () =>
                result = sut.get_result();

            It encodes_the_value_properly = () =>
            {
                result.ShouldEqual(a_proper_string_value);
                the_child.received(x => x.get_result());
            };
                
               
            static string result;
            static string a_proper_string_value;
            static KeyValuePair<string, object> the_key_value_pair;
            static ParametersKeyValuePairVisitor the_child;
        }

        [Subject(typeof(HtmlEncodingVisitor))]
        public class when_visiting : concern
        {
            
        }
    }
}
