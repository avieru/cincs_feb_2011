using System.Data;
using System.Security;
using System.Threading;

namespace nothinbutdotnetstore
{
    public class DefaultCalculator : Calculator
    {
        int offset;
        IDbConnection connection;

        public DefaultCalculator(int offset, IDbConnection connection)
        {
            this.offset = offset;
            this.connection = connection;
        }

        public int add(int first, int second)
        {
            using (connection)
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.ExecuteNonQuery();
                return first + second + offset;
            }
        }

        public void shut_off()
        {
            if (Thread.CurrentPrincipal.IsInRole("special")) return;

            throw new SecurityException();
        }
    }
}