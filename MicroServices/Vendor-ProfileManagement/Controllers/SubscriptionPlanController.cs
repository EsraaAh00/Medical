using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Models.SubscriptionPlan;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Vendor/[controller]")]
    public class SubscriptionPlanController : ControllerBase
    {
        private readonly ISubscriptionPlanService _SubscriptionPlanService;
        public SubscriptionPlanController(ISubscriptionPlanService SubscriptionPlanService)
        {
            _SubscriptionPlanService = SubscriptionPlanService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _SubscriptionPlanService.GetById(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(SubscriptionPlanFullDataModel model)
        {
            return Ok(await _SubscriptionPlanService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _SubscriptionPlanService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _SubscriptionPlanService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _SubscriptionPlanService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _SubscriptionPlanService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _SubscriptionPlanService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
