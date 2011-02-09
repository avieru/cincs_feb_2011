using System.Web.UI;

namespace nothinbutdotnetstore.web.core
{
    public class BasicViewFor<ReportModel> : Page,ViewFor<ReportModel>
    {
        public ReportModel model { get; set; }
    }
}