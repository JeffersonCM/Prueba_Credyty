using Credyty.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Credyty.Aplication.Interfaces
{
    public interface IGeneralDataAplication
    {
        Task<Result<dynamic>> All_GeneralData();
        Task<Result<dynamic>> List_GeneralData(int generalDataID);
        Task<Result<dynamic>> List_GeneralDataDetails(int generalDataID);
    }
}
