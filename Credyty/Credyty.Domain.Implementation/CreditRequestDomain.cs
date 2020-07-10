using Credyty.Domain.Entities;
using Credyty.Domain.Entities.Models;
using Credyty.Domain.Interfaces;
using Credyty.Infraestructure.Interfaces;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Credyty.Domain.Implementation
{
    public class CreditRequestDomain : ICreditRequestDomain
    {
        #region Variables globales
        private readonly ICommonRepository<Tab_CreditRequest> _creditRequestRepo;
        #endregion

        #region Contructor
        public CreditRequestDomain(ICommonRepository<Tab_CreditRequest> creditRequestRepo)
        {
            _creditRequestRepo = creditRequestRepo;
        }
        #endregion

        public async Task<Result<dynamic>> All(IDbConnection connection)
        {
            var listcreditRequest = await _creditRequestRepo.ListAll(connection);

            return new Result<dynamic>() { Successful = true, Error = false, Response = listcreditRequest };
        }

        public async Task<Result<dynamic>> Delete(IDbTransaction transaction, Mod_Delete parameters)
        {
            var creditRequest = (await _creditRequestRepo.ListByWhere(transaction, $"{nameof(Tab_CreditRequest.ID)} = @ID", new { parameters.ID })).SingleOrDefault();

            if (creditRequest != null)
            {
                await _creditRequestRepo.Delete(transaction, creditRequest);
                return new Result<dynamic>() { Successful = true, Error = false };
            }

            return new Result<dynamic>() { Successful = false, Error = false };
        }

        public async Task<Result<dynamic>> Insert(IDbTransaction transaction, Mod_CreateRequestCredit parameters)
        {
            Tab_CreditRequest creditRequest = new Tab_CreditRequest()
            {
                PersonID = parameters.PersonID,
                University = parameters.University,
                Career = parameters.Career,
                Amount = parameters.Amount,
                StateID = parameters.StateID
            };

            creditRequest = await _creditRequestRepo.Insert(transaction, creditRequest);

            return new Result<dynamic>() { Successful = true, Error = false, Response = creditRequest };
        }

        public async Task<Result<dynamic>> List(IDbConnection connection, int creditRequestID)
        {
            var creditRequestList = await _creditRequestRepo.ListByWhere(connection, $"{nameof(Tab_CreditRequest.ID)} = @ID", new { ID = creditRequestID });

            if (!creditRequestList.Any())
                return new Result<dynamic>() { Successful = false, Error = false };

            return new Result<dynamic>() { Successful = true, Error = false, Response = creditRequestList };
        }

        public async Task<Result<dynamic>> Update(IDbTransaction transaction, Mod_ModifyRequestCredit parameters)
        {
            var creditRequest = (await _creditRequestRepo.ListByWhere(transaction, $"{nameof(Tab_CreditRequest.ID)} = @ID", new { parameters.ID })).SingleOrDefault();

            if (creditRequest == null)
                return new Result<dynamic>() { Successful = false, Error = false };

            Tab_CreditRequest newcreditRequest = new Tab_CreditRequest()
            {
                ID = creditRequest.ID,
                PersonID = parameters.PersonID,
                University = parameters.University,
                Career = parameters.Career,
                Amount = parameters.Amount,
                StateID = parameters.StateID
            };

            await _creditRequestRepo.Update(transaction, newcreditRequest);

            return new Result<dynamic>() { Successful = true, Error = false, Response = newcreditRequest };
        }
    }
}

