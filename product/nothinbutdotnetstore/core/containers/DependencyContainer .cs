using System;

namespace nothinbutdotnetstore.core.containers
{
    public interface DependencyContainer
    {
        Dependency an<Dependency>();
        object an(Type dependency_type);
    }
}