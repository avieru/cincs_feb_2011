using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.core.containers;

namespace nothinbutdotnetstore.specs
{
    public class BasicDependencyFactorySpecs
    {
        public abstract class concern : Observes<DependencyFactory,
                                            BasicDependencyFactory>
        {
        }

        [Subject(typeof(BasicDependencyFactory))]
        public class when_creating_an_instance_of_a_dependency : concern
        {
            Establish c = () =>
            {
                the_item = new object();
                provide_a_basic_sut_constructor_argument<Func<object>>(() => the_item);
            };

            Because b = () =>
                result = sut.create();

            It should_return_the_instance_create_by_the_provided_factory = () =>
                result.ShouldEqual(the_item);

            static object result;
            static object the_item;
        }
    }
}