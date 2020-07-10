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
    public class PersonAplication : IPersonAplication
    {
        #region Globals
        private readonly IContextDb _contextDb;
        private readonly IPersonDomain _personDomain;
        private readonly IMapper _mapper;
        IDbTransaction transaction = null;
        IDbConnection connection = null;
        #endregion

        #region Builder
        public PersonAplication(IContextDb contextDb, IPersonDomain personDomain, IMapper mapper)
        {
            _contextDb = contextDb;
            _personDomain = personDomain;
            _mapper = mapper;
        }
        #endregion

        #region Public methods
        public async Task<Result<dynamic>> All()
        {
            try
            {
                connection = _contextDb.OpenConnection;
                
                var response = await _personDomain.All(connection);

                _contextDb.CloseConexion(connection);

                return response;
            }
            catch (Exception)
            {
                _contextDb.CloseConexion(connection);                
                return new Result<dynamic>() { Successful = false, Error = true};
            }
        }
        public async Task<Result<dynamic>> List(int personID)
        {
            try
            {
                connection = _contextDb.OpenConnection;

                var response = await _personDomain.List(connection, personID);

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

                
                var response = await _personDomain.Delete(transaction, _mapper.Map<Mod_Delete>(parameters));

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
        public async Task<Result<dynamic>> Insert(CreatePersonDTO parameters)
        {
            try
            {
                transaction = _contextDb.StartTransaction;


                var response = await _personDomain.Insert(transaction, _mapper.Map<Mod_CreatePerson>(parameters));

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
        public async Task<Result<dynamic>> Update(ModifyPersonDTO parameters)
        {
            try
            {
                transaction = _contextDb.StartTransaction;


                var response = await _personDomain.Update(transaction, _mapper.Map<Mod_ModifyPerson>(parameters));

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
