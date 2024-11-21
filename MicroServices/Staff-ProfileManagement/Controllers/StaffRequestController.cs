using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staff_StaffProfileManagement.Interfaces.Services;
using Staff_StaffProfileManagement.Models.StaffRequest;

namespace Staff_StaffProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Staff/[controller]")]
    public class StaffRequestController : ControllerBase
    {
        private readonly IStaffRequestService _StaffRequestService;
        public StaffRequestController(IStaffRequestService StaffRequestService)
        {
            _StaffRequestService = StaffRequestService;
        }
        #region CURD

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _StaffRequestService.GetById(id));
        }

        [HttpGet("GetListByState")]
        public async Task<ActionResult> GetListByState(int? state)
        {
            return Ok(await _StaffRequestService.GetListByState(state));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save(StaffRequestFullDataModel model)
        {
            return Ok(await _StaffRequestService.Save(model));
        }

        [HttpPost("RequestSetAccepted")]
        public async Task<ActionResult> RequestSetAccepted(int id)
        {
            return Ok(await _StaffRequestService.RequestSetAccepted(id));
        }

        [HttpPost("RequestSetRejected")]
        public async Task<ActionResult> RequestSetRejected(RejectionModel rejection)
        {
            return Ok(await _StaffRequestService.RequestSetRejected(rejection));
        }

        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _StaffRequestService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _StaffRequestService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
