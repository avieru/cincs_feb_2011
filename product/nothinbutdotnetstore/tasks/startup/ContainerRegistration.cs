using System;
using System.Collections.Generic;
using nothinbutdotnetstore.core.containers;

namespace nothinbutdotnetstore.tasks.startup
{
    public interface ContainerRegistration : IDictionary<Type,DependencyFactory>
    {
        void register<Dependency>(Dependency dependency);
        void register<Dependency>();
        void register<Contract,Implementation>();
    }
}