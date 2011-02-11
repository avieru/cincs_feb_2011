 using System;
 using System.Data;
 using System.Data.SqlClient;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.core.containers;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class BasicDependencyContainerSpecs
    {
        public abstract class concern : Observes<DependencyContainer,
                                            BasicDependencyContainer>
        {
        
        }

        [Subject(typeof(BasicDependencyContainer))]
        public class when_resolving_an_dependency : concern
        {
            Establish c = () =>
            {
                dependency_factories = the_dependency<DependencyFactories>();
                the_connection = new SqlConnection();
                factory  = an<DependencyFactory>();

                dependency_factories.Stub(x => x.get_factory_that_can_create(typeof(IDbConnection)))
                    .Return(factory);

                factory.Stub(x => x.create()).Return(the_connection);
            };

            Because b = () =>
                result = sut.an<IDbConnection>();


            It should_return_the_item_created_by_the_dependency_factory_for_the_dependency_requested = () =>
                result.ShouldEqual(the_connection);

            static IDbConnection result;
            static IDbConnection the_connection;
            static DependencyFactories dependency_factories;
            static DependencyFactory factory;
        }

        public class when_the_factory_for_a_dependency_throws_an_exception_when_creating_its_dependency : concern
        {
            Establish c = () =>
            {
                dependency_factories = the_dependency<DependencyFactories>();
                factory  = an<DependencyFactory>();
                the_original_exception = new Exception();

                dependency_factories.Stub(x => x.get_factory_that_can_create(typeof(IDbConnection)))
                    .Return(factory);

                factory.Stub(x => x.create()).Throw(the_original_exception);

            };

            Because b = () =>
                catch_exception(() => sut.an<IDbConnection>());

            It should_throw_a_dependency_creation_exception_with_the_correct_information = () =>
            {
                var item = exception_thrown_by_the_sut.ShouldBeAn<DependencyCreationException>();
                item.InnerException.ShouldEqual(the_original_exception);
                item.dependency_that_could_not_be_created.ShouldEqual(typeof(IDbConnection));
            };

            static DependencyFactories dependency_factories;
            static DependencyFactory factory;
            static Exception the_original_exception;
        }
    }
}
