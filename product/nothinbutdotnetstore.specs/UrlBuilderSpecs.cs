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
            Establish c = () =>
            {
                the_model = new TheModel();
                payload = the_dependency<UniqueTokenValueStore>();
                expression_to_property_name_mapper = the_dependency<ExpressionToPropertyNameMapper>();
                provide_a_basic_sut_constructor_argument(the_model);
            };

            public static UniqueTokenValueStore payload;
            protected static ExpressionToPropertyNameMapper expression_to_property_name_mapper;
            protected static TheModel the_model;
        }

        [Subject(typeof(UrlBuilder<,>))]
        public class when_provided_a_property_to_include_in_the_payload : concern
        {
            Establish c = () =>
            {
                the_model.id = 23;
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
  

            static string the_tokenized_property_name;
            static UrlBuilder<OurCommand,TheModel> result;
        }


        [Subject(typeof(UrlBuilder<,>))]
        public class when_asked_to_render_itself_as_string : concern
        {
            Establish c = () =>
            {
                the_model.id = 1;
                the_model.name="something";
                payload.Stub(x => x.UnrollAsString()).Return(string.Empty);
            };

            Because b = () =>
                result = sut.ToString();

            It should_be_apparent_that_payload_unload_was_called = () =>
                payload.received(x => x.UnrollAsString());

            It should_look_right_like_below = () =>
                result.ShouldBeAn<string>();

             static string result;
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
            public string name;
            public int id { get; set; }
        }
    }
}