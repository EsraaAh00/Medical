using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Shared_GeneralSharedData.Interfaces.Services;
using Shared_GeneralSharedData.Models.Region;
using SharedModels.Models.Filter;
namespace Shared_GeneralSharedData.Controllers
{
    //   [Authorize]
    [ApiController]
    [Route("Shared/[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _RegionService;
        public RegionController(IRegionService RegionService)
        {
            _RegionService = RegionService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _RegionService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _RegionService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]

        public async Task<ActionResult> Save(RegionFullDataModel model)
        {
            return Ok(await _RegionService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _RegionService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList(int GovernorateId)
        {
            return Ok(await _RegionService.GetDropDownList(GovernorateId));
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _RegionService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _RegionService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _RegionService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
