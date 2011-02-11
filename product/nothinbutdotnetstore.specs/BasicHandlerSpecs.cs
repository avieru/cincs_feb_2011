using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class BasicHandlerSpecs
    {
        public abstract class concern : Observes<IHttpHandler,
                                            BasicHandler>
        {
        }

        [Subject(typeof(BasicHandler))]
        public class when_processing_an_incoming_http_context : concern
        {
            Establish c = () =>
            {
                request_factory = the_dependency<RequestFactory>();
                front_controller = the_dependency<FrontController>();
                the_current_context = ObjectFactory.create_http_context();
                request = an<Request>();

                request_factory.Stub(x => x.create_request_from(the_current_context)).Return(
                    request);
            };

            Because b = () =>
                sut.ProcessRequest(the_current_context);

            It should_delegate_processing_to_the_front_controller = () =>
                front_controller.received(x => x.process(request));

            static FrontController front_controller;
            static Request request;
            static HttpContext the_current_context;
            static RequestFactory request_factory;
        }
    }
}