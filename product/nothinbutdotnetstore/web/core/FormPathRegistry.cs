namespace nothinbutdotnetstore.web.core
{
    public interface FormPathRegistry
    {
        string get_path_to_view_that_can_render<ReportModel>();
    }
}