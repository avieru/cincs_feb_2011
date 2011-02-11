using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureApplicationCommands : StartupCommand
    {
        ContainerRegistration container_services;

        public ConfigureApplicationCommands(ContainerRegistration container_services)
        {
            this.container_services = container_services;
        }

        public void run()
        {
            container_services.register<ViewMainDepartmentsInTheStore>();
            container_services.register<ViewDepartmentsInDepartment>();
            container_services.register<ViewDepartmentProducts>();
        }
    }
}