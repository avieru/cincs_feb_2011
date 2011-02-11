using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stub;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureFrontController : StartupCommand
    {
        ContainerRegistration container_services;

        public ConfigureFrontController(ContainerRegistration container_services)
        {
            this.container_services = container_services;
        }

        public void run()
        {
            container_services.register<RequestFactory, StubRequestFactory>();
            container_services.register<FrontController, DefaultFrontController>();
            container_services.register<CommandRegistry, DefaultCommandRegistry>();
            container_services.register<Renderer, WebFormRenderer>();
            container_services.register<ViewFactory, WebFormViewFactory>();
            container_services.register_instance<ActiveContextResolver>(() => HttpContext.Current);
            container_services.register<FormPathRegistry, StubFormPathRegistry>();
            container_services.register_instance<PageFactory>(BuildManager.CreateInstanceFromVirtualPath);
            container_services.register<IEnumerable<RequestCommand>, StubSetOfCommands>();
        }
    }
}