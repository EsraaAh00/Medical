using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Shared_GeneralSharedData.Interfaces.Services;
using Shared_GeneralSharedData.Models.Country;
using SharedModels.Models.Filter;
namespace Shared_GeneralSharedData.Controllers
{
    //  [Authorize]
    [ApiController]
    [Route("Shared/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _CountryService;
        public CountryController(ICountryService CountryService)
        {
            _CountryService = CountryService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _CountryService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _CountryService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save([FromForm] CountryFullDataModel model)
        {
            return Ok(await _CountryService.Save(model));
        }
        [HttpGet("ActiveSetInActive")]
        public async Task<ActionResult> ActiveSetInActive(int id)
        {
            return Ok(await _CountryService.ActiveSetInActive(id));
        }
        [HttpGet("ActiveSetActive")]
        public async Task<ActionResult> ActiveSetActive(int id)
        {
            return Ok(await _CountryService.ActiveSetActive(id));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _CountryService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _CountryService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _CountryService.GetIncludeByIdsList(ids));
        }
        [HttpGet("GetActiveEnumDropDownList")]
        public ActionResult GetActiveEnumDropDownList()
        {
            return Ok(_CountryService.GetActiveEnumDropDownList());
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _CountryService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _CountryService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
