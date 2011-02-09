using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stub;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewDepartmentsInDepartment : ApplicationCommand
    {
        Catalog catalog;
        Renderer renderer;

        public ViewDepartmentsInDepartment():this(new StubCatalog(),
            new StubRenderer())
        {
        }

        public ViewDepartmentsInDepartment(Catalog catalog, Renderer renderer)
        {
            this.catalog = catalog;
            this.renderer = renderer;
        }

        public void run(Request request)
        {
            renderer.render(catalog.get_departments_in(request.map<Department>()));
        }
    }
}