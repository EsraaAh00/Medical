using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared_GeneralSharedData.Interfaces.Services;
using Shared_GeneralSharedData.Models.Speciality;
using SharedModels.Models.Filter;

namespace Shared_GeneralSharedData.Controllers
{
    //  [Authorize]
    [ApiController]
    [Route("Shared/[controller]")]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityService _SpecialityService;
        public SpecialityController(ISpecialityService SpecialityService)
        {
            _SpecialityService = SpecialityService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _SpecialityService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _SpecialityService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(SpecialityFullDataModel model)
        {
            return Ok(await _SpecialityService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _SpecialityService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _SpecialityService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _SpecialityService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _SpecialityService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _SpecialityService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
