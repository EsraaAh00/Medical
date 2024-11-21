using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Models.VendorRequest;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Controllers
{
    [ApiController]
 //   [Authorize]
    [Route("Vendor/[controller]")]
    public class VendorRequestController : ControllerBase
    {
        private readonly IVendorRequestService _VendorRequestService;
        public VendorRequestController(IVendorRequestService VendorRequestService)
        {
            _VendorRequestService = VendorRequestService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _VendorRequestService.GetById(id));
        }
        [HttpPost("VendorRequestDocumentation")]
        public async Task<ActionResult> VendorRequestDocumentation([FromForm]  VendorRequestDocumentationModel model)
        {
            return Ok(await _VendorRequestService.VendorRequestDocumentation(model));
        }
        [HttpPost("BusinessIdentifiaction")]
        public async Task<ActionResult> BusinessIdentifiaction([FromForm] BusinessIdentifiactionModel model)
        {
            return Ok(await _VendorRequestService.BusinessIdentifiaction(model));
        }

        [HttpPost("VendorBusinessLocation")]
        public async Task<ActionResult> VendorBusinessLocation(VendorBusinessLocationModel  model)
        {
            return Ok(await _VendorRequestService.VendorBusinessLocation(model));
        }



        [HttpPost("AccountSetup")]
        [AllowAnonymous]
        public async Task<ActionResult> AccountSetup([FromForm] VendorAccountDataModel model)
        {
            return Ok(await _VendorRequestService.AccountSetup(model));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save([FromForm] VendorRequestFullDataModel model)
        {
             return Ok(await _VendorRequestService.Save(model));
        }
        [HttpPost("RequestSetRejected")]
        public async Task<ActionResult> RequestSetRejected( RejectionModel model)
        {
            return Ok(await _VendorRequestService.RequestSetRejected(model));
        }
        [HttpPost("RequestSetAccepted")]
        public async Task<ActionResult> RequestSetAccepted(int id)
        {
            return Ok(await _VendorRequestService.RequestSetAccepted(id));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _VendorRequestService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _VendorRequestService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _VendorRequestService.GetIncludeByIdsList(ids));
        }
        [HttpGet("GetRequestStatusEnumDropDownList")]
        public ActionResult GetRequestStatusEnumDropDownList()
        {
            return Ok(_VendorRequestService.GetRequestStatusEnumDropDownList());
        }
        [HttpGet("GetRejectionReasonDropDownList")]
        public ActionResult GetRejectionReasonDropDownList()
        {
            return Ok(_VendorRequestService.GetRejectionReasonDropDownList());
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _VendorRequestService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _VendorRequestService.GetRecordLogger(recordId));
        }
        #endregion
    }
}