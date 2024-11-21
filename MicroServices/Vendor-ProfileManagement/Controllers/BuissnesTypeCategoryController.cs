using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Models.BusinessTypeCategory;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("Vendor/[controller]")]
    public class BusinessTypeCategoryController : ControllerBase
    {
        private readonly IBusinessTypeCategoryService _BusinessTypeCategoryService;
        public BusinessTypeCategoryController(IBusinessTypeCategoryService BusinessTypeCategoryService)
        {
            _BusinessTypeCategoryService = BusinessTypeCategoryService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _BusinessTypeCategoryService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _BusinessTypeCategoryService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(BusinessTypeCategoryFullDataModel model)
        {
            return Ok(await _BusinessTypeCategoryService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _BusinessTypeCategoryService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList(int ?BusinessTypeId)
        {
            return Ok(await _BusinessTypeCategoryService.GetDropDownList(BusinessTypeId));
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _BusinessTypeCategoryService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _BusinessTypeCategoryService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _BusinessTypeCategoryService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
