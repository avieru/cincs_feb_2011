 using System;
 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.core.containers;

namespace nothinbutdotnetstore.specs
{   
    public class DependencyFactoriesSpecs
    {
        public abstract class concern : Observes<DependencyFactories,
                                            BasicDependencyFactories>
        {

            Establish c = () =>
            {
                special_case = an<DependencyFactory>();
                provide_a_basic_sut_constructor_argument<SpecialCaseDependencyFactory>((x) =>
                {
                    type_that_has_no_factory = x;
                    return special_case;
                });
            };

            protected static DependencyFactory special_case;
            protected static Type type_that_has_no_factory;
        }

        [Subject(typeof(BasicDependencyFactories))]
        public class when_getting_a_factory_that_can_create_a_dependency_and_it_has_the_dependency : concern
        {
            Establish c = () =>
            {
                the_factory = an<DependencyFactory>();
                all_factories = new Dictionary<Type,DependencyFactory>();
                all_factories.Add(typeof(OurDependency),the_factory );

                provide_a_basic_sut_constructor_argument(all_factories);
            };

            Because b = () =>
                result = sut.get_factory_that_can_create(typeof(OurDependency));

            It should_return_the_factory_that_can_create_the_dependency = () =>
                result.ShouldEqual(the_factory);

            static DependencyFactory result;
            static DependencyFactory the_factory;
            static IDictionary<Type, DependencyFactory> all_factories;
        }

        public class when_attempting_to_get_a_factory_and_it_does_have_it : concern
        {
            Establish c = () =>
            {
                all_factories = new Dictionary<Type,DependencyFactory>();
                provide_a_basic_sut_constructor_argument(all_factories);
            };

            Because b = () =>
                result = sut.get_factory_that_can_create(typeof(OurDependency));

            It should_return_the_special_case = () =>
            {
                type_that_has_no_factory.ShouldEqual(typeof(OurDependency));
                result.ShouldEqual(special_case);
            };


            static DependencyFactory result;
            static DependencyFactory the_factory;
            static IDictionary<Type, DependencyFactory> all_factories;
        }
    }

    public class OurDependency
    {
    }
}
