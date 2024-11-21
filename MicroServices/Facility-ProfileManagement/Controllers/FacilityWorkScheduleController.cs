using Facility_FacilityProfileManagement.Interfaces.Services;
using Facility_FacilityProfileManagement.Models.FacilityWorkSchedule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models.Filter;

namespace Facility_FacilityProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Facility/[controller]")]
    public class FacilityWorkScheduleController : ControllerBase
    {
        private readonly IFacilityWorkScheduleService _FacilityWorkScheduleService;
        public FacilityWorkScheduleController(IFacilityWorkScheduleService FacilityWorkScheduleService)
        {
            _FacilityWorkScheduleService = FacilityWorkScheduleService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _FacilityWorkScheduleService.GetById(id));
        }

        [HttpGet("GetListById")]
        public async Task<ActionResult> GetListById(int? id)
        {
            return Ok(await _FacilityWorkScheduleService.GetListById(id));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save(FacilityWorkScheduleFullDataModel model)
        {
            return Ok(await _FacilityWorkScheduleService.Save(model));
        }

        [HttpPost("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _FacilityWorkScheduleService.DeleteAndActivate(id));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _FacilityWorkScheduleService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _FacilityWorkScheduleService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
