using Credyty.Domain.Entities.Models;
using System.Data;
using System.Threading.Tasks;

namespace Credyty.Domain.Interfaces
{
    public interface IPersonDomain
    {
        Task<Result<dynamic>> Insert(IDbTransaction transaction, Mod_CreatePerson parameters);
        Task<Result<dynamic>> Update(IDbTransaction transaction, Mod_ModifyPerson parameters);
        Task<Result<dynamic>> Delete(IDbTransaction transaction, Mod_Delete parameters);
        Task<Result<dynamic>> All(IDbConnection connection);
        Task<Result<dynamic>> List(IDbConnection connection, int personID);
    }
}
