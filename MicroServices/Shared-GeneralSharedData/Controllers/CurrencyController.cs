using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Shared_GeneralSharedData.Interfaces.Services;
using Shared_GeneralSharedData.Models.Currency;
using SharedModels.Models.Filter;
namespace Shared_GeneralSharedData.Controllers
{
    //  [Authorize]
    [ApiController]
    [Route("Shared/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _CurrencyService;
        public CurrencyController(ICurrencyService CurrencyService)
        {
            _CurrencyService = CurrencyService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _CurrencyService.GetById(id));
        }
        [HttpGet("DeleteAndActivate")]
        public async Task<ActionResult> DeleteAndActivate(int? id)
        {
            return Ok(await _CurrencyService.DeleteAndActivate(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(CurrencyFullDataModel model)
        {
            return Ok(await _CurrencyService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _CurrencyService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _CurrencyService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _CurrencyService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _CurrencyService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _CurrencyService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
