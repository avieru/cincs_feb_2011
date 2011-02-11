using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.core;
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

            var combined = new AndCriteria<Request>(new RequestIsFor<ViewDepartmentsInDepartment>(),
                                                    new RequestContainsPayloadWithDetail<Department>(
                                                        x => x.number_of_products > 0));

            yield return new DefaultRequestCommand(combined.is_satisfied_by,
                                                   Container.resolve.an<ViewDepartmentProducts>());

            yield return new DefaultRequestCommand(new RequestIsFor<ViewMainDepartmentsInTheStore>().is_satisfied_by,
                                                   Container.resolve.an<ViewDepartmentsInDepartment>());
        }
    }
}