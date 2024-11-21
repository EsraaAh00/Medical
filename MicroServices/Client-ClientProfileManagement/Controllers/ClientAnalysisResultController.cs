using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Models.Client;
using Client_ClientProfileManagement.Models.ClientAnalysisResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models.Filter;

namespace Client_ClientProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Client/[controller]")]
    public class ClientAnalysisResultController : ControllerBase
    {
        private readonly IClientAnalysisResultService _ClientAnalysisResultService;
        public ClientAnalysisResultController(IClientAnalysisResultService ClientAnalysisResultService)
        {
            _ClientAnalysisResultService = ClientAnalysisResultService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ClientAnalysisResultService.GetById(id));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save(ClientAnalysisResultFullDataModel model)
        {
            return Ok(await _ClientAnalysisResultService.Save(model));
        }

        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _ClientAnalysisResultService.GetPagedList(filter));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ClientAnalysisResultService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ClientAnalysisResultService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
