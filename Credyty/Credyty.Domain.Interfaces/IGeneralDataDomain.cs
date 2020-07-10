using Credyty.Domain.Entities.Models;
using System.Data;
using System.Threading.Tasks;

namespace Credyty.Domain.Interfaces
{
    public interface IGeneralDataDomain
    {
        Task<Result<dynamic>> All_GeneralData(IDbConnection connection);
        Task<Result<dynamic>> List_GeneralData(IDbConnection connection, int requestCreditID);
        Task<Result<dynamic>> List_GeneralDataDetails(IDbConnection connection, int reneralDataID);
    }
}
