using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System_Authentication.Interfaces.Services;
using System_Authentication.Models.UserRoleGroup;
using SharedModels.Models.Filter;
using System_Authentication.Services;
namespace System_Authentication.Controllers
{
  //  [Authorize]
    [ApiController]
    [Route("System/[controller]")]
    public class UserRoleGroupController : ControllerBase
    {
        private readonly IUserRoleGroupService _UserRoleGroupService;
        public UserRoleGroupController(IUserRoleGroupService UserRoleGroupService)
        {
            _UserRoleGroupService = UserRoleGroupService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _UserRoleGroupService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _UserRoleGroupService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(UserRoleGroupFullDataModel model)
        {
            return Ok(await _UserRoleGroupService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(PagedFilterModel filter)
        {
            return Ok(await _UserRoleGroupService.GetPagedList(filter));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _UserRoleGroupService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _UserRoleGroupService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
