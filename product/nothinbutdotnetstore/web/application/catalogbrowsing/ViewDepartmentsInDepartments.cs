using System;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewDepartmentsInDepartments : ApplicationCommand
    {
        readonly Request request;
        readonly Departments departments;

        public ViewDepartmentsInDepartments(Request request, Departments departments)
        {
            this.request = request;
            this.departments = departments;
        }

        public void run(Request request)
        {
            throw new NotImplementedException();
        }
    }
}