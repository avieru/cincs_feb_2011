namespace nothinbutdotnetstore.web.core
{
    public interface Renderer
    {
        void render<ReportModel>(ReportModel model);
    }
}