using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models.Filter;
using Client_ClientRelationMangement.Models.ComplaintAction;
using Client_ClientRelationMangement.Interfaces.Services;

namespace Client_ClientRelationMangement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("System/Crm/[controller]")]
    public class ComplaintActionController : ControllerBase
    {
        private readonly IComplaintActionService _ComplaintActionService;
        public ComplaintActionController(IComplaintActionService ComplaintActionService)
        {
            _ComplaintActionService = ComplaintActionService;
        }

        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ComplaintActionService.GetById(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(ComplaintActionFullDataModel model)
        {
            return Ok(await _ComplaintActionService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _ComplaintActionService.GetPagedList(filter));
        }
        #endregion

        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ComplaintActionService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ComplaintActionService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
