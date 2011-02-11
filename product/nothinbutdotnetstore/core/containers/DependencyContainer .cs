using System;

namespace nothinbutdotnetstore.core.containers
{
    public interface DependencyContainer 
    {
        Dependency an<Dependency>();
        Dependency an(Type dependency_type);
 
    }
}