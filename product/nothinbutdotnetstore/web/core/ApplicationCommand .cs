namespace nothinbutdotnetstore.web.core
{
    public interface ApplicationCommand
    {
        void run(Request request);
    }
}