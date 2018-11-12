using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace BirdSightings
{
    public class ApplicationDbContext : System.Data.Common.DbConnection, IDisposable, System.Data.IDbConnection
    {
        private IConfiguration conf;
        private System.Data.Common.DbConnection conn;

        public ApplicationDbContext(IConfiguration conf) {
            this.conf = conf;
            conn = NpgsqlFactory.Instance.CreateConnection();
            conn.ConnectionString = conf.GetConnectionString("DbConnection");
        }

        public override string ConnectionString { get => conn.ConnectionString; set => conn.ConnectionString = value; }

        public override string Database => conn.Database;

        public override string DataSource => conn.DataSource;

        public override string ServerVersion => conn.ServerVersion;

        public override ConnectionState State => conn.State;

        public override void ChangeDatabase(string databaseName) {
            conn.ChangeDatabase(databaseName);
        }

        public override void Close() {
            conn.Close();
        }

        public override void Open() {
            conn.Open();
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel) {
            return conn.BeginTransaction(isolationLevel);
        }

        protected override DbCommand CreateDbCommand() {
            return conn.CreateCommand();
        }

        #region IDisposable Support

        protected override void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                if (conn != null) {
                    conn.Close();
                }

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~ApplicationDbContext() {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public new void Dispose() {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        private bool disposedValue = false; // To detect redundant calls    }
    }
    #endregion
}