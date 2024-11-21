using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared_GeneralSharedData.Interfaces.Services;
using Shared_GeneralSharedData.Models.Degree;
using SharedModels.Models.Filter;

namespace Shared_GeneralSharedData.Controllers
{
    //  [Authorize]
    [ApiController]
    [Route("Shared/[controller]")]
    public class DegreeController : ControllerBase
    {
        private readonly IDegreeService _DegreeService;
        public DegreeController(IDegreeService DegreeService)
        {
            _DegreeService = DegreeService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _DegreeService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _DegreeService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(DegreeFullDataModel model)
        {
            return Ok(await _DegreeService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _DegreeService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _DegreeService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _DegreeService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _DegreeService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _DegreeService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
