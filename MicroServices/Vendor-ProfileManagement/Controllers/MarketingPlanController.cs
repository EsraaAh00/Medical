using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Models.MarketingPlan;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Vendor/[controller]")]
    public class MarketingPlanController : ControllerBase
    {
        private readonly IMarketingPlanService _MarketingPlanService;
        public MarketingPlanController(IMarketingPlanService MarketingPlanService)
        {
            _MarketingPlanService = MarketingPlanService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _MarketingPlanService.GetById(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(MarketingPlanFullDataModel model)
        {
            return Ok(await _MarketingPlanService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _MarketingPlanService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _MarketingPlanService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _MarketingPlanService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _MarketingPlanService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _MarketingPlanService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
