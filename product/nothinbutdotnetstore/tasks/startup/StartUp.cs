using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.core.containers;
using nothinbutdotnetstore.tasks.startup.stubs;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stub;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        public static void run()
        {
            IDictionary<Type, DependencyFactory> all_factories = new Dictionary<Type, DependencyFactory>();
            DependencyContainer container = new BasicDependencyContainer(
                new BasicDependencyFactories(all_factories, WebFactories.special_case_dependency_factory));

            Container.container_factory = () => container;

            var form_path_registry = new StubFormPathRegistry();
            var view_factory = new WebFormViewFactory(form_path_registry, BuildManager.CreateInstanceFromVirtualPath);

            var catalog = new StubCatalog();
            var renderer = new WebFormRenderer(() => HttpContext.Current, view_factory);

            var command_registry = new DefaultCommandRegistry(new StubSetOfCommands());
            var front_controller = new DefaultFrontController(command_registry);
            all_factories.Add(typeof(FrontController),
                              with_exception_handling<DefaultFrontController>(() => front_controller));

            all_factories.Add(typeof(RequestFactory),with_exception_handling<RequestFactory>(() => new StubRequestFactory()));
            all_factories.Add(typeof(Renderer),with_exception_handling<RequestFactory>(() => renderer));
        }

        static DependencyFactory with_exception_handling<TypeToCreate>(Func<object> factory)
        {
            return new StubDependencyFactory<TypeToCreate>(
                new BasicDependencyFactory(factory)); 
        }
    }
}