using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class CalculatorSpecs
    {
        public abstract class concern : Observes<Calculator,DefaultCalculator>
        {
            Establish c = () =>
            {
                provide_a_basic_sut_constructor_argument(1);
            };
        }

        public class when_adding_two_positive_numbers : concern
        {
            Establish c = () =>
            {
                connection = the_dependency<IDbConnection>();
                command = an<IDbCommand>();

                connection.Stub(x => x.CreateCommand()).Return(command);
            };

            Because b = () =>
                result = sut.add(1, 3);


            It should_open_a_connection_to_the_database = () =>
                connection.received(x => x.Open());

            It should_run_a_query = () =>
                command.received(x => x.ExecuteNonQuery());

            It should_dispose_both_the_command_and_connection = () =>
            {
                connection.received(x => x.Dispose());
                command.received(x => x.Dispose());
            };
  

            It should_return_the_sum_with_the_offset = () =>
                result.ShouldEqual(5);

            static int result;
            static IDbConnection connection;
            static IDbCommand command;
        }

        class when_trying_to_shut_off_the_calculator_and_they_are_not_in_the_correct_security_group : concern
        {
            Establish c = () =>
            {
                our_principal = an<IPrincipal>();

                our_principal.Stub(x => x.IsInRole(Arg<string>.Is.Anything)).Return(false);

                change(() => Thread.CurrentPrincipal).to(our_principal);
            };

            Because b = () =>
                catch_exception(() => sut.shut_off());


            It should_throw_a_security_exception = () =>
            {
                exception_thrown_by_the_sut.ShouldBeAn<SecurityException>();
            };

            static IPrincipal our_principal;
        }
        class when_shuttting_off_the_calculator_and_they_are_in_the_correct_security_group: concern
        {
            Establish c = () =>
            {
                our_principal = an<IPrincipal>();

                our_principal.Stub(x => x.IsInRole(Arg<string>.Is.Anything)).Return(true);

                change(() => Thread.CurrentPrincipal).to(our_principal);
            };

            Because b = () =>
                sut.shut_off();



            It should_not_throw_an_exception = () =>
            {

            };


            static IPrincipal our_principal;
        }
    }
}