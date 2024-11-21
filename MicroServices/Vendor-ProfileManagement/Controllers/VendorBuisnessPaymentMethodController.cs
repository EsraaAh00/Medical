using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Models.VendorBusinessPaymentMethod;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Vendor/[controller]")]
    public class VendorBusinessPaymentMethodController : ControllerBase
    {
        private readonly IVendorBusinessPaymentMethodService _VendorBusinessPaymentMethodService;
        public VendorBusinessPaymentMethodController(IVendorBusinessPaymentMethodService VendorBusinessPaymentMethodService)
        {
            _VendorBusinessPaymentMethodService = VendorBusinessPaymentMethodService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _VendorBusinessPaymentMethodService.GetById(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(VendorBusinessPaymentMethodFullDataModel model)
        {
            return Ok(await _VendorBusinessPaymentMethodService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _VendorBusinessPaymentMethodService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _VendorBusinessPaymentMethodService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _VendorBusinessPaymentMethodService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _VendorBusinessPaymentMethodService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _VendorBusinessPaymentMethodService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
