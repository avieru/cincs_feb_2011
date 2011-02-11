using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.core.containers;
using nothinbutdotnetstore.specs.spikes;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class MagicWiringDependencyFactorySpecs
    {
        public abstract class concern : Observes<DependencyFactory,
                                            MagicWiringDependencyFactory>
        {
        }

        [Subject(typeof(MagicWiringDependencyFactory))]
        public class when_creating_an_instance_of_a_dependency : concern
        {
            Establish c = () =>
            {
                the_container = the_dependency<DependencyContainer>();
                the_type_that_is_being_created = typeof(OurTypeWithLotsOfDependencies);
                constructor_selection_strategy = the_dependency<ConstructorSelectionStrategy>();
                provide_a_basic_sut_constructor_argument(the_type_that_is_being_created);

                sql_command = new SqlCommand();
                sql_connection = new SqlConnection();
                other_item = new Other();

                the_greediest_constructor = ExpressionUtility.constructor_pointed_at_by(() =>
                                                                                            new OurTypeWithLotsOfDependencies
                                                                                            (null, null, null));

                constructor_selection_strategy.Stub(
                    x => x.get_applicable_constructor_on(the_type_that_is_being_created))
                    .Return(the_greediest_constructor);

                the_container.Stub(x => x.an(typeof(IDbConnection))).Return(sql_connection);
                the_container.Stub(x => x.an(typeof(IDbCommand))).Return(sql_command);
                the_container.Stub(x => x.an(typeof(Other))).Return(other_item);
            };

            Because b = () =>
                result = sut.create();

            It should_create_an_instance_of_the_dependency_with_all_of_its_dependencies_satisfied = () =>
            {
                var item = result.ShouldBeAn<OurTypeWithLotsOfDependencies>();
                item.connection.ShouldEqual(sql_connection);
                item.command.ShouldEqual(sql_command);
                item.other.ShouldEqual(other_item);
            };

            static object result;
            static IDbConnection sql_connection;
            static IDbCommand sql_command;
            static Other other_item;
            static DependencyContainer the_container;
            static ConstructorSelectionStrategy constructor_selection_strategy;
            static ConstructorInfo the_greediest_constructor;
            static Type the_type_that_is_being_created;
        }
    }

    public class OurTypeWithLotsOfDependencies
    {
        public IDbConnection connection;
        public IDbCommand command;
        public Other other;

        public OurTypeWithLotsOfDependencies(IDbConnection connection, IDbCommand command, Other other)
        {
            this.connection = connection;
            this.command = command;
            this.other = other;
        }

        public OurTypeWithLotsOfDependencies(IDbConnection connection, IDbCommand command)
        {
            this.connection = connection;
            this.command = command;
        }

        public OurTypeWithLotsOfDependencies(IDbConnection connection)
        {
            this.connection = connection;
        }
    }

    public class Other
    {
    }
}