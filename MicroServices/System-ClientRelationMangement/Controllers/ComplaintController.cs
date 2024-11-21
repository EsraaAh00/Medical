using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System_ClientRelationMangement.Interfaces.Services;
using System_ClientRelationMangement.Models.Complaint;
using SharedModels.Models.Filter;

namespace System_ClientRelationMangement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("System/Crm/[controller]")]
    public class ComplaintController : ControllerBase
    {
        private readonly IComplaintService _ComplaintService;
        public ComplaintController(IComplaintService ComplaintService)
        {
            _ComplaintService = ComplaintService;
        }

        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ComplaintService.GetById(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(ComplaintFullDataModel model)
        {
            return Ok(await _ComplaintService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _ComplaintService.GetPagedList(filter));
        }
        #endregion

        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ComplaintService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ComplaintService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
