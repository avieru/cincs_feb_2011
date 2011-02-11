using nothinbutdotnetstore.core.containers;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureCoreComponents : StartupCommand
    {
        ContainerRegistration registration_services;

        public ConfigureCoreComponents(ContainerRegistration registration_services)
        {
            this.registration_services = registration_services;
        }

        public void run()
        {
            var container = new BasicDependencyContainer(
                new BasicDependencyFactories(registration_services, WebFactories.special_case_dependency_factory));

            registration_services.register<DependencyContainer>(container);
            registration_services.register<ConstructorSelectionStrategy>(
                new GreedyConstructorSelectionStrategy());

            Container.container_factory = () => container;
        }
    }
}