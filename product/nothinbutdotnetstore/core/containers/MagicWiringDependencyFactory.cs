using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.core.containers
{
    public class MagicWiringDependencyFactory : DependencyFactory
    {
        DependencyContainer dependency_container;
        ConstructorSelectionStrategy constructor_selection_strategy;
        readonly Type type_created;

        public MagicWiringDependencyFactory(DependencyContainer dependency_container, ConstructorSelectionStrategy constructor_selection_strategy,Type type_created)
        {
            this.dependency_container = dependency_container;
            this.constructor_selection_strategy = constructor_selection_strategy;
            this.type_created = type_created;
        }

        public object create()
        {
            var constructor = constructor_selection_strategy.get_applicable_constructor_on(type_created);
            var constructor_params = new List<object>();
            constructor.GetParameters().for_each(x =>
            {
                 constructor_params.Add(dependency_container.an(x.GetType()));
            });
            var built_up_instance =  constructor.Invoke(constructor_params.ToArray());
            return dependency_container.an(built_up_instance.GetType());
        }
    }
}