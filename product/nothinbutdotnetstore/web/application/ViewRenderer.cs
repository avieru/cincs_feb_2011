using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public interface ViewRenderer
    {
        void render_view_with(object view_model, Request request);
    }
}