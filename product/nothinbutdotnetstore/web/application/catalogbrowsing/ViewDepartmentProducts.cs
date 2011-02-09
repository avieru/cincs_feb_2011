using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stub;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewDepartmentProducts : ApplicationCommand
    {
        Departments departments;
        Renderer renderer;

        public ViewDepartmentProducts():this(new StubDepartments(),
            new StubRenderer())
        {
        }

        public ViewDepartmentProducts(Departments departments, Renderer renderer)
        {
            this.departments = departments;
            this.renderer = renderer;
        }

        public void run(Request request)
        {
            renderer.render(departments.get_products_for(request.map<Product>()));
        }
    }
}