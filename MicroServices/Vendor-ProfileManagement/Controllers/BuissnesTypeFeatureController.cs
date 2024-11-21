using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Models.BusinessTypeFeature;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Vendor/[controller]")]
    public class BusinessTypeFeatureController : ControllerBase
    {
        private readonly IBusinessTypeFeatureService _BusinessTypeFeatureService;
        public BusinessTypeFeatureController(IBusinessTypeFeatureService BusinessTypeFeatureService)
        {
            _BusinessTypeFeatureService = BusinessTypeFeatureService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _BusinessTypeFeatureService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _BusinessTypeFeatureService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(BusinessTypeFeatureFullDataModel model)
        {
            return Ok(await _BusinessTypeFeatureService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _BusinessTypeFeatureService.GetPagedList(filter));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _BusinessTypeFeatureService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _BusinessTypeFeatureService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
