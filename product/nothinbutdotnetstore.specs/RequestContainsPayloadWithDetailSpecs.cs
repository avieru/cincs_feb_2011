using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.core;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class RequestContainsPayloadWithDetailSpecs
    {
        public abstract class concern : Observes<Criteria<Request>,
                                            RequestContainsPayloadWithDetail<SomeItemWithData>>
        {
        }

        [Subject(typeof(RequestContainsPayloadWithDetail<>))]
        public class when_determining_if_it_matches_the_request : concern
        {
            Establish c = () =>
            {
                input_model = new SomeItemWithData {has_products = true};
                request = an<Request>();
                request.Stub(x => x.map<SomeItemWithData>()).Return(input_model);

                provide_a_basic_sut_constructor_argument<Func<SomeItemWithData, bool>>(x => x.has_products);
            };

            Because b = () =>
                result = sut.is_satisfied_by(request);

            It should_match_if_an_item_in_the_payload_meets_the_condition = () =>
                result.ShouldBeTrue();

            static bool result;
            static Request request;
            static SomeItemWithData input_model;
        }
    }

    public class SomeItemWithData
    {
        public bool has_products { get; set; }
    }
}