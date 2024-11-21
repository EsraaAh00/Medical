using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Models.VendorBusinessPolicy;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Vendor/[controller]")]
    public class VendorBusinessPolicyController : ControllerBase
    {
        private readonly IVendorBusinessPolicyService _VendorBusinessPolicyService;
        public VendorBusinessPolicyController(IVendorBusinessPolicyService VendorBusinessPolicyService)
        {
            _VendorBusinessPolicyService = VendorBusinessPolicyService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _VendorBusinessPolicyService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _VendorBusinessPolicyService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(VendorBusinessPolicyFullDataModel model)
        {
            return Ok(await _VendorBusinessPolicyService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(PagedFilterModel filter)
        {
            return Ok(await _VendorBusinessPolicyService.GetPagedList(filter));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _VendorBusinessPolicyService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _VendorBusinessPolicyService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
