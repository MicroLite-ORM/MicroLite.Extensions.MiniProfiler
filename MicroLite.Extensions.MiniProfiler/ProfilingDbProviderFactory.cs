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
            var profiler = MiniProfiler.Current;

            var command = this.inner.CreateCommand();

            return profiler != null
                ? new ProfiledDbCommand(command, null, MiniProfiler.Current)
                : command;
        }

        public override DbCommandBuilder CreateCommandBuilder()
        {
            return this.inner.CreateCommandBuilder();
        }

        public override DbConnection CreateConnection()
        {
            var profiler = MiniProfiler.Current;

            var connection = this.inner.CreateConnection();

            return profiler != null
                ? new ProfiledDbConnection(connection, MiniProfiler.Current)
                : connection;
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
