using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Credyty.Infraestructure.Interfaces
{
    public interface ICommonRepository<T> where T : class
    {
        Task<T> Insert(IDbTransaction transaction, T entity);
        Task<IEnumerable<T>> ListAll(IDbConnection connection);
        Task<IEnumerable<T>> ListAll(IDbTransaction transaction);
        Task<IEnumerable<T>> ListByWhere(IDbConnection connection, string where, object parameters);
        Task<IEnumerable<T>> ListByWhere(IDbTransaction transaction, string where, object parameters);
        Task Delete(IDbTransaction transaction, T entity);
        Task Update(IDbTransaction transaction, T entity);
    }
}
