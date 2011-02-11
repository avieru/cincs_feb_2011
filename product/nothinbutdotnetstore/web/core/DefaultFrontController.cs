using nothinbutdotnetstore.core.containers;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultFrontController : FrontController
    {
        CommandRegistry registry;

        public DefaultFrontController(CommandRegistry registry)
        {
            this.registry = registry;
        }

        public void process(Request request)
        {
            this.registry.get_the_command_that_can_process(request).run(request);
        }
    }
}