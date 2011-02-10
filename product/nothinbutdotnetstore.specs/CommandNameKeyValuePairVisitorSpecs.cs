using System.Collections.Generic;
using System.Linq;
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
        public class when_processing_the_first_key_value_pair : concern
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

        public class when_processing_subsequent_items : concern
        {
            Establish c = () =>
            {
                first = new KeyValuePair<string, object>("somekey", 23);
                ignore = new KeyValuePair<string, object>("ignored", "ignored");
            };

            Because b = () =>
            {
                sut.process(first);

                sut.process(ignore);
            };

            It should_ignore_them = () =>
                sut.downcast_to<CommandNameKeyValuePairVisitor>().command_name.ShouldEqual(first.Value.ToString());

            static KeyValuePair<string, object> first;
            static KeyValuePair<string, object> ignore;
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

        public class when_visiting_a_set_of_items : Observes<Visitor<KeyValuePair<string, object>>,
                                                        ChainedVisitor<KeyValuePair<string, object>>>
        {
            Establish c = () =>
            {
                first_visitor = new CommandNameKeyValuePairVisitor();
                other_parameters = new List<KeyValuePair<string, object>>();
                second_visitor = new ParametersKeyValuePairVisitor(other_parameters);

                create_sut_using(() => new ChainedVisitor<KeyValuePair<string, object>>(
                                     first_visitor,
                                     second_visitor));

                items = Enumerable.Range(1, 100).Select(x => new KeyValuePair<string, object>(x.ToString("key0"),
                                                                                              x));
            };

            Because b = () => { items.each(sut.process); };

            It should_build_the_correct_url = () =>
            {
                first_visitor.command_name.ShouldEqual("1");
                other_parameters.Count.ShouldEqual(99);
            };

            static IEnumerable<KeyValuePair<string, object>> items;
            static CommandNameKeyValuePairVisitor first_visitor;
            static ParametersKeyValuePairVisitor second_visitor;
            static List<KeyValuePair<string, object>> other_parameters;
        }
    }
}