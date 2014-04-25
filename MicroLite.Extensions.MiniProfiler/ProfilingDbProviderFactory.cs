namespace MicroLite.Extensions.MiniProfiler
{
    using System.Data.Common;
    using StackExchange.Profiling;
    using StackExchange.Profiling.Data;

    internal sealed class ProfilingDbProviderFactory : DbProviderFactory
    {
        private readonly DbProviderFactory inner;

        internal ProfilingDbProviderFactory(DbProviderFactory inner)
        {
            this.inner = inner;
        }

        public override bool CanCreateDataSourceEnumerator
        {
            get
            {
                return this.inner.CanCreateDataSourceEnumerator;
            }
        }

        public override DbCommand CreateCommand()
        {
            var command = this.inner.CreateCommand();

            var profiler = MiniProfiler.Current;

            if (profiler == null)
            {
                return command;
            }

            return new ProfiledDbCommand(command, null, profiler);
        }

        public override DbCommandBuilder CreateCommandBuilder()
        {
            return this.inner.CreateCommandBuilder();
        }

        public override DbConnection CreateConnection()
        {
            var connection = this.inner.CreateConnection();

            var profiler = MiniProfiler.Current;

            if (profiler == null)
            {
                return connection;
            }

            return new ProfiledDbConnection(connection, profiler);
        }

        public override DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return this.inner.CreateConnectionStringBuilder();
        }

        public override DbDataAdapter CreateDataAdapter()
        {
            return this.inner.CreateDataAdapter();
        }

        public override DbDataSourceEnumerator CreateDataSourceEnumerator()
        {
            return this.inner.CreateDataSourceEnumerator();
        }

        public override DbParameter CreateParameter()
        {
            return this.inner.CreateParameter();
        }

        public override System.Security.CodeAccessPermission CreatePermission(System.Security.Permissions.PermissionState state)
        {
            return this.inner.CreatePermission(state);
        }
    }
}