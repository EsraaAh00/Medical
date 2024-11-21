using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Models.DiscountPlan;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Vendor/[controller]")]
    public class DiscountPlanController : ControllerBase
    {
        private readonly IDiscountPlanService _DiscountPlanService;
        public DiscountPlanController(IDiscountPlanService DiscountPlanService)
        {
            _DiscountPlanService = DiscountPlanService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _DiscountPlanService.GetById(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(DiscountPlanFullDataModel model)
        {
            return Ok(await _DiscountPlanService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _DiscountPlanService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _DiscountPlanService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _DiscountPlanService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _DiscountPlanService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _DiscountPlanService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
