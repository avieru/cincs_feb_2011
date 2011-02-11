using System;

namespace nothinbutdotnetstore.core.containers
{
    public interface DependencyFactories
    {
        DependencyFactory get_factory_that_can_create(Type dependency_type);
    }
}