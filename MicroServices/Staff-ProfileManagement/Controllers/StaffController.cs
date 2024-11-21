using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staff_StaffProfileManagement.Interfaces.Services;
using Staff_StaffProfileManagement.Models.Staff;

namespace Staff_StaffProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Staff/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _StaffService;
        public StaffController(IStaffService StaffService)
        {
            _StaffService = StaffService;
        }
        #region CURD

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int Id)
        {
            return Ok(await _StaffService.GetById(Id));
        }

        [HttpPost("GetListByIds")]
        public async Task<ActionResult> GetListByIds([FromBody] List<int> ids)
        {
            return Ok(await _StaffService.GetListByIds(ids));
        }

        [HttpGet("GetFilterList")]
        public async Task<ActionResult> GetFilterList(string Type, string Speciality)
        {
            return Ok(await _StaffService.GetFilterList(Type, Speciality));
        }


        [HttpGet("StateSetBlocked")]
        public async Task<ActionResult> StateSetBlocked(int Id)
        {
            return Ok(await _StaffService.StateSetBlocked(Id));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save(StaffFullDataModel model)
        {
            return Ok(await _StaffService.Save(model));
        }

        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _StaffService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _StaffService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
