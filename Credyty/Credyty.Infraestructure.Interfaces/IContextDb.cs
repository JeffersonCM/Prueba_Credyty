using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Credyty.Infraestructure.Interfaces
{
    public interface IContextDb
    {
        IDbConnection OpenConnection { get; }
        IDbTransaction StartTransaction { get; }
        void CloseConexion(IDbConnection conexion);
        void CommitTransaction(IDbTransaction transaccion);
        void RollbackTransaction(IDbTransaction transaccion);
    }
}
