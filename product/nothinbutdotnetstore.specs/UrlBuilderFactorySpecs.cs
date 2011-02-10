using System;
using System.Collections;
using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.core;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.urls;

namespace nothinbutdotnetstore.specs
{
    public class UrlBuilderFactorySpecs
    {
        public abstract class concern : Observes<UrlBuilderFactory<CommandToRun>>
        {
        }

        public class when_creating_a_url_builder : concern
        {
            Establish c = () =>
            {
                token_store = new FakeStore();
                provide_a_basic_sut_constructor_argument<TokenStoreFactory>(() => token_store);
                the_mapper = the_dependency<ExpressionToPropertyNameMapper>();
                the_model = new NotTheirModel();
            };

            Because b = () =>
                result = sut.For(the_model);

            It should_create_a_url_builder_with_the_appropriate_information = () =>
            {
                var item = result.ShouldBeAn<UrlBuilder<CommandToRun, NotTheirModel>>();
                item.model.ShouldEqual(the_model);
                item.payload.ShouldEqual(token_store);
                item.expression_to_property_name_mapper.ShouldEqual(the_mapper);
            };

            static UrlBuilder<CommandToRun, NotTheirModel> result;
            static NotTheirModel the_model;
            static ExpressionToPropertyNameMapper the_mapper;
            static UniqueTokenValueStore token_store;
        }

        class FakeStore : UniqueTokenValueStore
        {
            public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
            {
                yield break;
            }

            public void store_token_value(string token_key, object value)
            {
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }

    public class CommandToRun : ApplicationCommand
    {
        public void run(Request request)
        {
            throw new NotImplementedException();
        }
    }

    class NotTheirModel
    {
    }
}