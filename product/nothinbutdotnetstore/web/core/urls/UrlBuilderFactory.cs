using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core.urls
{
    public class UrlBuilderFactory<CommandToBuildUrlsTo> where CommandToBuildUrlsTo : ApplicationCommand
    {
        ExpressionToPropertyNameMapper expression_to_property_name_mapper;
        TokenStoreFactory token_store_factory;

        public UrlBuilderFactory(ExpressionToPropertyNameMapper expression_to_property_name_mapper, TokenStoreFactory token_store_factory)
        {
            this.expression_to_property_name_mapper = expression_to_property_name_mapper;
            this.token_store_factory = token_store_factory;
        }

        public UrlBuilder<CommandToBuildUrlsTo, ReportModel> For<ReportModel>(ReportModel the_model)
        {
            return new UrlBuilder<CommandToBuildUrlsTo, ReportModel>(the_model,
                                                        token_store_factory(),
                                                        expression_to_property_name_mapper);
        }
    }
}