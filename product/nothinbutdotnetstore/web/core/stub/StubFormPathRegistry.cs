using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core.stub
{
    public class StubFormPathRegistry : FormPathRegistry
    {
        public string get_path_to_view_that_can_render<ReportModel>()
        {
            if (typeof(ReportModel).Equals(typeof(Department)))
            {
                return "~/views/DepartmentBrowser.aspx";
            }
            return "~/views/ProductBrowser.aspx";
        }
    }
}