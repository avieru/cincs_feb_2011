using System.Web;

namespace nothinbutdotnetstore.web.core.stub
{
    public class StubRenderer : Renderer
    {
        public void render<ReportModel>(ReportModel model)
        {
            HttpContext.Current.Items.Add("blah",model);
            HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx");
        }
    }
}