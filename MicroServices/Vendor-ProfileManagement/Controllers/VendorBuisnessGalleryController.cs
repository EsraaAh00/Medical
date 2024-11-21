using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Models.VendorBusinessGallery;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Controllers
{
    [ApiController]
    [Route("Vendor/[controller]")]
    public class VendorBusinessGalleryController : ControllerBase
    {
        private readonly IVendorBusinessGalleryService _VendorBusinessGalleryService;
        public VendorBusinessGalleryController(IVendorBusinessGalleryService VendorBusinessGalleryService)
        {
            _VendorBusinessGalleryService = VendorBusinessGalleryService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _VendorBusinessGalleryService.GetById(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save([FromForm] VendorBusinessGalleryFullDataModel model)
        {
            return Ok(await _VendorBusinessGalleryService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(PagedFilterModel filter)
        {
            return Ok(await _VendorBusinessGalleryService.GetPagedList(filter));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _VendorBusinessGalleryService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _VendorBusinessGalleryService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
