using System;
using System.Collections.Generic;
using System.Web;
using nothinbutdotnetstore.core.containers;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stub;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        public static void run()
        {
            IDictionary<Type, DependencyFactory> all_factories = new Dictionary<Type, DependencyFactory>();
            DependencyContainer container =  new BasicDependencyContainer(
                new BasicDependencyFactories(all_factories, (type_that_has_no_factory) =>
                {
                    throw new NotImplementedException("You need to deal with the special case here");
                }));
            Container.container_factory = () => container;

            var form_path_registry = new StubFormPathRegistry();
            var view_factory = new WebFormViewFactory(form_path_registry,BasicViewFor<Department>);
            var catalog = new StubCatalog();
            var renderer = new WebFormRenderer(()=> HttpContext.Current ,view_factory); 
           List<ApplicationCommand> command_list = new List<ApplicationCommand>{
                new ViewDepartmentProducts(catalog,renderer),
                new ViewDepartmentsInDepartment(catalog,renderer),
                new ViewMainDepartmentsInTheStore(catalog,renderer)
            };

            var command_registry = new DefaultCommandRegistry(command_list));
            var defaultController = new DefaultFrontController(command_registry);
            all_factories.Add(typeof(FrontController), new BasicDependencyFactory(() => defaultController));
        }
    }
}