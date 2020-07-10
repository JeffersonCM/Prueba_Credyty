using Credyty.Aplication.DTO;
using Credyty.Domain.Entities.Models;
using System.Threading.Tasks;

namespace Credyty.Aplication.Interfaces
{
    public interface IPersonAplication
    {
        Task<Result<dynamic>> Insert(CreatePersonDTO parameters);
        Task<Result<dynamic>> Update(ModifyPersonDTO parameters);
        Task<Result<dynamic>> Delete(DeleteDTO parameters);
        Task<Result<dynamic>> All();
        Task<Result<dynamic>> List(int personID);
    }
}
