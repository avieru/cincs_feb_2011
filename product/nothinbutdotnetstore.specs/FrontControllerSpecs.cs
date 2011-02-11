using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class FrontControllerSpecs
    {
        public abstract class concern : Observes<FrontController,
                                            DefaultFrontController>
        {
        }

        [Subject(typeof(DefaultFrontController))]
        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                command_that_can_process = an<RequestCommand>();
                command_registry = the_dependency<CommandRegistry>();

                command_registry.Stub(x => x.get_the_command_that_can_process(request))
                    .Return(command_that_can_process);
            };

            Because b = () =>
                sut.process(request);

            It should_delegate_the_processing_to_the_command_that_can_process_the_request = () =>
                command_that_can_process.received(x => x.run(request));

            static RequestCommand command_that_can_process;
            static Request request;
            static CommandRegistry command_registry;
        }
    }
}