using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class WebFormViewFactory : ViewFactory
    {
        FormPathRegistry form_path_registry;
        PageFactory page_factory;

        public WebFormViewFactory(FormPathRegistry form_path_registry, PageFactory page_factory)
        {
            this.form_path_registry = form_path_registry;
            this.page_factory = page_factory;
        }

        public IHttpHandler create_view_to_display<ReportModel>(ReportModel model_object)
        {
            var raw_page = page_factory(form_path_registry.get_path_to_view_that_can_render<ReportModel>(),
                                        typeof(ViewFor<ReportModel>));

            var model_aware_page = (ViewFor<ReportModel>) raw_page;

            model_aware_page.model = model_object;

            return model_aware_page;
        }
    }
}