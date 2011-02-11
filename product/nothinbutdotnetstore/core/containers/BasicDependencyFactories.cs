using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.core.containers
{
    public class BasicDependencyFactories : DependencyFactories
    {
        IDictionary<Type, DependencyFactory> all_factories;
        SpecialCaseDependencyFactory special_case_dependency_factory;

        public BasicDependencyFactories(IDictionary<Type, DependencyFactory> all_factories,
                                        SpecialCaseDependencyFactory special_case_dependency_factory)
        {
            this.all_factories = all_factories;
            this.special_case_dependency_factory = special_case_dependency_factory;
        }

        public DependencyFactory get_factory_that_can_create(Type dependency_type)
        {
            if (all_factories.ContainsKey(dependency_type)) return all_factories[dependency_type];

            return special_case_dependency_factory(dependency_type);
        }
    }
}