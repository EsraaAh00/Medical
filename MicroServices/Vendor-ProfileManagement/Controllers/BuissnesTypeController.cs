using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Models.BusinessType;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("Vendor/[controller]")]
    public class BusinessTypeController : ControllerBase
    {
        private readonly IBusinessTypeService _BusinessTypeService;
        public BusinessTypeController(IBusinessTypeService BusinessTypeService)
        {
            _BusinessTypeService = BusinessTypeService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _BusinessTypeService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await  _BusinessTypeService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(BusinessTypeFullDataModel model)
        {
            return Ok(await _BusinessTypeService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _BusinessTypeService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _BusinessTypeService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _BusinessTypeService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _BusinessTypeService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _BusinessTypeService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
