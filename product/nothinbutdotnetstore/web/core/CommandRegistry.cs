namespace nothinbutdotnetstore.web.core
{
    public interface CommandRegistry
    {
        RequestCommand get_the_command_that_can_process(Request request);
    }
}