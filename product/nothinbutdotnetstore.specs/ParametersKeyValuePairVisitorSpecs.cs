using System.Collections;
using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.core;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class ParametersKeyValuePairVisitorSpecs
    {
        public abstract class concern : Observes<Visitor<KeyValuePair<string, object>>,
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
        public class when_processing_the_first_keypair: concern
        {
            Establish c = () =>
            {
                ignored_token = new KeyValuePair<string, object>("command_name", "sdfsdfsdfsdfsd");
            };

            Because b = () =>
                sut.process(ignored_token);

            It should_ignore_it = () =>
                parameters.Count.ShouldEqual(0);


            static KeyValuePair<string, object> ignored_token;
        }

        public class when_processing_subsequent_keypairs: concern
        {
            Establish c = () =>
            {
                first_token = new KeyValuePair<string, object>("command_name", "sdfsdf");
                second_token = new KeyValuePair<string, object>("arg1", "duh");
                parameters.Add(first_token);
            };

            Because b = () =>
            {
                sut.process(second_token);
            };

            It should_store_the_key_pairs_for_later_processing = () =>
                parameters.Count.ShouldEqual(2);


            static KeyValuePair<string, object> first_token;
            static KeyValuePair<string, object> second_token;
        }

        public class when_asked_for_the_querystring: concern
        {
            Establish c = () =>
            {
                first_token = new KeyValuePair<string, object>("arg1", "val1");
                second_token = new KeyValuePair<string, object>("arg2", "val2");
                parameters.Add(first_token);
                parameters.Add(second_token);
            };

            Because b = () =>
                result = sut.downcast_to<ParametersKeyValuePairVisitor>().get_query_string();

            It should_return_a_valid_querystring_string = () =>
                result.ShouldEqual("arg1=val1&arg2=val2");

            static string result;
            static KeyValuePair<string, object> first_token;
            static KeyValuePair<string, object> second_token;
        }
    }
}