using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewDepartmentProducts : ApplicationCommand
    {
        Catalog catalog;
        Renderer renderer;

        public ViewDepartmentProducts(Catalog catalog, Renderer renderer)
        {
            this.catalog = catalog;
            this.renderer = renderer;
        }

        public void run(Request request)
        {
            renderer.render(catalog.get_products_in(request.map<Department>()));
        }
    }
}