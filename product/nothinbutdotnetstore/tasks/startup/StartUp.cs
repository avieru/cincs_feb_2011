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
        static IDictionary<Type, DependencyFactory> all_factories;

        public static void run()
        {
            all_factories = new Dictionary<Type, DependencyFactory>();

            DependencyContainer container = new BasicDependencyContainer(
                new BasicDependencyFactories(all_factories, WebFactories.special_case_dependency_factory));

            Container.container_factory = () => container;

            configure_front_controller();
            configure_service_layer();
            configure_application_commands();
        }

        static void configure_application_commands()
        {
        }

        static void configure_service_layer()
        {
            register_factory<Catalog>(() => new StubCatalog());
        }

        static void configure_front_controller()
        {
            register_instance<PageFactory>(BuildManager.CreateInstanceFromVirtualPath);
            register_instance<ActiveContextResolver>(() => HttpContext.Current);
            register_factory<ViewFactory>(() => new WebFormViewFactory(Container.resolve.an<FormPathRegistry>(),
                                                                       Container.resolve.an<PageFactory>()));
            register_factory<FrontController>(() => new DefaultFrontController(Container.resolve.an<CommandRegistry>()));
            register_factory<RequestFactory>(() => new StubRequestFactory());
            register_factory<Renderer>(() => new WebFormRenderer(Container.resolve.an<ActiveContextResolver>(),
                                                                 Container.resolve.an<ViewFactory>()));
        }

        static void register_factory<Contract>(Func<object> factory)
        {
            all_factories.Add(typeof(Contract), new StubDependencyFactory<Contract>(
                                                    new BasicDependencyFactory(factory)));

        }

        static void register_instance<Contract>(Contract instance)
        {
            register_factory<Contract>(() => instance);
        }
    }

}