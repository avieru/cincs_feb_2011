using System;
using nothinbutdotnetstore.core.containers;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubMissingDependencyFactory : DependencyFactory
    {
        Type missing_type;

        public StubMissingDependencyFactory(Type missing_type)
        {
            this.missing_type = missing_type;
        }

        public object create()
        {
            throw new NotImplementedException(string.Format("There is no factory that can create a {0}",
                                                            missing_type.Name));
        }
    }
}