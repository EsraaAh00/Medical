using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models.Filter;
using Client_ClientRelationMangement.Interfaces.Services;
using Client_ClientRelationMangement.Models.Sanction;

namespace Client_ClientRelationMangement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("System/Crm/[controller]")]
    public class SanctionController : ControllerBase
    {
        private readonly ISanctionService _SanctionService;
        public SanctionController(ISanctionService SanctionService)
        {
            _SanctionService = SanctionService;
        }

        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _SanctionService.GetById(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(SanctionFullDataModel model)
        {
            return Ok(await _SanctionService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _SanctionService.GetPagedList(filter));
        }
        #endregion

        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _SanctionService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _SanctionService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
