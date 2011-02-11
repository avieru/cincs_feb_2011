using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.core.containers;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core.stub
{
    public class StubSetOfCommands : IEnumerable<RequestCommand>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<RequestCommand> GetEnumerator()
        {
            yield return new DefaultRequestCommand(new RequestIsFor<ViewMainDepartmentsInTheStore>().is_satisfied_by,
                                                   Container.resolve.an<ViewMainDepartmentsInTheStore>());
        }
    }
}