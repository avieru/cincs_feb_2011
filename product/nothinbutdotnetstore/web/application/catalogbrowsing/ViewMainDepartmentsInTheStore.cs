using System;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewMainDepartmentsInTheStore : ApplicationCommand
    {
        readonly Repository repository;
        readonly ViewRenderer view_renderer;

        public ViewMainDepartmentsInTheStore(Repository repository,ViewRenderer view_renderer)
        {
            this.repository = repository;
            this.view_renderer = view_renderer;
        }

        public void run(Request request)
        {
            var departments =repository.get_departments();
            view_renderer.render_view_with(departments,request);
        }
    }
}