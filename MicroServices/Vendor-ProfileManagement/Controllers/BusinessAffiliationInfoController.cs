using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Models.BusinessAffiliationInfo;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Controllers
{
    [ApiController]
    [Route("Vendor/[controller]")]
    public class BusinessAffiliationInfoController : ControllerBase
    {
      private readonly IBusinessAffiliationInfoService _BusinessAffiliationInfoService;
        public BusinessAffiliationInfoController(IBusinessAffiliationInfoService BusinessAffiliationInfoService)
        {
            _BusinessAffiliationInfoService = BusinessAffiliationInfoService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _BusinessAffiliationInfoService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _BusinessAffiliationInfoService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save([FromForm] BusinessAffiliationInfoFullDataModel model)
        {
            return Ok(await _BusinessAffiliationInfoService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _BusinessAffiliationInfoService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _BusinessAffiliationInfoService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _BusinessAffiliationInfoService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _BusinessAffiliationInfoService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _BusinessAffiliationInfoService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
