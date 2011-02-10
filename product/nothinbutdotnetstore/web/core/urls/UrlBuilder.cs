using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core.urls
{
    public class UrlBuilder<CommandToRun, Model> : IEnumerable<KeyValuePair<string, object>>
        where CommandToRun : ApplicationCommand
    {
        public Model model;
        public UniqueTokenValueStore payload;
        public ExpressionToPropertyNameMapper expression_to_property_name_mapper;
        public const string command_key = "command_name";

        public UrlBuilder(Model model, UniqueTokenValueStore payload,
                          ExpressionToPropertyNameMapper expression_to_property_name_mapper)
        {
            this.model = model;
            this.expression_to_property_name_mapper = expression_to_property_name_mapper;
            this.payload = payload;

            payload.store_token_value(command_key, typeof(CommandToRun).Name);
        }

        public UrlBuilder<CommandToRun, Model> with<PropertyType>(
            Expression<PropertyAccessor<Model, PropertyType>> accessor)
        {
            payload.store_token_value(expression_to_property_name_mapper.map(accessor),
                                      accessor.Compile()(model));

            return this;
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return payload.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}