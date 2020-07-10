using Credyty.Aplication.DTO;
using Credyty.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Credyty.Aplication.Interfaces
{
    public interface ICreditRequestAplication
    {
        Task<Result<dynamic>> Insert(CreateRequestCreditDTO parameters);
        Task<Result<dynamic>> Update(ModifyRequestCreditDTO parameters);
        Task<Result<dynamic>> Delete(DeleteDTO parameters);
        Task<Result<dynamic>> All();
        Task<Result<dynamic>> List(int RequestCreditID);
    }
}
