using System;
using System.Collections.Specialized;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class UrlBuilderSpecs
    {
        public abstract class concern : Observes<UrlBuilder<OurCommand, TheModel>>
        {
        }

        [Subject(typeof(UrlBuilder<,>))]
        public class when_provided_a_property_to_include_in_the_payload : concern
        {
            Establish c = () =>
            {
                the_model = new TheModel();
                the_model.id = 23;
                payload = new NameValueCollection();
                provide_a_basic_sut_constructor_argument(the_model);
                provide_a_basic_sut_constructor_argument(payload);
            };

            Because b = () =>
                sut.with(x => x.id);

            It should_add_the_value_of_the_property_to_the_payload_collection = () =>
                payload["id"].ShouldEqual(the_model.id.ToString());

            static NameValueCollection payload;
            static TheModel the_model;
        }

        public class OurCommand : ApplicationCommand
        {
            public void run(Request request)
            {
                throw new NotImplementedException();
            }
        }

        public class TheModel
        {
            public int id { get; set; }
        }
    }
}