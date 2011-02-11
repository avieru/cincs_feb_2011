using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class RequestCommandSpecs
    {
        public abstract class concern : Observes<RequestCommand,
                                            DefaultRequestCommand>
        {
            Establish c = () => { provide_a_basic_sut_constructor_argument<RequestCriteria>(x => true); };
        }

        [Subject(typeof(DefaultRequestCommand))]
        public class when_determining_if_it_can_process_a_request : concern
        {
            Establish c = () => { request = an<Request>(); };

            Because b = () =>
                result = sut.can_handle(request);

            It should_make_the_determination_by_leveraging_its_request_specification = () =>
                result.ShouldBeTrue();

            static bool result;
            static Request request;
        }

        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                application_command = the_dependency<ApplicationCommand>();
            };

            Because b = () =>
                sut.run(request);

            It should_delegate_the_processing_to_the_application_specific_command = () =>
                application_command.received(x => x.run(request));

            static ApplicationCommand application_command;
            static Request request;
        }
    }
}