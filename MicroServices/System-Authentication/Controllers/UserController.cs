using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System_Authentication.Interfaces.Services;
using System_Authentication.Models.User;
using SharedModels.Models.Filter;
using SharedModels.Models;
using System_Authentication.Services;

namespace System_Authentication.Controllers
{
    [ApiController]
 // [Authorize]
    [Route("System/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _UserService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _UserService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(UserFullDataModel model)
        {

            return Ok(await _UserService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(PagedFilterModel filter)
         {
            return Ok(await _UserService.GetPagedList(filter));
        }
        [HttpGet("GetDataList")]
        public async Task<ActionResult> GetDataList()
        {
            return Ok(await _UserService.GetDataList());
        }

        [HttpGet("CheckForRepetitationEmailAndPhone")]
        [AllowAnonymous]
        public async Task<ActionResult?> CheckForRepetitationEmailAndPhone(string? email, string? phone)
        {
            return Ok(await _UserService.CheckForRepetitationEmailAndPhone(email,phone));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _UserService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _UserService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
