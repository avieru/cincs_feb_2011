using nothinbutdotnetstore.tasks.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureServiceLayer : StartupCommand
    {
        ContainerRegistration container_services;

        public ConfigureServiceLayer(ContainerRegistration container_services)
        {
            this.container_services = container_services;
        }

        public  void run()
        {
            container_services.register<Catalog, StubCatalog>();
        }
    }
}