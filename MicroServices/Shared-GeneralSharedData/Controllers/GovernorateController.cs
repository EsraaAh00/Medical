using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Shared_GeneralSharedData.Interfaces.Services;
using Shared_GeneralSharedData.Models.Governorate;
using SharedModels.Models.Filter;
namespace Shared_GeneralSharedData.Controllers
{
    //  [Authorize]
    [ApiController]
    [Route("Shared/[controller]")]
    public class GovernorateController : ControllerBase
    {
        private readonly IGovernorateService _GovernorateService;
        public GovernorateController(IGovernorateService GovernorateService)
        {
            _GovernorateService = GovernorateService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _GovernorateService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _GovernorateService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(GovernorateFullDataModel model)
        {
            return Ok(await _GovernorateService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _GovernorateService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList(int? countryId)
        {
            return Ok(await _GovernorateService.GetDropDownList(countryId));
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _GovernorateService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _GovernorateService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _GovernorateService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
