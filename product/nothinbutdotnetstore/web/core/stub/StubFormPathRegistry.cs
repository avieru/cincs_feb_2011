namespace nothinbutdotnetstore.web.core.stub
{
    public class StubFormPathRegistry : FormPathRegistry
    {
        public string get_path_to_view_that_can_render<ReportModel>()
        {
            return "~/views/DepartmentBrowser.aspx";
        }
    }
}