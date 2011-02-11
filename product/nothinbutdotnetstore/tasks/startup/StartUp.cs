using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.core.containers;
using nothinbutdotnetstore.tasks.startup.stubs;
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
            var command_registry = new DefaultCommandRegistry(new StubSetOfCommands());
            var front_controller = new DefaultFrontController(command_registry);

            DependencyContainer container = new BasicDependencyContainer(
                new BasicDependencyFactories(generate_factories(front_controller), WebFactories.special_case_dependency_factory));

            Container.container_factory = () => container;
        }


        static WebFormViewFactory get_webform_factory()
        {
            var form_path_registry = new StubFormPathRegistry();
            return new WebFormViewFactory(form_path_registry, BuildManager.CreateInstanceFromVirtualPath);
        }


        static IDictionary<Type, DependencyFactory> generate_factories(FrontController front_controller)
        {
            var catalog = new StubCatalog();
            var renderer = new WebFormRenderer(() => HttpContext.Current, get_webform_factory());
            IDictionary<Type, DependencyFactory> all_factories = new Dictionary<Type, DependencyFactory>();
            all_factories.Add(typeof(FrontController), with_exception_handling<DefaultFrontController>(() => front_controller));
            all_factories.Add(typeof(RequestFactory),with_exception_handling<RequestFactory>(() => new StubRequestFactory()));
            all_factories.Add(typeof(Renderer),with_exception_handling<RequestFactory>(() => renderer));
            all_factories.Add(typeof(ViewMainDepartmentsInTheStore),with_exception_handling<ViewMainDepartmentsInTheStore>(() => new ViewMainDepartmentsInTheStore(catalog, renderer)));
            return all_factories;
        }


        static DependencyFactory with_exception_handling<TypeToCreate>(Func<object> factory)
        {
            return new StubDependencyFactory<TypeToCreate>(
                new BasicDependencyFactory(factory)); 
        }
    }
}