using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Credyty.Aplication.DTO;
using Credyty.Aplication.Interfaces;
using Credyty.Domain.Entities.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Credyty.Services.API.Controllers
{
    /// <summary>
    /// CreditRequestController
    /// </summary>
    [EnableCors("policyApiAcademycSuite")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CreditRequestController : ControllerBase
    {
        #region Globals
        private readonly ICreditRequestAplication _creditRequestAplication;
        #endregion

        #region Builder
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="creditRequestAplication"></param>
        public CreditRequestController(ICreditRequestAplication creditRequestAplication)
        {
            _creditRequestAplication = creditRequestAplication;

        }
        #endregion

        #region Public methods
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result<dynamic>> Insert(CreateRequestCreditDTO parameters)
        {
            return await _creditRequestAplication.Insert(parameters);
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result<dynamic>> Update(ModifyRequestCreditDTO parameters)
        {
            return await _creditRequestAplication.Update(parameters);
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result<dynamic>> Delete(DeleteDTO parameters)
        {
            return await _creditRequestAplication.Delete(parameters);
        }
        /// <summary>
        /// List all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result<dynamic>> All()
        {
            return await _creditRequestAplication.All();
        }
        /// <summary>
        /// List
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result<dynamic>> List(int personID)
        {
            return await _creditRequestAplication.List(personID);
        }
        #endregion
    }
}