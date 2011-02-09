using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class ViewDepartmentProducts : ApplicationCommand
    {
        Renderer renderer;
        Catalog catalog;

        public ViewDepartmentProducts(Renderer renderer, Catalog catalog)
        {
            this.renderer = renderer;
            this.catalog = catalog;
        }

        public void run(Request request)
        {
            renderer.render(catalog.get_products_in(request.map<Department>()));
        }
    }
}