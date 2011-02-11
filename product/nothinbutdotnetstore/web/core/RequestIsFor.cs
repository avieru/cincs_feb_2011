using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core
{
    public class RequestIsFor<Command> : Criteria<Request> where Command : ApplicationCommand
    {
        public bool is_satisfied_by(Request item)
        {
            return item.raw_url.Contains(typeof(Command).Name);
        }
    }
}