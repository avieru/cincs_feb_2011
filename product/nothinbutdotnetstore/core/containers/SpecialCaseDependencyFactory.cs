using System;

namespace nothinbutdotnetstore.core.containers
{
    public delegate DependencyFactory SpecialCaseDependencyFactory(Type type_that_has_no_dependency_factory);
}