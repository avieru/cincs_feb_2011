using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ViewFor<ReportModel> : IHttpHandler
    {
        ReportModel model { get; set; }
    }
}