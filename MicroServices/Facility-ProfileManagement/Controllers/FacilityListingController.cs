using Facility_FacilityProfileManagement.Interfaces.Services;
using Facility_FacilityProfileManagement.Models.FacilityListing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models.Filter;

namespace Facility_FacilityProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Facility/[controller]")]
    public class FacilityListingController : ControllerBase
    {
        private readonly IFacilityListingService _FacilityListingService;
        public FacilityListingController(IFacilityListingService FacilityListingService)
        {
            _FacilityListingService = FacilityListingService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int Id)
        {
            return Ok(await _FacilityListingService.GetById(Id));
        }


        [HttpGet("EntitiesById")]
        public async Task<ActionResult> EntitiesById(int Id)
        {
            return Ok(await _FacilityListingService.EntitiesById(Id));
        }


        [HttpGet("EntitiesBySpeciality")]
        public async Task<ActionResult> EntitiesBySpeciality(string Speciality)
        {
            return Ok(await _FacilityListingService.EntitiesBySpeciality(Speciality));
        }

        [HttpGet("EntitiesByIdSpeciality")]
        public async Task<ActionResult> EntitiesByIdSpeciality(int Id, string Speciality)
        {
            return Ok(await _FacilityListingService.EntitiesByIdSpeciality(Id,Speciality));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save(List<FacilityListingFullDataModel> models)
        {
            return Ok(await _FacilityListingService.Save(models));
        }

        [HttpPost("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int id)
        {
            return Ok(await _FacilityListingService.DeleteAndActivate(id));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _FacilityListingService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _FacilityListingService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
