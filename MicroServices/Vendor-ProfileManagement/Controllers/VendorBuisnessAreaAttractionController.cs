using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Models.VendorBusinessAreaAttraction;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Vendor/[controller]")]
    public class VendorBusinessAreaAttractionController : ControllerBase
    {
        private readonly IVendorBusinessAreaAttractionService _VendorBusinessAreaAttractionService;
        public VendorBusinessAreaAttractionController(IVendorBusinessAreaAttractionService VendorBusinessAreaAttractionService)
        {
            _VendorBusinessAreaAttractionService = VendorBusinessAreaAttractionService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _VendorBusinessAreaAttractionService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _VendorBusinessAreaAttractionService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save([FromForm] VendorBusinessAreaAttractionFullDataModel model)
        {
            return Ok(await _VendorBusinessAreaAttractionService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _VendorBusinessAreaAttractionService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _VendorBusinessAreaAttractionService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _VendorBusinessAreaAttractionService.GetIncludeByIdsList(ids));
        }
        [HttpGet("GetDistanceUnitEnumDropDownList")]
        public ActionResult GetDistanceUnitEnumDropDownList()
        {
            return Ok(_VendorBusinessAreaAttractionService.GetDistanceUnitEnumDropDownList());
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _VendorBusinessAreaAttractionService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _VendorBusinessAreaAttractionService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
