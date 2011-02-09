using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewMainDepartmentsInTheStore : ApplicationCommand
    {
        Catalog catalog;
        Renderer renderer;

        public ViewMainDepartmentsInTheStore():this(new StubCatalog(),
            new WebFormRenderer())
        {
        }

        public ViewMainDepartmentsInTheStore(Catalog catalog, Renderer renderer)
        {
            this.catalog = catalog;
            this.renderer = renderer;
        }

        public void run(Request request)
        {
            renderer.render(catalog.get_the_main_departments());
        }
    }
}