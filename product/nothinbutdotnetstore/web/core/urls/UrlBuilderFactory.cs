using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core.urls
{
    public class UrlBuilderFactory<CommandToBuildUrlsTo> where CommandToBuildUrlsTo : ApplicationCommand
    {
        ExpressionToPropertyNameMapper expression_to_property_name_mapper;
        TokenStoreFactory token_store_factory;
        UrlEncoderFactory url_encoder_factory;

        public UrlBuilderFactory(ExpressionToPropertyNameMapper expression_to_property_name_mapper,
                                 TokenStoreFactory token_store_factory, UrlEncoderFactory url_encoder_factory)
        {
            this.expression_to_property_name_mapper = expression_to_property_name_mapper;
            this.token_store_factory = token_store_factory;
            this.url_encoder_factory = url_encoder_factory;
        }

        public UrlBuilder<CommandToBuildUrlsTo, ReportModel> For<ReportModel>(ReportModel the_model)
        {
            return new UrlBuilder<CommandToBuildUrlsTo, ReportModel>(the_model,
                                                                     token_store_factory(),
                                                                     expression_to_property_name_mapper,
                                                                     url_encoder_factory());
        }

        public UrlBuilder<CommandToBuildUrlsTo, SomeDummyItem> basic()
        {
            return For(new SomeDummyItem {some_integer_value = 234}).with(x => x.some_integer_value);
        }

        public class SomeDummyItem
        {
            public int some_integer_value { get; set; }
        }
    }
}