using System.Collections.Generic;
using System.Text;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class UrlEncodingKeyValuePairVisitorSpecs
    {
        public abstract class concern : Observes<UrlEncodingKeyValuePairVisitor>
        {
            Establish c = () =>
            {
                builder = new StringBuilder();
                provide_a_basic_sut_constructor_argument(builder);
            };

            protected static StringBuilder builder;
        }

        [Subject(typeof(UrlEncodingKeyValuePairVisitor))]
        public class when_processing_the_first_key_value_pair : concern
        {
            Establish c = () =>
            {
                command_name = "our_command";
                first_token = new KeyValuePair<string, object>("command_name", command_name);
            };

            Because b = () =>
                sut.process(first_token);

            It should_append_the_name_of_the_command_to_the_builder_with_the_appropriate_handler_suffix = () =>
                sut.command_name.ShouldEqual(command_name);

            static KeyValuePair<string, object> first_token;
            static string command_name;
        }

        public class when_processing_subsequent_items : concern
        {
            Establish c = () =>
            {
                new_key_pair = new KeyValuePair<string, object>("somekey", 23);
                add_pipeline_behaviour_against_sut(x => x.process(new KeyValuePair<string, object>("sdf", 243)));
            };

            Because b = () => { sut.process(new_key_pair); };

            It should_append_the_key_value_pair_to_the_string_builder = () =>
                builder.ToString().ShouldEqual("&{0}={1}".format_using(new_key_pair.Key, new_key_pair.Value.ToString()));

            static KeyValuePair<string, object> new_key_pair;
        }

        public class when_accessing_the_result_of_visiting_a_single_pair : concern
        {
            Establish c = () =>
            {
                command_name = "Command";
                add_pipeline_behaviour_against_sut(
                    x => x.process(new KeyValuePair<string, object>("ignored", command_name)));
            };

            Because b = () => { result = sut.get_url(); };

            It should_return_the_name_of_the_command_suffixed_with_the_handler_token = () =>
                result.ShouldBeEqualIgnoringCase("{0}.cinc".format_using(command_name));

            static KeyValuePair<string, object> new_key_pair;
            static string result;
            static string command_name;
        }

        public class when_accessing_the_result_of_visiting_multiple_key_value_pairs : concern
        {
            Establish c = () =>
            {
                command_name = "Command";
                first = new KeyValuePair<string, object>("first_key",24);
                second = new KeyValuePair<string, object>("second_key",27);

                add_pipeline_behaviour_against_sut(
                    x => x.process(new KeyValuePair<string, object>("ignored", command_name)));

                add_pipeline_behaviour_against_sut(
                    x => x.process(first));
                add_pipeline_behaviour_against_sut(
                    x => x.process(second));
            };

            Because b = () => 
                result = sut.get_url();

            It should_return_the_name_of_the_command_suffixed_with_the_handler_token = () =>
                result.ShouldBeEqualIgnoringCase("{0}.cinc?{1}={2}&{3}={4}".format_using(command_name,
                first.Key,first.Value.ToString(),second.Key,second.Value.ToString()));

            static string result;
            static string command_name;
            static KeyValuePair<string,object> first;
            static KeyValuePair<string,object> second;
        }
    }
}