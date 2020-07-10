using Credyty.Domain.Entities;
using Credyty.Domain.Entities.Models;
using Credyty.Domain.Interfaces;
using Credyty.Infraestructure.Interfaces;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Credyty.Domain.Implementation
{
    public class PersonDomain : IPersonDomain
    {
        #region Variables globales
        private readonly ICommonRepository<Tab_Person> _personRepo;
        #endregion

        #region Contructor
        public PersonDomain(ICommonRepository<Tab_Person> personRepo)
        {
            _personRepo = personRepo;
        }
        #endregion

        public async Task<Result<dynamic>> All(IDbConnection connection)
        {
            var listPerson = await _personRepo.ListAll(connection);

            return new Result<dynamic>() { Successful = true, Error = false, Response = listPerson };
        }

        public async Task<Result<dynamic>> Delete(IDbTransaction transaction, Mod_Delete parameters)
        {
            var person = (await _personRepo.ListByWhere(transaction, $"{nameof(Tab_Person.ID)} = @ID", new { parameters.ID })).SingleOrDefault();

            if (person != null)
            {
                await _personRepo.Delete(transaction, person);
                return new Result<dynamic>() { Successful = true, Error = false };
            }

            return new Result<dynamic>() { Successful = false, Error = false };
        }

        public async Task<Result<dynamic>> Insert(IDbTransaction transaction, Mod_CreatePerson parameters)
        {
            Tab_Person person = new Tab_Person()
            {
                FirstName = parameters.FirstName,
                LastName = parameters.LastName,
                IdentificationType = parameters.IdentificationType,
                IdentificationNumber = parameters.IdentificationNumber,
                GenderID = parameters.GenderID,
                Address = parameters.Address,
                Phone = parameters.Phone,
                Email = parameters.Email
            };

            person = await _personRepo.Insert(transaction, person);

            return new Result<dynamic>() { Successful = true, Error = false, Response = person };
        }

        public async Task<Result<dynamic>> List(IDbConnection connection, int personID)
        {
            var personList = await _personRepo.ListByWhere(connection, $"{nameof(Tab_Person.ID)} = @ID", new { ID = personID });

            if (!personList.Any())
                return new Result<dynamic>() { Successful = false, Error = false };

            return new Result<dynamic>() { Successful = true, Error = false, Response = personList };
        }

        public async Task<Result<dynamic>> Update(IDbTransaction transaction, Mod_ModifyPerson parameters)
        {
            var person = (await _personRepo.ListByWhere(transaction, $"{nameof(Tab_Person.ID)} = @ID", new { parameters.ID })).SingleOrDefault();

            if (person == null)
                return new Result<dynamic>() { Successful = false, Error = false };

            Tab_Person newPerson = new Tab_Person()
            {
                ID = person.ID,
                FirstName = parameters.FirstName,
                LastName = parameters.LastName,
                IdentificationType = parameters.IdentificationType,
                IdentificationNumber = parameters.IdentificationNumber,
                GenderID = parameters.GenderID,
                Address = parameters.Address,
                Phone = parameters.Phone,
                Email = parameters.Email
            };

            await _personRepo.Update(transaction, newPerson);

            return new Result<dynamic>() { Successful = true, Error = false, Response = newPerson };
        }
    }
}
