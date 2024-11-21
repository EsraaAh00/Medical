using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staff_StaffProfileManagement.Interfaces.Services;

namespace Staff_StaffProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Staff/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IFilterService _FilterService;
        public SearchController(IFilterService FilterService)
        {
            _FilterService = FilterService;
        }

        [HttpGet("Search")]
        public async Task<ActionResult> Filter(string? Speciality, string Day, double lat, double lng)
        {
            return Ok(await _FilterService.GetList(Speciality, Day, lat, lng));
        }
    }
}
