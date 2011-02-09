using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ViewFactory
    {
        IHttpHandler create_view_to_display<ReportModel>(ReportModel model_object);
    }
}