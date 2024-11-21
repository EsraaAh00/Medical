using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System_Authentication.Interfaces.Services;
using System_Authentication.Models.UserActionRole;
using SharedModels.Models.Filter;
using System_Authentication.Services;
namespace System_Authentication.Controllers
{
  //  [Authorize]
    [ApiController]
    [Route("System/[controller]")]
    public class UserActionRoleController : ControllerBase
    {
        private readonly IUserActionRoleService _UserActionRoleService;
        public UserActionRoleController(IUserActionRoleService UserActionRoleService)
        {
            _UserActionRoleService = UserActionRoleService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _UserActionRoleService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _UserActionRoleService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(UserActionRoleFullDataModel model)
        {
            return Ok(await _UserActionRoleService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(PagedFilterModel filter)
        {
            return Ok(await _UserActionRoleService.GetPagedList(filter));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _UserActionRoleService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _UserActionRoleService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
