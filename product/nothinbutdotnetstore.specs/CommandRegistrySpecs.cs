using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class CommandRegistrySpecs
    {
        public abstract class concern : Observes<CommandRegistry,
                                            DefaultCommandRegistry>
        {
        }

        [Subject(typeof(DefaultCommandRegistry))]
        public class when_finding_a_command_that_can_process_a_request_and_it_has_the_command : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                all_commands = Enumerable.Range(1, 100).Select(x => an<RequestCommand>()).ToList();
                the_command_that_can_handle_the_request = an<RequestCommand>();
                all_commands.Add(the_command_that_can_handle_the_request);

                the_command_that_can_handle_the_request.Stub(x => x.can_handle(request))
                    .Return(true);

                provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(all_commands);
            };

            Because b = () =>
                result = sut.get_the_command_that_can_process(request);

            It should_return_the_command_that_can_process_the_request = () =>
                result.ShouldEqual(the_command_that_can_handle_the_request);

            static RequestCommand result;
            static RequestCommand the_command_that_can_handle_the_request;
            static Request request;
            static IList<RequestCommand> all_commands;
        }
    }
}