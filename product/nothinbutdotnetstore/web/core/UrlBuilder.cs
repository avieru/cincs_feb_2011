using System.Linq.Expressions;

namespace nothinbutdotnetstore.web.core
{
    public delegate PropertyType PropertyAccessor<ItemToTarget, PropertyType>(ItemToTarget item);

    public class UrlBuilder<CommandToRun, Model> where CommandToRun : ApplicationCommand
    {
        Model model;
        UniqueTokenValueStore payload;
        ExpressionToPropertyNameMapper expression_to_property_name_mapper;

        public UrlBuilder(Model model, UniqueTokenValueStore payload, ExpressionToPropertyNameMapper expression_to_property_name_mapper)
        {
            this.model = model;
            this.expression_to_property_name_mapper = expression_to_property_name_mapper;
            this.payload = payload;
        }

        public UrlBuilder<CommandToRun, Model> with<PropertyType>(Expression<PropertyAccessor<Model, PropertyType>> accessor)
        {
            payload.store_token_value(expression_to_property_name_mapper.map(accessor),
                                      accessor.Compile()(model));

            return this;
        }
    }
}