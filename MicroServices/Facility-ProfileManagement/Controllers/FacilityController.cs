using Facility_FacilityProfileManagement.Interfaces.Services;
using Facility_FacilityProfileManagement.Models.Facility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models.Filter;

namespace Facility_FacilityProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Facility/[controller]")]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityService _FacilityService;
        public FacilityController(IFacilityService FacilityService)
        {
            _FacilityService = FacilityService;
        }
        #region CURD

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int Id)
        {
            return Ok(await _FacilityService.GetById(Id));
        }

        [HttpPost("getEntitiesByIds")]
        public async Task<ActionResult> GetListByIds([FromBody] List<int> ids)
        {
            return Ok(await _FacilityService.GetListByIds(ids));
        }

        [HttpGet("GetFilterList")]
        public async Task<ActionResult> GetFilterList(string Type, double lat, double lng)
        {
            return Ok(await _FacilityService.GetFilterList(Type,lat,lng));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save(FacilityFullDataModel model)
        {
            return Ok(await _FacilityService.Save(model));
        }

        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _FacilityService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _FacilityService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
