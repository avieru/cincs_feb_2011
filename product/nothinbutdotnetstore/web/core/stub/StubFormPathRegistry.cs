using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core.stub
{
    public class StubFormPathRegistry : FormPathRegistry
    {
        public string get_path_to_view_that_can_render<ReportModel>()
        {
            if (typeof(ReportModel) == typeof(IEnumerable<Department>))
            {
                return create_view("DepartmentBrowser");
            }
            return create_view("ProductBrowser");
        }

        string create_view(string raw_name)
        {
            return string.Format("~/views/{0}.aspx", raw_name);
        }
    }
}