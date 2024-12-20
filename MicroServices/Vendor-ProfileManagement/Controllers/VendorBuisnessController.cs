using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Models.VendorBusiness;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("Vendor/[controller]")]
    public class VendorBusinessController : ControllerBase
    {
        private readonly IVendorBusinessService _VendorBusinessService;
        public VendorBusinessController(IVendorBusinessService VendorBusinessService)
        {
            _VendorBusinessService = VendorBusinessService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _VendorBusinessService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _VendorBusinessService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save([FromForm] VendorBusinessFullDataModel model)
        {
            return Ok(await _VendorBusinessService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _VendorBusinessService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _VendorBusinessService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _VendorBusinessService.GetIncludeByIdsList(ids));
        }
        [HttpGet("GetBusinessStatusEnumDropDownList")]
        public ActionResult GetBusinessStatusEnumDropDownList()
        {
            return Ok(_VendorBusinessService.GetBusinessStatusEnumDropDownList());
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _VendorBusinessService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _VendorBusinessService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
