namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        public static void run()
        {
            Start.by<ConfigureCoreComponents>()
                .then_by<ConfigureFrontController>()
                .then_by<ConfigureServiceLayer>()
                .finish_by<ConfigureApplicationCommands>();
        }
    }
}