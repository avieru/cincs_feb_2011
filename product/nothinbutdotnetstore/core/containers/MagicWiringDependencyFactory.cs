using System;
using System.Linq;
using System.Reflection;

namespace nothinbutdotnetstore.core.containers
{
    public class MagicWiringDependencyFactory : DependencyFactory
    {
        Type type_being_created;
        DependencyContainer container;
        ConstructorSelectionStrategy strategy;

        public MagicWiringDependencyFactory(Type type_being_created, DependencyContainer container,
                                            ConstructorSelectionStrategy strategy)
        {
            this.type_being_created = type_being_created;
            this.container = container;
            this.strategy = strategy;
        }

        public object create()
        {
            var constructor = strategy.get_applicable_constructor_on(type_being_created);
            var parameters = constructor.GetParameters().Select(x => container.an(x.ParameterType));
            return constructor.Invoke(parameters.ToArray());
        }

        object get_parameter_value(ParameterInfo parameter)
        {
            return container.an(parameter.ParameterType);
        }
    }
}