using Facility_FacilityProfileManagement.Interfaces.Services;
using Facility_FacilityProfileManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Facility_FacilityProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Facility/[controller]")]

    public class SearchController : ControllerBase
    {

        private readonly IFilterService _FilterService;
        public SearchController(IFilterService FilterService)
        {
            _FilterService = FilterService;
        }

        [HttpGet("Search")]
        public async Task<ActionResult> Filter(string Speciality , double lat , double lng)
        {
            return Ok(await _FilterService.GetList(Speciality, lat , lng));
        }
    }
}
