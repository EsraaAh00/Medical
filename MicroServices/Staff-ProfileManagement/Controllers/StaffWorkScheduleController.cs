using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staff_StaffProfileManagement.Interfaces.Services;
using Staff_StaffProfileManagement.Models.StaffWorkSchedule;

namespace Staff_StaffProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Staff/[controller]")]
    public class StaffWorkScheduleController : ControllerBase
    {
        private readonly IStaffWorkScheduleService _StaffWorkScheduleService;
        public StaffWorkScheduleController(IStaffWorkScheduleService StaffWorkScheduleService)
        {
            _StaffWorkScheduleService = StaffWorkScheduleService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int Id)
        {
            return Ok(await _StaffWorkScheduleService.GetById(Id));
        }


        [HttpGet("GetListById")]
        public async Task<ActionResult> GetListById(int? id)
        {
            return Ok(await _StaffWorkScheduleService.GetListById(id));
        }

        [HttpGet("EntitiesByDayLoc")]
        public async Task<ActionResult> EntitiesByDayLoc(string day, double lat, double lng)
        {
            return Ok(await _StaffWorkScheduleService.EntitiesByDayLoc(day, lat, lng));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save(StaffWorkScheduleFullDataModel model)
        {
            return Ok(await _StaffWorkScheduleService.Save(model));
        }

        [HttpPost("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int Id)
        {
            return Ok(await _StaffWorkScheduleService.DeleteAndActivate(Id));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _StaffWorkScheduleService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _StaffWorkScheduleService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
