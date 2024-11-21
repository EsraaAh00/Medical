using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Models.VendorBusinessFacility;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Vendor/[controller]")]
    public class VendorBusinessFacilityController : ControllerBase
    {
        private readonly IVendorBusinessFacilityService _VendorBusinessFacilityService;
        public VendorBusinessFacilityController(IVendorBusinessFacilityService VendorBusinessFacilityService)
        {
            _VendorBusinessFacilityService = VendorBusinessFacilityService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _VendorBusinessFacilityService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _VendorBusinessFacilityService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(VendorBusinessFacilityFullDataModel model)
        {
            return Ok(await _VendorBusinessFacilityService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(PagedFilterModel filter)
        {
            return Ok(await _VendorBusinessFacilityService.GetPagedList(filter));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _VendorBusinessFacilityService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _VendorBusinessFacilityService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
