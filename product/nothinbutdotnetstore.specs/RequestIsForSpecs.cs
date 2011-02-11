using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;
using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs
{
    public class RequestIsForSpecs
    {
        public abstract class concern : Observes<RequestIsFor<TheCommand>>
        {
        }

        [Subject(typeof(RequestCriteria))]
        public class when_matching_an_incoming_request : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                request.Stub(x => x.raw_url).Return("{0}.cinc?sdfsdfsdf".format_using(typeof(TheCommand).Name));
            };

            Because b = () =>
                result = sut.is_satisfied_by(request);

            It should_match_the_request_if_the_incoming_request_is_for_the_command_it_expects = () =>
                result.ShouldBeTrue();

            static bool result;
            static Request request;
        }

        public class TheCommand : ApplicationCommand
        {
            public void run(Request request)
            {
                throw new NotImplementedException();
            }
        }
    }
}