using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Models.Client;
using Client_ClientProfileManagement.Models.ClientInsurance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models.Filter;

namespace Client_ClientProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Client/[controller]")]
    public class ClientInsuranceController : ControllerBase
    {
        private readonly IClientInsuranceService _ClientInsuranceService;
        public ClientInsuranceController(IClientInsuranceService ClientInsuranceService)
        {
            _ClientInsuranceService = ClientInsuranceService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ClientInsuranceService.GetById(id));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save(ClientInsuranceFullDataModel model)
        {
            return Ok(await _ClientInsuranceService.Save(model));
        }

        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _ClientInsuranceService.GetPagedList(filter));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ClientInsuranceService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ClientInsuranceService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
