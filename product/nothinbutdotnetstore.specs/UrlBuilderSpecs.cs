using System;
using System.Linq.Expressions;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

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
                payload = the_dependency<UniqueTokenValueStore>();
                expression_to_property_name_mapper = the_dependency<ExpressionToPropertyNameMapper>();
                provide_a_basic_sut_constructor_argument(the_model);

                the_tokenized_property_name = "sdfsdfsdf";

                expression_to_property_name_mapper.Stub(
                    x => x.map(Arg<Expression<PropertyAccessor<TheModel, int>>>.Is.NotNull)
                    ).Return(the_tokenized_property_name);
            };

            Because b = () =>
                result = sut.with(x => x.id);

            It should_add_the_value_of_the_property_to_the_payload_collection_with_the_correct_key = () =>
                payload.received(x => x.store_token_value(the_tokenized_property_name, the_model.id));

            It should_return_the_builder_to_continue_payload_chaining = () =>
                result.ShouldEqual(sut);
  

            static UniqueTokenValueStore payload;
            static TheModel the_model;
            static ExpressionToPropertyNameMapper expression_to_property_name_mapper;
            static string the_tokenized_property_name;
            static UrlBuilder<OurCommand,TheModel> result;
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