using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Models.Client;
using Client_ClientProfileManagement.Models.ClientPrescribtion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models.Filter;

namespace Client_ClientProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Client/[controller]")]
    public class ClientPrescribtionController : ControllerBase
    {
        private readonly IClientPrescribtionService _ClientPrescribtionService;
        public ClientPrescribtionController(IClientPrescribtionService ClientPrescribtionService)
        {
            _ClientPrescribtionService = ClientPrescribtionService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ClientPrescribtionService.GetById(id));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save(ClientPrescribtionFullDataModel model)
        {
            return Ok(await _ClientPrescribtionService.Save(model));
        }

        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _ClientPrescribtionService.GetPagedList(filter));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ClientPrescribtionService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ClientPrescribtionService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
