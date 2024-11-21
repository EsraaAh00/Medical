using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staff_StaffProfileManagement.Interfaces.Services;
using Staff_StaffProfileManagement.Models.StaffAward;

namespace Staff_StaffProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Staff/[controller]")]
    public class StaffAwardController : ControllerBase
    {
        private readonly IStaffAwardService _StaffAwardService;
        public StaffAwardController(IStaffAwardService StaffAwardService)
        {
            _StaffAwardService = StaffAwardService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _StaffAwardService.GetById(id));
        }

        [HttpGet("GetListById")]
        public async Task<ActionResult> GetListById(int? id)
        {
            return Ok(await _StaffAwardService.GetListById(id));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save(StaffAwardFullDataModel model)
        {
            return Ok(await _StaffAwardService.Save(model));
        }

        [HttpPost("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _StaffAwardService.DeleteAndActivate(id));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _StaffAwardService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _StaffAwardService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
