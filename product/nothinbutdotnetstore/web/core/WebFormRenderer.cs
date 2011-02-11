namespace nothinbutdotnetstore.web.core
{
    public class WebFormRenderer : Renderer
    {
        ActiveContextResolver context_resolver;
        ViewFactory view_factory;

        public WebFormRenderer(ActiveContextResolver context_resolver, ViewFactory view_factory)
        {
            this.context_resolver = context_resolver;
            this.view_factory = view_factory;
        }

        public void render<ReportModel>(ReportModel model)
        {
            view_factory.create_view_to_display(model).ProcessRequest(context_resolver());
        }
    }
}