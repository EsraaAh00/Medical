using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System_Authentication.Interfaces.Services;
using System_Authentication.Models.Rank;
using SharedModels.Models.Filter;
namespace System_Authentication.Controllers
{
 //   [Authorize]
    [ApiController]
    [Route("System/[controller]")]
    public class RankController : ControllerBase
    {
        private readonly IRankService _RankService;
        public RankController(IRankService RankService)
        {
            _RankService = RankService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _RankService.GetById(id));
        }

        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
         {
            return Ok(await _RankService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(RankFullDataModel model)
        {
            return Ok(await _RankService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _RankService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _RankService.GetDropDownList());
        }
        [HttpGet("GetDataList")]
        public async Task<ActionResult> GetDataList()
        {
            return Ok(await _RankService.GetDataList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _RankService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _RankService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _RankService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
