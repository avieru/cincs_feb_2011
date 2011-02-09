using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stub;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewDepartmentsInDepartment : ApplicationCommand
    {
        readonly Departments departments;
        Renderer renderer;

        public ViewDepartmentsInDepartment():this(new StubDepartments(),
            new StubRenderer())
        {
        }

        public ViewDepartmentsInDepartment(Departments departments, Renderer renderer)
        {
            this.departments = departments;
            this.renderer = renderer;
        }

        public void run(Request request)
        {
            renderer.render(departments.get_departments_in(request.map<Department>()));
        }
    }
}