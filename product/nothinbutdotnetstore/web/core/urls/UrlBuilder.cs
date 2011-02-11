using System.Linq.Expressions;
using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core.urls
{
    public class UrlBuilder<CommandToRun, Model>
        where CommandToRun : ApplicationCommand
    {
        public Model model;
        public UniqueTokenValueStore payload;
        public ExpressionToPropertyNameMapper expression_to_property_name_mapper;
        public UrlEncoder url_encoding_visitor;

        public const string command_key = "command_name";

        public UrlBuilder(Model model, UniqueTokenValueStore payload,
                          ExpressionToPropertyNameMapper expression_to_property_name_mapper,
                          UrlEncoder url_encoding_visitor)
        {
            this.model = model;
            this.url_encoding_visitor = url_encoding_visitor;
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

        public override string ToString()
        {
            return payload.get_result_of_visit_all_items_with(url_encoding_visitor);
        }

        public static implicit operator string(UrlBuilder<CommandToRun, Model> builder)
        {
            return builder.ToString(); 
        }

    }
}