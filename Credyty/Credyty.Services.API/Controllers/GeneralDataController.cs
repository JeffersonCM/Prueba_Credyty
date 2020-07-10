using Credyty.Aplication.Interfaces;
using Credyty.Domain.Entities.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Credyty.Services.API.Controllers
{
    /// <summary>
    /// GeneralDataController
    /// </summary>
    [EnableCors("policyApiAcademycSuite")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GeneralDataController : ControllerBase
    {
        #region Globals
        private readonly IGeneralDataAplication _generalDataAplication;
        #endregion

        #region Constructor
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="generalDataAplication"></param>
        public GeneralDataController(IGeneralDataAplication generalDataAplication)
        {
            _generalDataAplication = generalDataAplication;
        }
        #endregion
        /// <summary>
        /// All_GeneralData
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result<dynamic>> All_GeneralData()
        {
            return await _generalDataAplication.All_GeneralData();
        }
        /// <summary>
        /// List_GeneralData
        /// </summary>
        /// <param name="generalDataID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result<dynamic>> List_GeneralData(int generalDataID)
        {
            return await _generalDataAplication.List_GeneralData(generalDataID);
        }
        /// <summary>
        /// List_GeneralDataDetails
        /// </summary>
        /// <param name="generalDataID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result<dynamic>> List_GeneralDataDetails(int generalDataID)
        {
            return await _generalDataAplication.List_GeneralDataDetails(generalDataID);
        }
    }
}