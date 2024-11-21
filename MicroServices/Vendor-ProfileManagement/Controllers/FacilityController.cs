using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Models.Facility;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Vendor/[controller]")]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityService _FacilityService;
        public FacilityController(IFacilityService FacilityService)
        {
            _FacilityService = FacilityService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _FacilityService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _FacilityService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save([FromForm] FacilityFullDataModel model)
        {
            return Ok(await _FacilityService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _FacilityService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _FacilityService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _FacilityService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _FacilityService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _FacilityService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
