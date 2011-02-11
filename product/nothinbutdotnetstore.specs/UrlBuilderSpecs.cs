using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.core;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.urls;
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

        public class when_created : concern
        {
            It should_add_the_name_of_the_command_to_the_token_value_store = () =>
                payload.received(
                    x => x.store_token_value(UrlBuilder<OurCommand, TheModel>.command_key, typeof(OurCommand).Name));

            static string the_tokenized_property_name;
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
                result.Equals(sut).ShouldBeTrue();

            static string the_tokenized_property_name;
            static UrlBuilder<OurCommand, TheModel> result;
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

        public class when_implicitly_converted_to_a_string : concern
        {
            Establish c = () =>
            {
                var model = new TheModel();
                to_string_visitor = the_dependency<UrlEncoder>();
                items = new List<KeyValuePair<string, object>>();
                payload.Stub(x => x.GetEnumerator()).Return(items.GetEnumerator());
                model.name = "val1";
                well_formed_url_built_by_visitor = "sdfsfsdfsdf";

                to_string_visitor.Stub(x => x.get_result()).Return(well_formed_url_built_by_visitor);
            };

            Because b = () => { result = sut; };

            It should_return_the_result_of_the_visitor_that_can_process_it = () =>
                result.ShouldEqual(well_formed_url_built_by_visitor);

            static string result;
            static string well_formed_url_built_by_visitor;
            static UrlEncoder to_string_visitor;
            static IEnumerable<KeyValuePair<string, object>> items;
        }

        [Subject(typeof(UrlBuilder<,>))]
        public class when_being_represented_as_a_string : concern
        {
            Establish c = () =>
            {
                var model = new TheModel();
                to_string_visitor = the_dependency<UrlEncoder>();
                items = new List<KeyValuePair<string, object>>();
                payload.Stub(x => x.GetEnumerator()).Return(items.GetEnumerator());
                model.name = "val1";
                well_formed_url_built_by_visitor = "sdfsfsdfsdf";

                to_string_visitor.Stub(x => x.get_result()).Return(well_formed_url_built_by_visitor);
            };

            Because b = () => { result = sut.ToString(); };

            It should_return_the_result_of_the_visitor_that_can_process_it = () =>
                result.ShouldEqual(well_formed_url_built_by_visitor);

            static string result;
            static string well_formed_url_built_by_visitor;
            static UrlEncoder to_string_visitor;
            static IEnumerable<KeyValuePair<string, object>> items;
        }
    }
}