using Credyty.Aplication.Interfaces;
using Credyty.Domain.Entities.Models;
using Credyty.Domain.Interfaces;
using Credyty.Infraestructure.Interfaces;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Credyty.Aplication.Implementation
{
    public class GeneralDataAplication : IGeneralDataAplication
    {
        #region Globals
        private readonly IContextDb _contextDb;
        private readonly IGeneralDataDomain _generalDataDomain;
        IDbConnection connection = null;
        #endregion

        #region Builder
        public GeneralDataAplication(IContextDb contextDb, IGeneralDataDomain generalDataDomain)
        {
            _contextDb = contextDb;
            _generalDataDomain = generalDataDomain;
        }
        #endregion

        #region Public methods
        public async Task<Result<dynamic>> All_GeneralData()
        {
            try
            {
                connection = _contextDb.OpenConnection;

                var response = await _generalDataDomain.All_GeneralData(connection);

                _contextDb.CloseConexion(connection);

                return response;
            }
            catch (Exception)
            {
                _contextDb.CloseConexion(connection);
                return new Result<dynamic>() { Successful = false, Error = true };
            }
        }
        public async Task<Result<dynamic>> List_GeneralData(int generalDataDetail)
        {
            try
            {
                connection = _contextDb.OpenConnection;

                var response = await _generalDataDomain.List_GeneralData(connection, generalDataDetail);

                _contextDb.CloseConexion(connection);

                return response;
            }
            catch (Exception)
            {
                _contextDb.CloseConexion(connection);
                return new Result<dynamic>() { Successful = false, Error = true };
            }
        }
        public async Task<Result<dynamic>> List_GeneralDataDetails(int generalDataID)
        {
            try
            {
                connection = _contextDb.OpenConnection;

                var response = await _generalDataDomain.List_GeneralDataDetails(connection, generalDataID);

                _contextDb.CloseConexion(connection);

                return response;
            }
            catch (Exception)
            {
                _contextDb.CloseConexion(connection);
                return new Result<dynamic>() { Successful = false, Error = true };
            }
        }
        #endregion
    }
}
