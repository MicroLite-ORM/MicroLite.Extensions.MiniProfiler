namespace MicroLite.Extensions.MiniProfiler
{
    using System.Data.Common;
    using StackExchange.Profiling;
    using StackExchange.Profiling.Data;

    public sealed class ProfilingDbProviderFactory : DbProviderFactory
    {
        private readonly DbProviderFactory dbProviderFactory;

        public ProfilingDbProviderFactory(DbProviderFactory dbProviderFactory)
        {
            this.dbProviderFactory = dbProviderFactory;
        }

        public override bool CanCreateDataSourceEnumerator
        {
            get
            {
                return this.dbProviderFactory.CanCreateDataSourceEnumerator;
            }
        }

        public override DbCommand CreateCommand()
        {
            var profiler = MiniProfiler.Current;

            var command = this.dbProviderFactory.CreateCommand();

            return profiler != null
                ? new ProfiledDbCommand(command, null, MiniProfiler.Current)
                : command;
        }

        public override DbCommandBuilder CreateCommandBuilder()
        {
            return this.dbProviderFactory.CreateCommandBuilder();
        }

        public override DbConnection CreateConnection()
        {
            var profiler = MiniProfiler.Current;

            var connection = this.dbProviderFactory.CreateConnection();

            return profiler != null
                ? new ProfiledDbConnection(connection, MiniProfiler.Current)
                : connection;
        }

        public override DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return this.dbProviderFactory.CreateConnectionStringBuilder();
        }

        public override DbDataAdapter CreateDataAdapter()
        {
            return this.dbProviderFactory.CreateDataAdapter();
        }

        public override DbDataSourceEnumerator CreateDataSourceEnumerator()
        {
            return this.dbProviderFactory.CreateDataSourceEnumerator();
        }

        public override DbParameter CreateParameter()
        {
            return this.dbProviderFactory.CreateParameter();
        }

        public override System.Security.CodeAccessPermission CreatePermission(System.Security.Permissions.PermissionState state)
        {
            return this.dbProviderFactory.CreatePermission(state);
        }
    }
}