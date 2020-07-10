using AutoMapper;
using Credyty.Aplication.DTO;
using Credyty.Aplication.Interfaces;
using Credyty.Domain.Entities.Models;
using Credyty.Domain.Interfaces;
using Credyty.Infraestructure.Interfaces;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Credyty.Aplication.Implementation
{
    public class CreditRequestAplication : ICreditRequestAplication
    {
        #region Globals
        private readonly IContextDb _contextDb;
        private readonly ICreditRequestDomain _creditRequestDomain;
        private readonly IMapper _mapper;
        IDbTransaction transaction = null;
        IDbConnection connection = null;
        #endregion

        #region Builder
        public CreditRequestAplication(IContextDb contextDb, ICreditRequestDomain creditRequestDomain, IMapper mapper)
        {
            _contextDb = contextDb;
            _creditRequestDomain = creditRequestDomain;
            _mapper = mapper;
        }
        #endregion

        #region Public methods
        public async Task<Result<dynamic>> All()
        {
            try
            {
                connection = _contextDb.OpenConnection;

                var response = await _creditRequestDomain.All(connection);

                _contextDb.CloseConexion(connection);

                return response;
            }
            catch (Exception)
            {
                _contextDb.CloseConexion(connection);
                return new Result<dynamic>() { Successful = false, Error = true };
            }
        }
        public async Task<Result<dynamic>> List(int creditRequestID)
        {
            try
            {
                connection = _contextDb.OpenConnection;

                var response = await _creditRequestDomain.List(connection, creditRequestID);

                _contextDb.CloseConexion(connection);

                return response;
            }
            catch (Exception)
            {
                _contextDb.CloseConexion(connection);
                return new Result<dynamic>() { Successful = false, Error = true };
            }
        }
        public async Task<Result<dynamic>> Delete(DeleteDTO parameters)
        {
            try
            {
                transaction = _contextDb.StartTransaction;


                var response = await _creditRequestDomain.Delete(transaction, _mapper.Map<Mod_Delete>(parameters));

                if (!response.Successful)
                    _contextDb.RollbackTransaction(transaction);
                else
                    _contextDb.CommitTransaction(transaction);

                return response;
            }
            catch (Exception)
            {
                _contextDb.RollbackTransaction(transaction);
                return new Result<dynamic>() { Successful = false, Error = true };
            }
        }
        public async Task<Result<dynamic>> Insert(CreateRequestCreditDTO parameters)
        {
            try
            {
                transaction = _contextDb.StartTransaction;


                var response = await _creditRequestDomain.Insert(transaction, _mapper.Map<Mod_CreateRequestCredit>(parameters));

                if (!response.Successful)
                    _contextDb.RollbackTransaction(transaction);
                else
                    _contextDb.CommitTransaction(transaction);

                return response;
            }
            catch (Exception)
            {
                _contextDb.RollbackTransaction(transaction);
                return new Result<dynamic>() { Successful = false, Error = true };
            }
        }
        public async Task<Result<dynamic>> Update(ModifyRequestCreditDTO parameters)
        {
            try
            {
                transaction = _contextDb.StartTransaction;


                var response = await _creditRequestDomain.Update(transaction, _mapper.Map<Mod_ModifyRequestCredit>(parameters));

                if (!response.Successful)
                    _contextDb.RollbackTransaction(transaction);
                else
                    _contextDb.CommitTransaction(transaction);

                return response;
            }
            catch (Exception)
            {
                _contextDb.RollbackTransaction(transaction);
                return new Result<dynamic>() { Successful = false, Error = true };
            }
        }
        #endregion
    }
}
