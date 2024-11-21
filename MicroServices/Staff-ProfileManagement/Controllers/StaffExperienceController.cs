using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staff_StaffProfileManagement.Interfaces.Services;
using Staff_StaffProfileManagement.Models.StaffExperience;

namespace Staff_StaffProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Staff/[controller]")]
    public class StaffExperienceController : ControllerBase
    {
        private readonly IStaffExperienceService _StaffExperienceService;
        public StaffExperienceController(IStaffExperienceService StaffExperienceService)
        {
            _StaffExperienceService = StaffExperienceService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _StaffExperienceService.GetById(id));
        }

        [HttpGet("GetListById")]
        public async Task<ActionResult> GetListById(int? id)
        {
            return Ok(await _StaffExperienceService.GetListById(id));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save(StaffExperienceFullDataModel model)
        {
            return Ok(await _StaffExperienceService.Save(model));
        }

        [HttpPost("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _StaffExperienceService.DeleteAndActivate(id));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _StaffExperienceService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _StaffExperienceService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
