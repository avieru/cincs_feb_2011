namespace nothinbutdotnetstore.web.core
{
    public interface RequestCommand 
    {
        void run(Request request);
    }
}