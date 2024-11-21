using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System_Authentication.Interfaces.Services;
using System_Authentication.Models.ActionRole;
using SharedModels.Models.Filter;
using System_Authentication.Services;
namespace System_Authentication.Controllers
{
  //  [Authorize]
    [ApiController]
    [Route("System/[controller]")]
    public class ActionRoleController : ControllerBase
    {
        private readonly IActionRoleService _ActionRoleService;
        public ActionRoleController(IActionRoleService ActionRoleService)
        {
            _ActionRoleService = ActionRoleService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ActionRoleService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _ActionRoleService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(ActionRoleFullDataModel model)
        {
            return Ok(await _ActionRoleService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _ActionRoleService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList(int? roleGroupId)
        {
            return Ok(await _ActionRoleService.GetDropDownList(roleGroupId));
        }
        [HttpGet("GetDataList")]
        public async Task<ActionResult> GetDataList()
        {
            return Ok(await _ActionRoleService.GetDataList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _ActionRoleService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ActionRoleService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ActionRoleService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
