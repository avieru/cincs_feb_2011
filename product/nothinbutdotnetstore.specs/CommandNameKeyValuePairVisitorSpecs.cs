using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.core;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class CommandNameKeyValuePairVisitorSpecs
    {
        public abstract class concern : Observes<Visitor<KeyValuePair<string, object>>,
                                            CommandNameKeyValuePairVisitor>
        {
        }

        [Subject(typeof(CommandNameKeyValuePairVisitor))]
        public class when_processing_an_item : concern
        {
            Establish c = () =>
            {
                command_name = "our_command";
                first_token = new KeyValuePair<string, object>("command_name", command_name);
            };

            Because b = () =>
                sut.process(first_token);

            It should_store_the_name_of_the_command_to_run = () =>
                sut.downcast_to<CommandNameKeyValuePairVisitor>().command_name.ShouldEqual(command_name);

            static KeyValuePair<string, object> first_token;
            static string command_name;
        }

        public class when_getting_its_url : concern
        {
            Establish c = () => { command_name = "Command"; };

            Because b = () =>
            {
                //setup
                sut.process(new KeyValuePair<string, object>("ignored", command_name));

                result = sut.downcast_to<ParametersKeyValuePairVisitor>().get_query_string();
            };

            It should_return_the_name_of_the_command_suffixed_with_the_handler_token = () =>
                result.ShouldBeEqualIgnoringCase("{0}.cinc?".format_using(command_name));

            static string result;
            static string command_name;
        }
    }
}