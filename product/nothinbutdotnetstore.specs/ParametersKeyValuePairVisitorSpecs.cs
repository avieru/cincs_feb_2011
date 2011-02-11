using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.urls;

namespace nothinbutdotnetstore.specs
{
    public class ParametersKeyValuePairVisitorSpecs
    {
        public abstract class concern : Observes<UrlEncoder,
                                            ParametersKeyValuePairVisitor>
        {
            Establish c = () =>
            {
                parameters = new List<KeyValuePair<string, object>>();
                provide_a_basic_sut_constructor_argument(parameters);
            };

            protected static IList<KeyValuePair<string, object>> parameters;
        }

        [Subject(typeof(ParametersKeyValuePairVisitor))]
        public class when_processing_an_item : concern
        {
            Establish c = () => { a_token = new KeyValuePair<string, object>("command_name", "sdfsdfsdfsdfsd"); };

            Because b = () =>
                sut.process(a_token);

            It should_add_it_to_the_list_of_parameters = () =>
                parameters.Count.ShouldEqual(1);

            static KeyValuePair<string, object> a_token;
        }

        public class when_asked_for_the_querystring : concern
        {
            Establish c = () =>
            {
                first_token = new KeyValuePair<string, object>("arg1", "val1");
                second_token = new KeyValuePair<string, object>("arg2", "val2");
                parameters.Add(first_token);
                parameters.Add(second_token);
            };

            Because b = () =>
                result = sut.downcast_to<ParametersKeyValuePairVisitor>().get_result();

            It should_return_a_valid_querystring_string = () =>
                result.ShouldEqual("arg1=val1&arg2=val2");

            static string result;
            static KeyValuePair<string, object> first_token;
            static KeyValuePair<string, object> second_token;
        }
    }
}