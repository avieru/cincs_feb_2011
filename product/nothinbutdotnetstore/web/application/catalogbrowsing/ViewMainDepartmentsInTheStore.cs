using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stub;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewMainDepartmentsInTheStore : ApplicationCommand
    {
        Departments departments;
        Renderer renderer;

        public ViewMainDepartmentsInTheStore():this(new StubDepartments(),
            new StubRenderer())
        {
        }

        public ViewMainDepartmentsInTheStore(Departments departments, Renderer renderer)
        {
            this.departments = departments;
            this.renderer = renderer;
        }

        public void run(Request request)
        {
            renderer.render(departments.get_the_main_departments());
        }
    }
}