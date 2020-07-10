using Credyty.Infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Credyty.Infraestructure.DataAccess
{
    public class ContextDb : IContextDb
    {
        #region Globals
        private readonly IConfiguration _configuration;
        #endregion

        #region Builder
        public ContextDb(IConfiguration configuration)
        {
            _configuration = configuration;           
        }
        #endregion

        #region Public methods
        public IDbConnection OpenConnection
        {
            get
            {
                return Connection();
            }
        }
        public IDbTransaction StartTransaction
        {
            get
            {
                var connection = Connection();               
                return connection.BeginTransaction();
            }
        }
        public void CloseConexion(IDbConnection connection)
        {
            connection.Close();
            connection.Dispose();
        }
        public void CommitTransaction(IDbTransaction transaction)
        {
            transaction.Commit();
            transaction.Dispose();
        }
        public void RollbackTransaction(IDbTransaction transaction)
        {
            if (transaction != null)
                transaction.Rollback();

            transaction.Dispose();
        }
        #endregion

        #region Private methods
        private SqlConnection Connection()
        {
            var connection = new SqlConnection();

            if (connection == null)
                return null;

            connection.ConnectionString = _configuration.GetConnectionString("_ConnectionString").ToString();
            connection.Open();
            
            return connection;
        }
        #endregion
    }
}
