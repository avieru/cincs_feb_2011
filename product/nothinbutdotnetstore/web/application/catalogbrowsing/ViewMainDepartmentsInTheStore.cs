using System;
using System.Collections.Generic;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewMainDepartmentsInTheStore : ApplicationCommand
    {
        Departments departments;
        Renderer renderer;

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