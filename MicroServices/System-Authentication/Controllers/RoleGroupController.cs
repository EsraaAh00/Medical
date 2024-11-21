using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System_Authentication.Interfaces.Services;
using System_Authentication.Models.RoleGroup;
using SharedModels.Models.Filter;
using System_Authentication.Services;
namespace System_Authentication.Controllers
{
 //   [Authorize]
    [ApiController]
    [Route("System/[controller]")]
    public class RoleGroupController : ControllerBase
    {
        private readonly IRoleGroupService _RoleGroupService;
        public RoleGroupController(IRoleGroupService RoleGroupService)
        {
            _RoleGroupService = RoleGroupService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _RoleGroupService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _RoleGroupService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(RoleGroupFullDataModel model)
        {
            return Ok(await _RoleGroupService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _RoleGroupService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _RoleGroupService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _RoleGroupService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _RoleGroupService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _RoleGroupService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
