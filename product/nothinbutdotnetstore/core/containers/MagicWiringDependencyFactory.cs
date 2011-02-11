using System;
using System.Collections.Generic;
using System.Reflection;

namespace nothinbutdotnetstore.core.containers
{
    public class MagicWiringDependencyFactory : DependencyFactory
    {
        readonly Type type_being_created;
        readonly DependencyContainer container;
        readonly ConstructorSelectionStrategy strategy;

        public MagicWiringDependencyFactory(Type type_being_created, DependencyContainer container, ConstructorSelectionStrategy strategy)
        {
            this.type_being_created = type_being_created;
            this.container = container;
            this.strategy = strategy;
        }

        public object create()
        {
            var constructor = strategy.get_applicable_constructor_on(type_being_created);
            List<object> parameters = new List<object>();
            foreach (var parameter in constructor.GetParameters())
            {
                parameters.Add(get_parameter_value(parameter));
            }
            return constructor.Invoke(parameters.ToArray());
        }

        private object get_parameter_value(ParameterInfo parameter)
        {
            return container.an(parameter.ParameterType);
        }
    }
}