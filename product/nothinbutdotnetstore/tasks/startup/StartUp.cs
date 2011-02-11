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
            DependencyContainer container = new BasicDependencyContainer(
                new BasicDependencyFactories(get_all_setup_factories(), WebFactories.special_case_dependency_factory));

            Container.container_factory = () => container;
        }

        static IDictionary<Type, DependencyFactory> get_all_setup_factories()
        {
            var front_controller = new DefaultFrontController(new DefaultCommandRegistry(new StubSetOfCommands()));
            var catalog = new StubCatalog();
            var renderer = new WebFormRenderer(() => HttpContext.Current, get_webform_factory());

            IDictionary<Type, DependencyFactory> all_factories = new Dictionary<Type, DependencyFactory>();
            all_factories.Add(factory_for<FrontController, DefaultFrontController>(() => front_controller));
            all_factories.Add(factory_for<RequestFactory, RequestFactory>(() => new StubRequestFactory()));
            all_factories.Add(factory_for<Renderer, RequestFactory>(() => renderer));
            all_factories.Add(factory_for<ViewMainDepartmentsInTheStore, ViewMainDepartmentsInTheStore>(() => new ViewMainDepartmentsInTheStore(catalog, renderer)));

            return all_factories;
        }
        static WebFormViewFactory get_webform_factory()
        {
            return new WebFormViewFactory(new StubFormPathRegistry(), BuildManager.CreateInstanceFromVirtualPath);
        }

        static KeyValuePair<Type,DependencyFactory> factory_for<SomeType,TypeToCreate>(Func<object> factory)
        {
            return new KeyValuePair<Type, DependencyFactory>(typeof(SomeType), with_exception_handling<TypeToCreate>(factory));
        }

        static DependencyFactory with_exception_handling<TypeToCreate>(Func<object> factory)
        {
            return new StubDependencyFactory<TypeToCreate>(
                new BasicDependencyFactory(factory)); 
        }
    }

}