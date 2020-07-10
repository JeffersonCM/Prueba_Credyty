using Credyty.Domain.Entities;
using Credyty.Domain.Entities.Models;
using Credyty.Domain.Interfaces;
using Credyty.Infraestructure.Interfaces;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Credyty.Domain.Implementation
{
    public class GeneralDataDomain : IGeneralDataDomain
    {
        #region Globals
        private readonly ICommonRepository<Tab_GeneralData> _generalDataRepo;
        private readonly ICommonRepository<Tab_GeneralDataDetail> _generalDataDetailRepo;
        #endregion

        #region Builder
        public GeneralDataDomain(ICommonRepository<Tab_GeneralData> generalDataRepo, ICommonRepository<Tab_GeneralDataDetail> generalDataDetailRepo)
        {
            _generalDataRepo = generalDataRepo;
            _generalDataDetailRepo = generalDataDetailRepo;
        }
        #endregion

        public async Task<Result<dynamic>> All_GeneralData(IDbConnection connection)
        {
            var listDataGeneral = await _generalDataRepo.ListAll(connection);

            return new Result<dynamic>() { Successful = true, Error = false, Response = listDataGeneral };
        }

        public async Task<Result<dynamic>> List_GeneralData(IDbConnection connection, int generalDataID)
        {
            var generalData = (await _generalDataRepo.ListByWhere(connection, $"{nameof(Tab_GeneralData.ID)} = @ID", new { ID = generalDataID })).SingleOrDefault();

            if (generalData == null)
                return new Result<dynamic>() { Successful = false, Error = false };

            return new Result<dynamic>() { Successful = true, Error = false, Response = generalData };
        }

        public async Task<Result<dynamic>> List_GeneralDataDetails(IDbConnection connection, int generalDataID)
        {
            var generalDataDetail = await _generalDataDetailRepo.ListByWhere(connection, $"{nameof(Tab_GeneralDataDetail.GeneralDataID)} = @GeneralDataID", new { GeneralDataID = generalDataID });

            if (!generalDataDetail.Any())
                return new Result<dynamic>() { Successful = false, Error = false };

            return new Result<dynamic>() { Successful = true, Error = false, Response = generalDataDetail };
        }

    }
}
