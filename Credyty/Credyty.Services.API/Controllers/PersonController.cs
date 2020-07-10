using System.Threading.Tasks;
using Credyty.Aplication.DTO;
using Credyty.Aplication.Interfaces;
using Credyty.Domain.Entities.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Credyty.Services.API.Controllers
{
    /// <summary>
    /// PersonController
    /// </summary>
    [EnableCors("policyApiAcademycSuite")]
    [Route("api/[controller]/[action]")]
    [ApiController]    
    public class PersonController : ControllerBase
    {
        #region Globals
        private readonly IPersonAplication _personAplication;
        #endregion

        #region Constructor
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="personAplication"></param>
        public PersonController(IPersonAplication personAplication)
        {
            _personAplication = personAplication;

        }
        #endregion

        #region Public methods
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result<dynamic>> Insert(CreatePersonDTO parameters)
        {
            return await _personAplication.Insert(parameters);           
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result<dynamic>> Update(ModifyPersonDTO parameters)
        {
            return await _personAplication.Update(parameters);
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result<dynamic>> Delete(DeleteDTO parameters)
        {
            return await _personAplication.Delete(parameters);
        }
        /// <summary>
        /// List all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result<dynamic>> All()
        {
            return await _personAplication.All();
        }
        /// <summary>
        /// List
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result<dynamic>> List(int personID)
        {
            return await _personAplication.List(personID);
        }
        #endregion
    }
}