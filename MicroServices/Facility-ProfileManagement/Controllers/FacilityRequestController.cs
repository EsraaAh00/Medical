using Facility_FacilityProfileManagement.Interfaces.Services;
using Facility_FacilityProfileManagement.Models.FacilityRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models.Filter;

namespace Facility_FacilityProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Facility/[controller]")]
    public class FacilityRequestController : ControllerBase
    {
        private readonly IFacilityRequestService _FacilityRequestService;
        public FacilityRequestController(IFacilityRequestService FacilityRequestService)
        {
            _FacilityRequestService = FacilityRequestService;
        }
        #region CURD

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _FacilityRequestService.GetById(id));
        }

        [HttpGet("GetListByState")]
        public async Task<ActionResult> GetListByState(int? state)
        {
            return Ok(await _FacilityRequestService.GetListByState(state));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save(FacilityRequestFullDataModel model)
        {
            return Ok(await _FacilityRequestService.Save(model));
        }

        [HttpPost("RequestSetAccepted")]
        public async Task<ActionResult> RequestSetAccepted(int id)
        {
            return Ok(await _FacilityRequestService.RequestSetAccepted(id));
        }

        [HttpPost("RequestSetRejected")]
        public async Task<ActionResult> RequestSetRejected(RejectionModel rejection)
        {
            return Ok(await _FacilityRequestService.RequestSetRejected(rejection));
        }

        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _FacilityRequestService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _FacilityRequestService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
